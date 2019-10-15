using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XFramework
{
    public class PoolMgr : GameMgr<PoolMgr>
    {
        private Dictionary<string, IPool> m_poolDic;
       
        public override void Init()
        {
            m_poolDic = new Dictionary<string, IPool>();
        }

        //获取对象池
        public IPool GetPool<T>(string name) where T : IPool, new()
        {
            if (m_poolDic.ContainsKey(name))
            {
                return m_poolDic[name];
            }

            m_poolDic[name] = CreatNewPool<T>(name);
            return m_poolDic[name];
        }

        //创建对象池
        private IPool CreatNewPool<T>(string name) where T : IPool, new()
        {
            IPool newPool = new T() as IPool;
            m_poolDic[name] = newPool;
            return newPool;
        }

        //释放对象池
        public void ReleasePool(string name)
        {
            if (!m_poolDic.ContainsKey(name))
            {
                return;
            }

            m_poolDic[name].Release();
        }

        //释放全部
        public void ReleaseAll()
        {
            foreach(KeyValuePair<string, IPool> onepool in m_poolDic)
            {
                onepool.Value.Release();
            }       
        }
    }
}

