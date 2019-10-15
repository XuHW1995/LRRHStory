using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace XFramework
{
    public class BasePool : IPool
    {
        private const int m_MaxCacheCount = 10;
        private List<BaseObjofPool> m_CacheObjList;

        public BasePool()
        {
            m_CacheObjList = new List<BaseObjofPool>();
        }

        public T GetObj<T>() where T:BaseObjofPool,new()
        {
            if (m_CacheObjList.Count > 0)
            {
                T item = m_CacheObjList[0] as T;
                m_CacheObjList.Remove(m_CacheObjList[0]);
                Debug.Log("从缓存中获取对象");
                return item;        
                
            }
            Debug.Log("创建新对象");
            return new T();
        }

        public void RecycleObj(BaseObjofPool obj)
        {
            if (m_CacheObjList.Count <= m_MaxCacheCount)
            {
                Debug.Log("加入缓存列表");
                m_CacheObjList.Add(obj);
            }
        }

        public void Release()
        {

        }

        public void ReleaseFreeObj()
        {

        }
    }
}
