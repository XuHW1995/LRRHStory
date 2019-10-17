using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFramework
{
    public abstract class AbstractObjectPool
    {
        public abstract void Release();
        public abstract void ReleaseFreeObj();
    }
}
