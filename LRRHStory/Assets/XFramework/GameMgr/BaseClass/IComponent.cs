using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace XFramework
{
    public abstract class IComponent
    {
        public abstract void Add(IComponent childComponent);

        public abstract void Remove(IComponent childComponent);

        public abstract T GetChildComponent<T>();
    }
}
