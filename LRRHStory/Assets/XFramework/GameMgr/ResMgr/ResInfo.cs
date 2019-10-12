using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace XFramework
{
    public class ResInfo
    {
        private string m_name;
        private LoadAssetCallBack m_cb;
        private Type m_type;

        public string name { get { return m_name; } }
        public LoadAssetCallBack cb { get { return m_cb; } }
        public Type type { get { return m_type; } }

        public ResInfo(string name, Type type, LoadAssetCallBack cb)
        {
            m_name = name;
            m_type = type;
            m_cb = cb;
        }
    }
}

