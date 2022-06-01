using System.Windows.Forms;

//TODO: Move this to a Util library
namespace System.Windows.Forms
{
    public class ToolStripDropDownButtonEx : ToolStripDropDownButton
    {
        public ToolStripDropDownButtonEx()
        {
        }

        protected override void OnMouseHover(EventArgs e)
        {
            if (this.Parent != null)
                Parent.Focus();
            base.OnMouseHover(e);
        }
    }
}
