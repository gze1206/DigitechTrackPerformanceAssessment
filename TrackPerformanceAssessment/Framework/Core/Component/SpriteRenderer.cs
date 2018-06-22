using System.Drawing;

using Resources = TPA.Framework.Core.Resource.ResourceManager;

namespace TPA.Framework.Core.Component
{
    public class SpriteRenderer : Component
    {
        public string path = string.Empty;
        public Color color = Color.White;
        public Point pivot = new Point();

        public override void Render()
        {
            MainGame.Get.sprite.Draw2D(Resources.Get.GetTexture(path), new Point(), 0.0f, new Point((int)transform.position.X - pivot.X, (int)transform.position.Y - pivot.Y), color);
        }
    }
}
