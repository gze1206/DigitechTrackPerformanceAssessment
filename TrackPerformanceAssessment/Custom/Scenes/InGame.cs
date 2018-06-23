using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

using Microsoft.DirectX;

using TPA.Framework.Core;
using TPA.Framework.Core.Scene;
using TPA.Framework.Core.Component;

using TPA.Custom.Components;

using Resources = TPA.Framework.Core.Resource.ResourceManager;

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

            gameObject = new GameObject();
            var renderer = gameObject.AddComponent<SpriteRenderer>();
            renderer.path = "../Resources/PsBulletM.png";
            renderer.pivot = new Vector3(128, 256, 0);
            gameObject.AddComponent<CharacterController>();
        }

        public override void Update()
        {
            base.Update();
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
