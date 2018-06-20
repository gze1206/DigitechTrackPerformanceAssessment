using System;
using System.Collections.Generic;
using System.Text;

namespace TPA.Framework.Core.Scene
{
    public delegate void SceneEvent();

    public abstract class BaseScene : IDisposable
    {
        public BaseScene()
        {
            Init();
        }

        public SceneEvent onActive = () => { };
        public SceneEvent onInactive = () => { };

        public abstract void Init();
        public abstract void Update();
        public abstract void Render();
        public abstract void Dispose();
    }
}
