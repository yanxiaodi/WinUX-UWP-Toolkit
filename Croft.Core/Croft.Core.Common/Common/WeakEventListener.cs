namespace WinUX.Common
{
    using System;

    public class WeakEventListener<TInstance, TSource>
        where TInstance : class
    {
        private readonly WeakReference _weakInstance;

        public WeakEventListener(TInstance instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException(nameof(instance));
            }

            this._weakInstance = new WeakReference(instance);
        }

        public Action<TInstance, TSource> OnEventAction { get; set; }

        public Action<TInstance, WeakEventListener<TInstance, TSource>> OnDetachAction { get; set; }

        public void OnEvent(TSource source)
        {
            var target = (TInstance)this._weakInstance.Target;
            if (target != null)
            {
                this.OnEventAction?.Invoke(target, source);
            }
            else
            {
                this.Detach();
            }
        }

        public void Detach()
        {
            var target = (TInstance)this._weakInstance.Target;
            if (this.OnDetachAction == null)
            {
                return;
            }

            this.OnDetachAction(target, this);
            this.OnDetachAction = null;
        }
    }

    public class WeakEventListener<TInstance, TSource, TEventArgs> where TInstance : class
    {
        private readonly WeakReference _weakInstance;

        public WeakEventListener(TInstance instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException(nameof(instance));
            }

            this._weakInstance = new WeakReference(instance);
        }

        public Action<TInstance, TSource, TEventArgs> OnEventAction { get; set; }

        public Action<TInstance, WeakEventListener<TInstance, TSource, TEventArgs>> OnDetachAction { get; set; }

        public void OnEvent(TSource source, TEventArgs eventArgs)
        {
            var target = (TInstance)this._weakInstance.Target;
            if (target != null)
            {
                this.OnEventAction?.Invoke(target, source, eventArgs);
            }
            else
            {
                this.Detach();
            }
        }

        public void Detach()
        {
            var target = (TInstance)this._weakInstance.Target;
            if (this.OnDetachAction == null)
            {
                return;
            }

            this.OnDetachAction(target, this);
            this.OnDetachAction = null;
        }
    }
}