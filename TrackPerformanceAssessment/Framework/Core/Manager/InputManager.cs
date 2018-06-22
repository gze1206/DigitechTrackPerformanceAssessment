using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TPA.Framework.Core.Manager
{
    public class InputManager : Singleton<InputManager>
    {
        private static Dictionary<Keys, bool> _keys = new Dictionary<Keys, bool>(256);

        public MouseEventHandler onMouseDown = (a, b) => { };
        public MouseEventHandler onMouseUp = (a, b) => { };
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
    }
}
