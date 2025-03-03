﻿using System.Linq;
using System.Collections.Generic;

using Radiance.Events;
using Radiance.Coroutines;

namespace Radiance.Components
{
    public abstract partial class Component
    {
        public bool Active { get; set; }
        public Component Parent { get; set; }
        public Transform Transform { get; protected set; }

        public List<Component> Children;

        public Component(Component parent = null, Transform transform = null)
        {
            this.Active = true;
            this.Parent = parent;
            this.Children = new List<Component>();
            this.Transform = transform ?? this.CreateTransform();
        }

        public T AddComponent<T>(T c) where T : Component
        {
            if (!this.Children.Contains(c))
            {
                c.Parent = this;
                this.Children.Add(c);
            }
            return c;
        }

        public T GetComponent<T>() where T : Component
        {
            return this.Children.Where(o => o is T).FirstOrDefault() as T;
        }

        public void RemoveComponent<T>(T c) where T : Component
        {
            this.Children.Remove(c);
        }

        public List<Component> GetAllChildren()
        {
            return this.Children.Concat(this.Children.SelectMany(c => c.GetAllChildren())).ToList();
        }

        public Coroutine StartCoroutine(IEnumerator<CoroutineState> coroutine)
        {
            var newCoroutine = new Coroutine(this, coroutine);
            RadianceGame.Instance.StartCoroutine(newCoroutine);
            return newCoroutine;
        }

        public virtual void Start()
        {
            foreach (Component child in this.Children)
            {
                child.Start();
            }
        }

        public virtual void Sleep()
        {
            foreach (Component child in this.Children)
            {
                child.Sleep();
            }
        }

        public virtual void OnMouseDown(MouseEventArgs e)
        {
            foreach (Component child in this.Children)
            {
                child.OnMouseDown(e);
            }
        }

        public virtual void OnMouseUp(MouseEventArgs e)
        {
            foreach (Component child in this.Children)
            {
                child.OnMouseUp(e);
            }
        }

        public virtual void OnMouseMove(MouseEventArgs e)
        {
            foreach (Component child in this.Children)
            {
                child.OnMouseMove(e);
            }
        }

        public virtual void OnMouseScrollUp(MouseEventArgs e)
        {
            foreach (Component child in this.Children)
            {
                child.OnMouseScrollUp(e);
            }
        }

        public virtual void OnMouseScrollDown(MouseEventArgs e)
        {
            foreach (Component child in this.Children)
            {
                child.OnMouseScrollDown(e);
            }
        }

        protected virtual Transform CreateTransform()
        {
            return new Transform(this);
        }
    }
}
