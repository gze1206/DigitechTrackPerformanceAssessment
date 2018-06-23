using System.Drawing;

using Microsoft.DirectX;

using Resources = TPA.Framework.Core.Resource.ResourceManager;

namespace TPA.Framework.Core.Component
{
    public class SpriteRenderer : Component
    {
        public string path = string.Empty;
        public Color color = Color.White;
        public Vector3 pivot = new Vector3();

        public override void Render()
        {
            MainGame.Get.sprite.Transform = transform.matrix;
            MainGame.Get.sprite.Draw(Resources.Get.GetTexture(path), pivot, new Vector3(), color.ToArgb());
        }
    }
}
