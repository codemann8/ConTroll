using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using LiteDB;

using System.Windows.Forms;

namespace ConTroll
{
    public class Database
    {
        public static string DATABASE_FILE = "config.db";

        public Config.User CurrentUser;
        public Config.Settings Settings;

        public Database()
        {
            BsonMapper.Global.EmptyStringToNull = false;

            using (var db = new LiteDatabase(DATABASE_FILE))
            {
                var users = db.GetCollection<Config.User>("users");
                if (!File.Exists(DATABASE_FILE))
                {
                    var user = new Config.User
                    {
                        Name = "User1"
                    };
                    users.Insert(user);
                }

                CurrentUser = users.FindById(1);

                Settings = new Config.Settings();
                var connections = db.GetCollection<Config.Connections>("connections");
                if (connections.Find(x => x.UserId == CurrentUser.Id).Count() == 1)
                {
                    Settings.Connections = connections.Find(x => x.UserId == CurrentUser.Id).First();
                }
                else
                {
                    Settings.Connections = new Config.Connections();
                    Settings.Connections.UserId = CurrentUser.Id;
                    Settings.Connections.OBSAddress = "";
                    Settings.Connections.OBSPassword = "";
                    Settings.Connections.SNIAddress = "";
                    connections.Insert(Settings.Connections);
                }

                var socialDistortions = db.GetCollection<Config.SocialDistortion>("socialdistortion");
                if (socialDistortions.Find(x => x.UserId == CurrentUser.Id).Count() == 1)
                {
                    Settings.SocialDistortion = socialDistortions.Find(x => x.UserId == CurrentUser.Id).First();
                }
                else
                {
                    Settings.SocialDistortion = new Config.SocialDistortion();
                    Settings.SocialDistortion.UserId = CurrentUser.Id;
                    Settings.SocialDistortion.OBSSourceName = "";
                    Settings.SocialDistortion.Interval = 60;
                    Settings.SocialDistortion.TransitionDuration = 1000;
                    Settings.SocialDistortion.MaxTilt = 4;
                    Settings.SocialDistortion.AdjustmentX = 0;
                    Settings.SocialDistortion.AdjustmentY = 0;
                    Settings.SocialDistortion.ColorizeDuration = 8000;
                    Settings.SocialDistortion.MirrorHorizontal = DistortionActivity.DistortEnabled.Random;
                    Settings.SocialDistortion.MirrorVertical = DistortionActivity.DistortEnabled.Random;
                    Settings.SocialDistortion.Rotate = DistortionActivity.DistortEnabled.Random;
                    Settings.SocialDistortion.ZoomIn = DistortionActivity.DistortEnabled.Random;
                    Settings.SocialDistortion.ScaleHorizontal = DistortionActivity.DistortEnabled.Random;
                    Settings.SocialDistortion.ScaleVertical = DistortionActivity.DistortEnabled.Random;
                    Settings.SocialDistortion.ShearHorizontal = DistortionActivity.DistortEnabled.Random;
                    Settings.SocialDistortion.ShearVertical = DistortionActivity.DistortEnabled.Random;
                    Settings.SocialDistortion.Colorize = DistortionActivity.DistortEnabled.AlwaysOn;
                    socialDistortions.Insert(Settings.SocialDistortion);
                }
            }
        }

        public void Update(Config.LiteTableRecord record)
        {
            using (var db = new LiteDatabase(DATABASE_FILE))
            {
                if (record.GetType() == typeof(Config.User))
                {
                    var collection = db.GetCollection<Config.User>(record.TableName);
                    collection.Update((Config.User)record);
                }
                else if (record.GetType() == typeof(Config.Connections))
                {
                    var collection = db.GetCollection<Config.Connections>(record.TableName);
                    collection.Update((Config.Connections)record);
                }
                else if (record.GetType() == typeof(Config.SocialDistortion))
                {
                    var collection = db.GetCollection<Config.SocialDistortion>(record.TableName);
                    collection.Update((Config.SocialDistortion)record);
                }
            }
        }
    }
}

namespace ConTroll.Config
{
    public class Settings
    {
        public Connections Connections { get; set; }
        public SocialDistortion SocialDistortion { get; set; }
    }

    public class LiteTableRecord
    {
        [BsonIgnore]
        public string TableName { get; set; }
    }

    public class User : LiteTableRecord
    {
        public User() { TableName = "users"; }
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Connections : LiteTableRecord
    {
        public Connections() { TableName = "connections"; }
        public int Id { get; set; }
        public int UserId { get; set; }
        public string OBSAddress { get; set; }
        public string OBSPassword { get; set; }
        public string SNIAddress { get; set; }
    }

    public class SocialDistortion : LiteTableRecord
    {
        public SocialDistortion() { TableName = "socialdistortion"; } 
        public int Id { get; set; }
        public int UserId { get; set; }
        public string OBSSourceName { get; set; }
        public uint Interval { get; set; }
        public uint TransitionDuration { get; set; }
        public double MaxTilt { get; set; }
        public double AdjustmentX { get; set; }
        public double AdjustmentY { get; set; }
        public uint ColorizeDuration { get; set; }
        public DistortionActivity.DistortEnabled MirrorHorizontal { get; set; }
        public DistortionActivity.DistortEnabled MirrorVertical { get; set; }
        public DistortionActivity.DistortEnabled Rotate { get; set; }
        public DistortionActivity.DistortEnabled ZoomIn { get; set; }
        public DistortionActivity.DistortEnabled ScaleHorizontal { get; set; }
        public DistortionActivity.DistortEnabled ScaleVertical { get; set; }
        public DistortionActivity.DistortEnabled ShearHorizontal { get; set; }
        public DistortionActivity.DistortEnabled ShearVertical { get; set; }
        public DistortionActivity.DistortEnabled Colorize { get; set; }
    }
}
