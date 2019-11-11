using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace XFramework
{
    public abstract class AbstractObjectOfPool
    {
        private bool m_Free;
        public bool Free{ get { return m_Free; }}

        public AbstractObjectOfPool()
        {
            m_Free = true;
        }
        //调用
        public virtual void OnUse()
        {
            m_Free = false;
        }
        //回收重置
        public virtual void Reset()
        {
            m_Free = true;
        }
        //释放
        public virtual void Release()
        {
        
        }
    }
}
