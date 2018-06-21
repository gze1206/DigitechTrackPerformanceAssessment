using System.Collections.Generic;

namespace TPA.Framework.Core.Scene
{
    public class SceneManager : Singleton<SceneManager>
    {
        private Dictionary<string, BaseScene> sceneMaps = new Dictionary<string, BaseScene>();
        private BaseScene activeScene = null;
        private string nextKey = null;

        public void AddScene(string key, BaseScene scene) => sceneMaps.Add(key, scene);
        public void AddScene<T>(string key) where T: BaseScene, new() => sceneMaps.Add(key, new T());
        public BaseScene GetScene(string key) => sceneMaps[key];
        public BaseScene GetCurrentScene => activeScene;

        public void SetScene(string key) => nextKey = key;

        public void Update()
        {
            if (!string.IsNullOrEmpty(nextKey))
            {
                activeScene?.onInactive();
                activeScene = sceneMaps[nextKey];
                activeScene?.onActive();
                nextKey = null;
            }
            activeScene?.Update();
        }

        public void Render()
        {
            activeScene?.Render();
        }

        public override void Dispose()
        {
            activeScene?.onInactive();
            foreach (var iter in sceneMaps.Values)
            {
                iter?.Dispose();
            }
            base.Dispose();
        }
    }
}
