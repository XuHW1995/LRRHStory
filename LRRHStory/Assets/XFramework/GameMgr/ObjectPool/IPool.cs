using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFramework
{
    public interface IPool<TPObj> where TPObj : AbstractObjectOfPool, new()
    {
        TPObj GetObj();
        void RecycleObj(TPObj obj);
        void Release();
        void ReleaseFreeObj();
    }
}
