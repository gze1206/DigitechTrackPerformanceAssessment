namespace TPA.Framework.Core.Component
{
    public class Component
    {
        public GameObject gameObject { get; internal set; }
        public Transform transform { get => gameObject.transform; }

        public virtual void Update() { }
        public virtual void Render() { }

        public override string ToString()
        {
            return GetType().Name;
        }
    }
}
