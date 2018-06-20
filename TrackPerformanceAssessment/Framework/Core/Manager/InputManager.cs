using System.Windows.Forms;

namespace TPA.Framework.Core.Manager
{
    public class InputManager : Singleton<InputManager>
    {
        public MouseEventHandler onMouseDown = (a, b) => { };
        public MouseEventHandler onMouseUp = (a, b) => { };
        public MouseEventHandler onMouseMove = (a, b) => { };
        public MouseEventHandler onMouseWheel = (a, b) => { };

        public KeyEventHandler onKeyDown = (a, b) => { };
        public KeyEventHandler onKeyUp = (a, b) => { };
    }
}
