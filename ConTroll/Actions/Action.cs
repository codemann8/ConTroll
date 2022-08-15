using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConTroll
{
    public abstract class Action
    {
        public string Name { get; private set; }
        public string Message { get; set; } = "";

        public Action(string name)
        {
            Name = name;
        }

        protected bool CanPerformAction() => CanPerformAction(ActionArgs.Empty);
        protected abstract bool CanPerformAction(ActionArgs args);

        private bool PerformAction() => PerformAction(ActionArgs.Empty);
        protected abstract bool PerformAction(ActionArgs args);

        public bool DoAction() => DoAction(ActionArgs.Empty);
        public bool DoAction(ActionArgs args)
        {
            if (CanPerformAction(args))
            {
                return PerformAction(args);
            }
            return false;
        }

        public abstract void UpdateStatus();
    }

    public class ActionArgs
    {
        public static readonly ActionArgs Empty = new ActionArgs();

        public ActionArgs() { }
        public ActionArgs(ActionArgs args) { }
    }
}
