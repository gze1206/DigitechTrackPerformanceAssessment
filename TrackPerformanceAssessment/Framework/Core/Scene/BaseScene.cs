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
            root = new GameObject();
            Init();
        }

        public SceneEvent onActive = () => { };
        public SceneEvent onInactive = () => { };
        public GameObject root;

        public abstract void Init();
        public virtual void Update()
        {
            root.Update();
        }
        public virtual void Render()
        {
            root.Render();
        }
        public abstract void Dispose();
    }
}
