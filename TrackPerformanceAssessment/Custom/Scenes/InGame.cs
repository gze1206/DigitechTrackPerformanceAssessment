using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;

using TPA.Framework;
using TPA.Framework.Core;
using Resources = TPA.Framework.Core.Resource.ResourceManager;
using TPA.Framework.Core.Scene;
using TPA.Framework.Core.Component;
using TPA.Framework.Core.Manager;
using System.Windows.Forms;

namespace TPA.Custom.Scenes
{
    public class InGame : BaseScene
    {
        public GameObject gameObject;

        public InGame() : base()
        {
            onActive += Init;
        }

        public override void Init()
        {
            Resources.Get.GetTexture("../Resources/PsBulletM.png");
            gameObject = new GameObject(SceneManager.Get.GetCurrentScene.root.transform);
            var renderer = gameObject.AddComponent<SpriteRenderer>();
            renderer.path = "../Resources/PsBulletM.png";
            renderer.pivot = new Point(128, 256);
        }

        public override void Update()
        {
            base.Update();

            if (InputManager.Get.GetKey(Keys.Left)) gameObject.transform.position += new Vector3(-10, 0, 0);
            if (InputManager.Get.GetKey(Keys.Right)) gameObject.transform.position += new Vector3(10, 0, 0);
            if (InputManager.Get.GetKey(Keys.Up)) gameObject.transform.position += new Vector3(0, -10, 0);
            if (InputManager.Get.GetKey(Keys.Down)) gameObject.transform.position += new Vector3(0, 10, 0);
        }

        public override void Render()
        {
            base.Render();
        }

        public override void Dispose()
        {
        }
    }
}
