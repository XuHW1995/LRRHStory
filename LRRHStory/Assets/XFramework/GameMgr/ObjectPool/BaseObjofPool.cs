using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace XFramework
{
    public class BaseObjofPool
    {
        private bool m_Free;
        public bool Free
        {
            get
            {
                return m_Free;
            }
            set
            {
                m_Free = value;
            }
        }

        public BaseObjofPool()
        {
            m_Free = true;
        }

        public virtual void Release()
        {

        }
    }
}
