using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using Object = UnityEngine.Object;

namespace XFramework
{
    public class EditorResLoader : IResLoader
    {
        //加载队列
        private List<ResInfo> m_LoadingRes;
        private Dictionary<string, Object> m_cacheRes;

        private ResInfo m_curResInfo;

        public EditorResLoader()
        {
            m_LoadingRes = new List<ResInfo>();
            m_cacheRes = new Dictionary<string, Object>();
            DebugMgr.instance.Log("编辑模式加载器创建完成");
        }

        #region 生命周期
        public void Start()
        {

        }

        public void Update()
        {
            if (m_LoadingRes.Count > 0)
            {
                m_curResInfo = m_LoadingRes[0];

                Object asset;
                if (m_cacheRes.TryGetValue(m_curResInfo.name, out asset))
                {
                    //do nothing;
                }
                else
                {
                    asset = AssetDatabase.LoadAssetAtPath(m_curResInfo.name, m_curResInfo.type);
                    m_cacheRes.Add(m_curResInfo.name, asset);
                }

                if (asset != null)
                {
                    m_curResInfo.cb(true, asset);
                    m_LoadingRes.Remove(m_curResInfo);                    
                }
                else
                {
                    DebugMgr.instance.LogError("加载资源失败:" + m_curResInfo.name);
                }
            }     
        }

        public void Release()
        {

        }
        #endregion

        public void LoadAsset(string name, Type type, LoadAssetCallBack cb)
        {
            ResInfo resinfo = new ResInfo(name, type, cb);
            m_LoadingRes.Add(resinfo);
        }

        public void LoadScene(string sceneName)
        {
        }
    }
}

