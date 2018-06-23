using System.Collections;
using System.Collections.Generic;

using Microsoft.DirectX;

using ChildList = System.Collections.Generic.List<TPA.Framework.Core.Transform>;

namespace TPA.Framework.Core
{
    public class Transform : Component.Component, IEnumerable<Transform>
    {
        private Vector3 _pos = new Vector3(), _rot = new Vector3(), _scale = new Vector3(1,1,1);
        private Matrix _locMat = new Matrix();
        private ChildList childs = new ChildList();

        public Vector3 localPosition { get => _pos; set => _pos = value; }
        public Vector3 localRotation { get => _rot; set => _rot = value; }
        public Vector3 localScale { get => _scale; set => _scale = value; }
        public Matrix localMatrix { get => _locMat; set => _locMat = value; }

        public Transform parent { get; private set; } = null;
        public int childCount { get => childs.Count; }
        
        public Vector3 position
        {
            get
            {
                if (parent == null) return localPosition;
                else                return parent.position + localPosition;
            }
            set
            {
                if (parent == null) localPosition = value;
                else                localPosition = value - parent.position;
            }
        }
        public Vector3 rotation
        {
            get
            {
                if (parent == null) return localRotation;
                else return parent.rotation + localRotation;
            }
            set
            {
                if (parent == null) localRotation = value;
                else localRotation = value - parent.rotation;
            }
        }
        public Vector3 scale
        {
            get
            {
                if (parent == null) return localScale;
                else return new Vector3(localScale.X * parent.scale.X, localScale.Y * parent.scale.Y, localScale.Z * parent.scale.Z);
            }
            set
            {
                if (parent == null) localScale = value;
                else localScale = new Vector3(value.X / parent.scale.X, value.Y / parent.scale.Y, value.Z / parent.scale.Z);
            }
        }

        public Matrix matrix {
            get
            {
                if (parent == null) return localMatrix;
                else                return parent.matrix * localMatrix;
            }
        }

        public void SetParent(Transform parent)
        {
            this.parent?.childs.Remove(this);
            this.parent = parent;
            this.parent?.childs.Add(this);
        }

        public ChildList GetChilds() => childs;
        public Transform GetChild(int index) => childs[index];

        public override void Update()
        {
            Matrix s = new Matrix(), r = new Matrix(), t = new Matrix();
            s.Scale(localScale);
            r.RotateYawPitchRoll(localRotation.Y, localRotation.X, localRotation.Z);
            t.Translate(localPosition);
            localMatrix = s * r * t;
        }

        public IEnumerator<Transform> GetEnumerator()
        {
            return ((IEnumerable<Transform>)childs).GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<Transform>)childs).GetEnumerator();
        }
    }
}
