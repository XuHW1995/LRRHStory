using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFramework
{
    public interface IPool
    {
        T GetObj<T>() where T : BaseObjofPool, new();
        void RecycleObj(BaseObjofPool obj);
        void Release();
        void ReleaseFreeObj();
    }
}
