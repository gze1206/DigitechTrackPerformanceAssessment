using System.Collections.Generic;

namespace TPA.Framework.Core
{
    public class GameObject
    {
        private List<Component.Component> components = new List<Component.Component>();
        public Transform transform { get; private set; }
        public string name { get; set; } = "new GameObject";

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
        // Set name to custom name
        public GameObject(string name) : this()
        {
            this.name = name;
        }
        // Set name and parent to custom value
        public GameObject(string name, Transform parent) : this(parent)
        {
            this.name = name;
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
        public bool HasComponent<T>() where T : Component.Component
        {
            foreach (var iter in components)
            {
                // T 상속 받은 컴포넌트를 반환
                if (typeof(T).IsAssignableFrom(iter.GetType()))
                {
                    return true;
                }
            }
            return false;
        }
        public T FindComponentFromChildren<T>() where T : Component.Component
        {
            foreach (var child in transform)
            {
                foreach (var iter in child.gameObject.components)
                {
                    // T 상속 받은 컴포넌트를 반환
                    if (typeof(T).IsAssignableFrom(iter.GetType()))
                    {
                        return iter as T;
                    }
                }
            }
            return null;
        }

        public override string ToString()
        {
            return name;
        }
    }
}
