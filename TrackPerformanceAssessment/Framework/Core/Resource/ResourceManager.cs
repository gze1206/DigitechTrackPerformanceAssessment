using System;
using System.Collections.Generic;
using System.IO;

using Microsoft.DirectX.Direct3D;

namespace TPA.Framework.Core.Resource
{
    public class ResourceManager : Singleton<ResourceManager>
    {
        private Dictionary<string, Texture> dicTexture = new Dictionary<string, Texture>();

        public Texture GetTexture(string path)
        {
            if (dicTexture.ContainsKey(path)) return dicTexture[path];

            Texture tex = TextureLoader.FromFile(MainGame.Get.device, path);
            dicTexture[path] = tex;
            return tex;
        }
    }
}
