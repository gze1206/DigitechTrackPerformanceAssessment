using System;
using System.Collections.Generic;
using System.Text;

namespace TPA.Framework.Core
{
    public class Singleton<T> : IDisposable where T : class, new()
    {
        private static bool __isDisposed = false;
        private static T __instance = null;

        public static T Get
        {
            get
            {
                if (!__isDisposed && __instance == null) __instance = new T();
                return __instance;
            }
        }
        public virtual void Dispose()
        {
            __isDisposed = true;
            __instance = null;
        }
    }
}
