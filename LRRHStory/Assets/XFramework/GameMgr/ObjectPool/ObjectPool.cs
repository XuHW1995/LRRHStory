using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace XFramework
{
    sealed class ObjectPool<TObjofPool> : AbstractObjectPool, IPool<TObjofPool> where TObjofPool : BaseObjofPool, new()
    {
        private string m_name = string.Empty;
        private readonly int m_MaxCacheCount = 10;
        private List<TObjofPool> m_CacheObjList;

        public ObjectPool(string name)
        {
            m_CacheObjList = new List<TObjofPool>();
            m_name = name;
        }

        public TObjofPool GetObj()
        {
            if (m_CacheObjList.Count > 0)
            {
                TObjofPool item = m_CacheObjList[0];
                m_CacheObjList.Remove(m_CacheObjList[0]);
                item.Free = false;
                Debug.Log("从缓存中获取对象");
                return item;
            }
            Debug.Log("创建新对象");
            return new TObjofPool();
        }

        public void RecycleObj(TObjofPool obj)
        {
            if (m_CacheObjList.Count <= m_MaxCacheCount)
            {
                Debug.Log("加入缓存列表");
                m_CacheObjList.Add(obj);
                obj.Free = true;
            }
        }

        public override void Release()
        {
            foreach (TObjofPool item in m_CacheObjList)
            {
                item.Release();
            }
            m_CacheObjList.Clear();
        }

        public override void ReleaseFreeObj()
        {
            for (int i = m_CacheObjList.Count - 1; i >= 0 ; i--)
            {
                if (m_CacheObjList[i].Free)
                {
                    m_CacheObjList[i].Release();
                    m_CacheObjList.Remove(m_CacheObjList[i]);
                }
            }
        }
    }
}
