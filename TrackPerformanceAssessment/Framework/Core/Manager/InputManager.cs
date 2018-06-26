using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TPA.Framework.Core.Manager
{
    public class InputManager : Singleton<InputManager>
    {
        private static Dictionary<Keys, bool> _keys = new Dictionary<Keys, bool>(256);
        private static bool[] _mouse = new bool[3] { false, false, false };

        public MouseEventHandler onMouseDown = (object a, MouseEventArgs b) => { if (b.Button == MouseButtons.Left) _mouse[0] = true; else if (b.Button == MouseButtons.Right) _mouse[1] = true; else if (b.Button == MouseButtons.Middle) _mouse[2] = true; };
        public MouseEventHandler onMouseUp = (object a, MouseEventArgs b) => { if (b.Button == MouseButtons.Left) _mouse[0] = false; else if (b.Button == MouseButtons.Right) _mouse[1] = false; else if (b.Button == MouseButtons.Middle) _mouse[2] = false; };
        public MouseEventHandler onMouseMove = (a, b) => { };
        public MouseEventHandler onMouseWheel = (a, b) => { };

        public KeyEventHandler onKeyDown = (object a, KeyEventArgs b) => { _keys[b.KeyCode] = true; };
        public KeyEventHandler onKeyUp = (object a, KeyEventArgs b) => { _keys[b.KeyCode] = false; };

        public InputManager()
        {
            for (int i = 0; i < 262145; i++)
                _keys.Add((Keys)Enum.Parse(typeof(Keys), ((Keys)i).ToString()), false);
        }

        public bool GetKey(Keys keyCode) => _keys[keyCode];

        public bool GetMouseDown(MouseButtons button) => _mouse[button == MouseButtons.Left ? 0 : button == MouseButtons.Right ? 1 : 2];
    }
}
