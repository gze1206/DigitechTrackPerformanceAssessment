using System;
using System.Collections.Generic;
using System.Text;

namespace TPA.Framework.Core
{
    public class GameObject
    {
        private List<Component.Component> components = new List<Component.Component>();
        public Transform transform { get; private set; }

        // Set parent to current scene's root object
        public GameObject()
        {
            transform = AddComponent<Transform>();
            transform.SetParent(Scene.SceneManager.Get.GetCurrentScene?.root.transform);
        }

        // Set parent to custom parent
        public GameObject(Transform parent)
        {
            transform = AddComponent<Transform>();
            transform.SetParent(parent);
        }

        public virtual void Update()
        {
            transform.Update();
            foreach (var iter in components)
            {
                if (iter == transform) continue;
                iter.Update();
            }

            foreach (var iter in transform)
            {
                iter.gameObject.Update();
            }
        }
        public virtual void Render()
        {
            foreach (var iter in components)
            {
                if (iter == transform) continue;
                iter.Render();
            }

            foreach (var iter in transform)
            {
                iter.gameObject.Render();
            }
        }

        public T AddComponent<T>() where T : Component.Component, new()
        {
            T com = new T();
            com.gameObject = this;
            components.Add(com);
            return com;
        }
        public T GetComponent<T>() where T : Component.Component
        {
            foreach (var iter in components)
            {
                // T 상속 받은 컴포넌트를 반환
                if (typeof(T).IsAssignableFrom(iter.GetType()))
                {
                    return iter as T;
                }
            }
            return null;
        }
    }
}
