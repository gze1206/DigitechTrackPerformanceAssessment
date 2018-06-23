using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using Microsoft.DirectX;

using TPA.Framework;
using TPA.Framework.Core;
using TPA.Framework.Core.Manager;
using TPA.Framework.Core.Component;

namespace TPA.Custom.Components
{
    public class CharacterController : Component
    {
        public override void Update()
        {
            Vector3 move = new Vector3();

            if (InputManager.Get.GetKey(Keys.Left)) move += new Vector3(-1, 0, 0);
            if (InputManager.Get.GetKey(Keys.Right)) move += new Vector3(1, 0, 0);
            if (InputManager.Get.GetKey(Keys.Up)) move += new Vector3(0, -1, 0);
            if (InputManager.Get.GetKey(Keys.Down)) move += new Vector3(0, 1, 0);

            move.Normalize();
            transform.position += move * 10;
        }
    }
}
