using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Newtonsoft.Json.Linq;

using SNIConnect;
using OBSWebsocketDotNet;
using OBSWebsocketDotNet.Types;

namespace ConTroll
{
    public class DistortionActivity : Action, IDisposable
    {
        private Main _main;
        private OBSConnect _obs;
        private SNIClient _sni;

        public DistortStatus Status;

        private static string DISTORT_FILTER = "DistortMode";
        private static string DISTORT_MOVE_FILTER = "DistortMove";
        private static string DISTORT_COLOR_FILTER = "DistortColor";
        private static string DISTORT_COLOR_MOVE_FILTER = "DistortColorMove";
        private static string DISTORT_COLOR_MOVE2_FILTER = "DistortColorMove2";
        private static string DISTORT_TILT_FILTER = "DistortTilt";

        private static MediaPlayback[] DistortSounds = {
            new MediaPlayback() { Stream = Properties.Resources.BOTW___Ready_Go_Start, Duration = 2800 },
            new MediaPlayback() { Stream = Properties.Resources.Super_Mario_Kart___Time_Trial_Start, Duration = 2400 }
        };

        private bool MirrorModeZoomed = false;
        private bool MirrorModeFlippedX = false;
        private bool MirrorModeFlippedY = false;
        private bool MirrorModeRotated = false;
        private bool MirrorModeScaledX = false;
        private bool MirrorModeScaledY = false;
        private bool MirrorModeShearedX = false;
        private bool MirrorModeShearedY = false;
        private bool MirrorModeColorized = false;
        private double MirrorModeTilt = Properties.Settings.Default.DistortTilt;
        private bool MirrorModeTiltDir = false;

        private Task Process;
        private bool IsCancelPending = false;

        struct MediaPlayback
        {
            public System.IO.Stream Stream { get; set; }
            public string Filename { get; set; }
            public int Duration { get; set; }
        }

        public DistortionActivity(Main main) : base("Social Distortion")
        {
            _main = main;
            _obs = main._obs;
            _sni = main._sni;
        }

        protected override bool CanPerformAction(ActionArgs args)
        {
            DistortionActionArgs actionArgs = new DistortionActionArgs(args);
            if (!actionArgs.ShouldReset
                && Properties.Settings.Default.DistortMirrorX == CheckState.Unchecked
                && Properties.Settings.Default.DistortMirrorY == CheckState.Unchecked
                && Properties.Settings.Default.DistortRotate == CheckState.Unchecked
                && Properties.Settings.Default.DistortZoom == CheckState.Unchecked
                && Properties.Settings.Default.DistortScaleX == CheckState.Unchecked
                && Properties.Settings.Default.DistortScaleY == CheckState.Unchecked
                && Properties.Settings.Default.DistortShearX == CheckState.Unchecked
                && Properties.Settings.Default.DistortShearY == CheckState.Unchecked
                && Properties.Settings.Default.DistortColor == CheckState.Unchecked)
            {
                this.Message = "No Social Distortion effects are enabled";
                return false;
            }

            if (_obs != null && _obs.Status != OBSConnect.OBSStatus.Connected)
            {
                this.Message = "OBS is not connected";
                return false;
            }

            if (Properties.Settings.Default.OBSGameSource == "")
            {
                this.Message = "No OBS Game Source is selected";
                return false;
            }

            if (MirrorModeFlippedX || MirrorModeFlippedY || MirrorModeRotated || Properties.Settings.Default.DistortMirrorX != CheckState.Unchecked || Properties.Settings.Default.DistortMirrorY != CheckState.Unchecked || Properties.Settings.Default.DistortRotate != CheckState.Unchecked)
            {
                if (_sni == null || _sni.Status == SNIClient.DeviceState.SNIOffline || _sni.Status == SNIClient.DeviceState.NoDevice)
                {
                    this.Message = "No devices are detected thru SNI";
                    return false;
                }

                if (_sni.Status == SNIClient.DeviceState.DeviceRunning || _sni.Status == SNIClient.DeviceState.DeviceRunningLive)
                {
                    string header = _sni.GetROMHeader();
                    if (header == "NO-ROM" || header.StartsWith("NO-CONF-"))
                    {
                        this.Message = "No ROM detected. If the ROM is loaded, try restarting SNI.";
                        return false;
                    }
                    if (!header.EndsWith("O"))
                    {
                        this.Message = "Mirroring and Rotating is incompatible with this ROM. Currently only seeds generated from the OWR branch are compatible. Try disabling Mirroring and Rotating effects.";
                        return false;
                    }
                }
                else
                {
                    this.Message = "No ROM detected. If the ROM is loaded, try power-cycling the console and SNI.";
                    return false;
                }
            }

            try
            {
                _obs._obs.GetSourceSettings(Properties.Settings.Default.OBSGameSource);
            }
            catch (ErrorResponseException ex)
            {
                this.Message = "The selected OBS Game Source does not exist";
                return false;
            }

            Dictionary<string, string> filters = new Dictionary<string, string>() {
                { "streamfx-filter-transform", "StreamFX" },
                { "move_value_filter", "Move Transition" }
            };
            foreach (SourceType type in _obs._obs.GetSourceTypesList())
            {
                if (type.Type == "filter" && filters.ContainsKey(type.TypeID))
                {
                    filters.Remove(type.TypeID);
                    if (filters.Count == 0)
                    {
                        this.Message = "";
                        return true;
                    }
                }
            }
            this.Message = "OBS is missing the following plugins: " + string.Join(", ", filters.Values);
            return false;
        }

        public void Start()
        {
            if (Status == DistortStatus.Stopped && CanPerformAction())
            {
                UpdateStatus(DistortStatus.Running);
                IsCancelPending = false;

                Process = Task.Run(() =>
                {
                    RunDistortion();
                });
            }
            UpdateStatus();
        }

        public void Stop()
        {
            IsCancelPending = true;
            Task.Run(() =>
            {
                if (Status == DistortStatus.Stopped)
                {
                    DistortionActionArgs args = new DistortionActionArgs(true);
                    DoAction(args);
                    return;
                }

                while (Status != DistortStatus.Running)
                {
                    System.Threading.Thread.Sleep(100);
                }

                UpdateStatus(DistortStatus.Stopped);
            });
        }

        private void RunDistortion()
        {
            if (System.Threading.Thread.CurrentThread.Name == null)
            {
                System.Threading.Thread.CurrentThread.Name = "DistortionWorker";
            }

            //byte[] raw = _sni.Read(0, 0x10000);
            //System.IO.File.WriteAllBytes(@"L:\_Work\Zelda\test-out.bin", raw);

            DistortionActionArgs args = new DistortionActionArgs(true);
            if (DoAction(args))
            {
                UpdateStatus(DistortStatus.Busy);

                while (!IsCancelPending && DoAction())
                {
                    UpdateStatus(DistortStatus.Running);

                    uint timeout = Properties.Settings.Default.DistortInterval;
                    while (timeout > 0 && !IsCancelPending)
                    {
                        System.Threading.Thread.Sleep(1000);
                        timeout--;
                    }

                    UpdateStatus(DistortStatus.Busy);
                }
                UpdateStatus();

                DoAction(args);
            }

            UpdateStatus(DistortStatus.Stopped);
        }

        protected override bool PerformAction(ActionArgs args)
        {
            DistortionActionArgs actionArgs = new DistortionActionArgs(args);

            bool InputsFlipped = MirrorModeFlippedX || MirrorModeFlippedY || MirrorModeRotated;
            bool InputsMightFlip = Properties.Settings.Default.DistortMirrorX != CheckState.Unchecked || Properties.Settings.Default.DistortMirrorY != CheckState.Unchecked || Properties.Settings.Default.DistortRotate != CheckState.Unchecked;

            if (!actionArgs.ShouldReset && _sni != null && (InputsFlipped || InputsMightFlip))
            {
                switch (_sni.Status)
                {
                    case SNIClient.DeviceState.DeviceRunning:
                        byte value = _sni.Read(0x7e0010);
                        if (value == 0x19 || value == 0x1a)
                        {
                            return false;
                        }
                        break;
                    case SNIClient.DeviceState.SNIOffline:
                    case SNIClient.DeviceState.NoDevice:
                        return false;
                }
            }

            if (actionArgs.ShouldReset || _sni.Status == SNIClient.DeviceState.DeviceStandby)
            {
                //add filters if they don't exist
                try
                {
                    _obs._obs.GetSourceFilterInfo(Properties.Settings.Default.OBSGameSource, DISTORT_FILTER);
                }
                catch (ErrorResponseException ex)
                {
                    JObject settings = new JObject();
                    OBSConnect.AddOrReplaceProperty(settings, "Camera.FieldOfView", 90.0);
                    OBSConnect.AddOrReplaceProperty(settings, "Camera.Mode", 1);

                    _obs._obs.AddFilterToSource(Properties.Settings.Default.OBSGameSource, DISTORT_FILTER, "streamfx-filter-transform", settings);
                }

                try
                {
                    _obs._obs.GetSourceFilterInfo(Properties.Settings.Default.OBSGameSource, DISTORT_MOVE_FILTER);
                }
                catch (ErrorResponseException ex)
                {
                    JObject settings = new JObject();
                    OBSConnect.AddOrReplaceProperty(settings, "filter", DISTORT_FILTER);
                    OBSConnect.AddOrReplaceProperty(settings, "move_value_type", 1);
                    OBSConnect.AddOrReplaceProperty(settings, "value_type", 2);
                    OBSConnect.AddOrReplaceProperty(settings, "end_delay", 100);

                    _obs._obs.AddFilterToSource(Properties.Settings.Default.OBSGameSource, DISTORT_MOVE_FILTER, "move_value_filter", settings);
                    _obs._obs.GetSourceFilterInfo(Properties.Settings.Default.OBSGameSource, DISTORT_MOVE_FILTER);
                }

                try
                {
                    _obs._obs.GetSourceFilterInfo(Properties.Settings.Default.OBSGameSource, DISTORT_TILT_FILTER);
                }
                catch (ErrorResponseException ex)
                {
                    JObject settings = new JObject();
                    OBSConnect.AddOrReplaceProperty(settings, "filter", DISTORT_FILTER);
                    OBSConnect.AddOrReplaceProperty(settings, "move_value_type", 1);
                    OBSConnect.AddOrReplaceProperty(settings, "value_type", 2);
                    OBSConnect.AddOrReplaceProperty(settings, "duration", 300);
                    OBSConnect.AddOrReplaceProperty(settings, "easing_match", 2);
                    OBSConnect.AddOrReplaceProperty(settings, "easing_function_match", 10);

                    _obs._obs.AddFilterToSource(Properties.Settings.Default.OBSGameSource, DISTORT_TILT_FILTER, "move_value_filter", settings);
                }

                try
                {
                    var b = _obs._obs.GetSourceFilterInfo(Properties.Settings.Default.OBSGameSource, DISTORT_COLOR_FILTER);
                }
                catch (ErrorResponseException ex)
                {
                    JObject settings = new JObject();
                    OBSConnect.AddOrReplaceProperty(settings, "hue_shift", 0.0);

                    _obs._obs.AddFilterToSource(Properties.Settings.Default.OBSGameSource, DISTORT_COLOR_FILTER, "color_filter", settings);
                }

                try
                {
                    _obs._obs.GetSourceFilterInfo(Properties.Settings.Default.OBSGameSource, DISTORT_COLOR_MOVE_FILTER);
                }
                catch (ErrorResponseException ex)
                {
                    JObject settings = new JObject();
                    OBSConnect.AddOrReplaceProperty(settings, "filter", DISTORT_COLOR_FILTER);
                    OBSConnect.AddOrReplaceProperty(settings, "move_value_type", 0);
                    OBSConnect.AddOrReplaceProperty(settings, "value_type", 2);
                    OBSConnect.AddOrReplaceProperty(settings, "setting_name", "hue_shift");
                    OBSConnect.AddOrReplaceProperty(settings, "setting_float", 180.0);
                    OBSConnect.AddOrReplaceProperty(settings, "easing_match", 0);
                    OBSConnect.AddOrReplaceProperty(settings, "duration", Properties.Settings.Default.DistortColorDuration);

                    _obs._obs.AddFilterToSource(Properties.Settings.Default.OBSGameSource, DISTORT_COLOR_MOVE_FILTER, "move_value_filter", settings);
                    _obs._obs.GetSourceFilterInfo(Properties.Settings.Default.OBSGameSource, DISTORT_COLOR_MOVE_FILTER);
                }

                try
                {
                    _obs._obs.GetSourceFilterInfo(Properties.Settings.Default.OBSGameSource, DISTORT_COLOR_MOVE2_FILTER);
                }
                catch (ErrorResponseException ex)
                {
                    JObject settings = new JObject();
                    OBSConnect.AddOrReplaceProperty(settings, "filter", DISTORT_COLOR_FILTER);
                    OBSConnect.AddOrReplaceProperty(settings, "move_value_type", 0);
                    OBSConnect.AddOrReplaceProperty(settings, "value_type", 2);
                    OBSConnect.AddOrReplaceProperty(settings, "setting_name", "hue_shift");
                    OBSConnect.AddOrReplaceProperty(settings, "setting_float", -180.0);
                    OBSConnect.AddOrReplaceProperty(settings, "duration", 10);
                    OBSConnect.AddOrReplaceProperty(settings, "easing_match", 0);
                    OBSConnect.AddOrReplaceProperty(settings, "next_move", DISTORT_COLOR_MOVE_FILTER);

                    _obs._obs.AddFilterToSource(Properties.Settings.Default.OBSGameSource, DISTORT_COLOR_MOVE2_FILTER, "move_value_filter", settings);
                    _obs._obs.GetSourceFilterInfo(Properties.Settings.Default.OBSGameSource, DISTORT_COLOR_MOVE2_FILTER);
                }

                FilterSettings f = _obs._obs.GetSourceFilterInfo(Properties.Settings.Default.OBSGameSource, DISTORT_MOVE_FILTER);
                OBSConnect.AddOrReplaceProperty(f.Settings, "next_move", DISTORT_TILT_FILTER);
                _obs._obs.SetSourceFilterSettings(Properties.Settings.Default.OBSGameSource, DISTORT_MOVE_FILTER, f.Settings);

                //reset mirror mode
                MirrorModeZoomed = false;
                MirrorModeFlippedX = false;
                MirrorModeFlippedY = false;
                MirrorModeRotated = false;
                MirrorModeScaledX = false;
                MirrorModeScaledY = false;
                MirrorModeShearedX = false;
                MirrorModeShearedY = false;
                MirrorModeColorized = Properties.Settings.Default.DistortColor == CheckState.Checked;
                MirrorModeTilt = 0.0;
            }
            else
            {
                _obs._obs.SetSourceFilterVisibility(Properties.Settings.Default.OBSGameSource, DISTORT_FILTER, true);
                _obs._obs.SetSourceFilterVisibility(Properties.Settings.Default.OBSGameSource, DISTORT_COLOR_FILTER, true);
                List<DistortEffect> effects = new List<DistortEffect>();
                if (Properties.Settings.Default.DistortMirrorX == CheckState.Indeterminate) effects.Add(DistortEffect.MirrorX);
                else MirrorModeFlippedX = Properties.Settings.Default.DistortMirrorX == CheckState.Checked;
                if (Properties.Settings.Default.DistortMirrorY == CheckState.Indeterminate) effects.Add(DistortEffect.MirrorY);
                else MirrorModeFlippedY = Properties.Settings.Default.DistortMirrorY == CheckState.Checked;
                if (Properties.Settings.Default.DistortRotate == CheckState.Indeterminate) effects.Add(DistortEffect.Rotate);
                else MirrorModeRotated = Properties.Settings.Default.DistortRotate == CheckState.Checked;
                if (Properties.Settings.Default.DistortZoom == CheckState.Indeterminate) effects.Add(DistortEffect.Zoom);
                else MirrorModeZoomed = Properties.Settings.Default.DistortZoom == CheckState.Checked;
                if (Properties.Settings.Default.DistortScaleX == CheckState.Indeterminate) effects.Add(DistortEffect.ScaleX);
                else MirrorModeScaledX = Properties.Settings.Default.DistortScaleX == CheckState.Checked;
                if (Properties.Settings.Default.DistortScaleY == CheckState.Indeterminate) effects.Add(DistortEffect.ScaleY);
                else MirrorModeScaledY = Properties.Settings.Default.DistortScaleY == CheckState.Checked;
                if (Properties.Settings.Default.DistortShearX == CheckState.Indeterminate) effects.Add(DistortEffect.ShearX);
                else MirrorModeShearedX = Properties.Settings.Default.DistortShearX == CheckState.Checked;
                if (Properties.Settings.Default.DistortShearY == CheckState.Indeterminate) effects.Add(DistortEffect.ShearY);
                else MirrorModeShearedY = Properties.Settings.Default.DistortShearY == CheckState.Checked;
                if (Properties.Settings.Default.DistortColor == CheckState.Indeterminate) effects.Add(DistortEffect.Colorize);
                else MirrorModeColorized = Properties.Settings.Default.DistortColor == CheckState.Checked;

                if (effects.Count > 0)
                {
                    //play sound
                    Random r = new Random();
                    if (Properties.Settings.Default.DistortInterval >= 10)
                    {
                        int i = r.Next(0, DistortSounds.Length);
                        if (DistortSounds[i].Stream != null)
                        {
                            DistortSounds[i].Stream.Position = 0;
                        }
                        using (System.Media.SoundPlayer player = new System.Media.SoundPlayer(DistortSounds[i].Stream))
                        {
                            player.Play();
                        };
                        System.Threading.Thread.Sleep(DistortSounds[i].Duration);
                    }

                    //randomly flip one setting
                    switch (effects[r.Next(0, effects.Count)])
                    {
                        case DistortEffect.MirrorX:
                            MirrorModeFlippedX = !MirrorModeFlippedX;
                            break;
                        case DistortEffect.MirrorY:
                            MirrorModeFlippedY = !MirrorModeFlippedY;
                            break;
                        case DistortEffect.Rotate:
                            MirrorModeRotated = !MirrorModeRotated;
                            MirrorModeTiltDir = r.Next() % 2 == 0;
                            break;
                        case DistortEffect.Zoom:
                            MirrorModeZoomed = !MirrorModeZoomed;
                            break;
                        case DistortEffect.ScaleX:
                            MirrorModeScaledX = !MirrorModeScaledX;
                            break;
                        case DistortEffect.ScaleY:
                            MirrorModeScaledY = !MirrorModeScaledY;
                            break;
                        case DistortEffect.ShearX:
                            MirrorModeShearedX = !MirrorModeShearedX;
                            break;
                        case DistortEffect.ShearY:
                            MirrorModeShearedY = !MirrorModeShearedY;
                            break;
                        case DistortEffect.Colorize:
                            MirrorModeColorized = !MirrorModeColorized;
                            break;
                    }

                    if (!MirrorModeRotated)
                    {
                        MirrorModeTiltDir = r.Next() % 2 == 0;
                    }
                    MirrorModeTilt = r.NextDouble() * Properties.Settings.Default.DistortTilt;
                }
            }

            //set animation destination settings to OBS filter
            FilterSettings filter = _obs._obs.GetSourceFilterInfo(Properties.Settings.Default.OBSGameSource, DISTORT_MOVE_FILTER);
            OBSConnect.AddOrReplaceProperty(filter.Settings, "duration", Properties.Settings.Default.DistortDuration);
            OBSConnect.AddOrReplaceProperty(filter.Settings, "Position.X", MirrorModeFlippedY ^ MirrorModeRotated ? Properties.Settings.Default.DistortAdjustX : 0.0);
            OBSConnect.AddOrReplaceProperty(filter.Settings, "Position.Y", MirrorModeFlippedX ^ MirrorModeRotated ? Properties.Settings.Default.DistortAdjustY : 0.0);
            OBSConnect.AddOrReplaceProperty(filter.Settings, "Position.Z", MirrorModeZoomed ? 33.0 : 0.0);
            OBSConnect.AddOrReplaceProperty(filter.Settings, "Scale.X", MirrorModeScaledX ? 66.0 : 100.0);
            OBSConnect.AddOrReplaceProperty(filter.Settings, "Scale.Y", MirrorModeScaledY ? 66.0 : 100.0);
            OBSConnect.AddOrReplaceProperty(filter.Settings, "Shear.X", MirrorModeShearedX ? 33.0 : 0.0);
            OBSConnect.AddOrReplaceProperty(filter.Settings, "Shear.Y", MirrorModeShearedY ? 33.0 : 0.0);
            OBSConnect.AddOrReplaceProperty(filter.Settings, "Rotation.X", MirrorModeFlippedX ? 180.0 : 0.0);
            OBSConnect.AddOrReplaceProperty(filter.Settings, "Rotation.Y", MirrorModeFlippedY ? 180.0 : 0.0);
            OBSConnect.AddOrReplaceProperty(filter.Settings, "Rotation.Z", MirrorModeRotated ? (MirrorModeTiltDir ? -180.0 : 180.0) : 0.0);
            _obs._obs.SetSourceFilterSettings(Properties.Settings.Default.OBSGameSource, DISTORT_MOVE_FILTER, filter.Settings);

            FilterSettings filter2 = _obs._obs.GetSourceFilterInfo(Properties.Settings.Default.OBSGameSource, DISTORT_TILT_FILTER);
            OBSConnect.AddOrReplaceProperty(filter2.Settings, "Position.X", filter.Settings.Property("Position.X").Value);
            OBSConnect.AddOrReplaceProperty(filter2.Settings, "Position.Y", filter.Settings.Property("Position.Y").Value);
            OBSConnect.AddOrReplaceProperty(filter2.Settings, "Position.Z", filter.Settings.Property("Position.Z").Value);
            OBSConnect.AddOrReplaceProperty(filter2.Settings, "Scale.X", filter.Settings.Property("Scale.X").Value);
            OBSConnect.AddOrReplaceProperty(filter2.Settings, "Scale.Y", filter.Settings.Property("Scale.Y").Value);
            OBSConnect.AddOrReplaceProperty(filter2.Settings, "Shear.X", filter.Settings.Property("Shear.X").Value);
            OBSConnect.AddOrReplaceProperty(filter2.Settings, "Shear.Y", filter.Settings.Property("Shear.Y").Value);
            OBSConnect.AddOrReplaceProperty(filter2.Settings, "Rotation.X", filter.Settings.Property("Rotation.X").Value);
            OBSConnect.AddOrReplaceProperty(filter2.Settings, "Rotation.Y", filter.Settings.Property("Rotation.Y").Value);
            OBSConnect.AddOrReplaceProperty(filter2.Settings, "Rotation.Z", (Double)filter.Settings.Property("Rotation.Z").Value + (MirrorModeTilt * (MirrorModeTiltDir ? 1 : -1)));
            _obs._obs.SetSourceFilterSettings(Properties.Settings.Default.OBSGameSource, DISTORT_TILT_FILTER, filter2.Settings);

            _obs._obs.SetSourceFilterVisibility(Properties.Settings.Default.OBSGameSource, DISTORT_MOVE_FILTER, true);

            filter = _obs._obs.GetSourceFilterInfo(Properties.Settings.Default.OBSGameSource, DISTORT_COLOR_MOVE_FILTER);
            OBSConnect.AddOrReplaceProperty(filter.Settings, "duration", Properties.Settings.Default.DistortColorDuration);
            OBSConnect.AddOrReplaceProperty(filter.Settings, "hue_shift", MirrorModeColorized ? 180.0 : 0.0);
            OBSConnect.AddOrReplaceProperty(filter.Settings, "next_move", MirrorModeColorized ? DISTORT_COLOR_MOVE2_FILTER : "");
            _obs._obs.SetSourceFilterSettings(Properties.Settings.Default.OBSGameSource, DISTORT_COLOR_MOVE_FILTER, filter.Settings);
            _obs._obs.SetSourceFilterVisibility(Properties.Settings.Default.OBSGameSource, DISTORT_COLOR_MOVE_FILTER, true);

            //change inputs
            if (_sni != null && (_sni.Status == SNIClient.DeviceState.DeviceRunning || _sni.Status == SNIClient.DeviceState.DeviceRunningLive) && (InputsFlipped || InputsMightFlip))
            {
                bool InputsFlippedLR = MirrorModeFlippedY ^ MirrorModeRotated;
                bool InputsFlippedUD = MirrorModeFlippedX ^ MirrorModeRotated;

                byte value = 0;
                switch ((InputsFlippedLR ? 1 : 0) + (InputsFlippedUD ? 2 : 0))
                {
                    case 1:
                        value = 5;
                        break;
                    case 2:
                        value = 6;
                        break;
                    case 3:
                        value = 1;
                        break;
                    default:
                        value = 0;
                        break;
                }
                System.Threading.Thread.Sleep((int)Properties.Settings.Default.DistortDuration / 2 + 100);
                //if (value > 0)
                //{
                //    _emu.Freeze(0x7f50cb, value);
                //}
                //else
                //{
                //    _emu.Unfreeze(0x7f50cb);
                //    _emu.Write(0x7f50cb, value);
                //}
                _sni.Write(0x7f50cb, value);
            }

            //disable mirror mode
            if (actionArgs.ShouldReset)
            {
                System.Threading.Thread.Sleep((int)Properties.Settings.Default.DistortDuration + 500);
                _obs._obs.SetSourceFilterVisibility(Properties.Settings.Default.OBSGameSource, DISTORT_FILTER, false);
                _obs._obs.SetSourceFilterVisibility(Properties.Settings.Default.OBSGameSource, DISTORT_COLOR_FILTER, false);
            }

            return true;
        }

        private void UpdateStatus(DistortStatus status)
        {
            Status = status;
            UpdateStatus();
        }

        public override void UpdateStatus()
        {
            Image img;
            switch (Status)
            {
                case DistortStatus.Running:
                    img = Properties.Resources.OnlineStatusAvailable;
                    break;
                case DistortStatus.Busy:
                    img = Properties.Resources.OnlineStatusAway;
                    break;
                default:
                    img = Properties.Resources.OnlineStatusUnknown;
                    break;
            }

            _main.BeginInvoke((MethodInvoker)(() => {
                if (Message != "")
                {
                    img = Properties.Resources.OnlineStatusPresenting;
                }
                _main.tooltip.SetToolTip(_main.btnActivityDistortion, Message);

                if (img != _main.btnActivityDistortion.Image)
                {
                    _main.btnActivityDistortion.Image.Dispose();
                    _main.btnActivityDistortion.Image = img;
                }
                _main.btnActivityDistortion.Image = img;
            }));
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public enum DistortEffect
        {
            MirrorX = 0,
            MirrorY = 1,
            Rotate = 2,
            Zoom = 3,
            ScaleX = 4,
            ScaleY = 5,
            ShearX = 6,
            ShearY = 7,
            Colorize = 8
        }

        public enum DistortStatus
        {
            Stopped = 0,
            Running = 1,
            Busy = 2
        }
    }

    public class DistortionActionArgs : ActionArgs
    {
        public bool ShouldReset;
        public DistortionActionArgs(bool shouldReset = false)
        {
            this.ShouldReset = shouldReset;
        }
        public DistortionActionArgs(ActionArgs args)
        {
            if (args.GetType() == typeof(DistortionActionArgs))
            {
                this.ShouldReset = ((DistortionActionArgs)args).ShouldReset;
            }
        }
    }
}
