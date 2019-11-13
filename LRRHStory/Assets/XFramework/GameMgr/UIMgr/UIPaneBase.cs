using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace XFramework
{
    public class UIPanelInfo
    {
        public UIData UIData { get; }
        public GameObject Obj { get; }

        public UIPanelInfo(UIData sData, GameObject obj)
        {
            UIData = sData;
            Obj = obj;
        }
    }

    public class UIPanelBase
    {
        private UIPanelInfo m_PanelInfo;
        public UIView m_UIView;

        public UIPanelBase(UIData uiStaticData, GameObject prefab)
        {    
            m_PanelInfo = new UIPanelInfo(uiStaticData, UnityEngine.Object.Instantiate(prefab));
            InnerSetParentRoot(true);
            m_UIView = m_PanelInfo.Obj.GetComponent<UIView>();
        }

        public void Open(params object[] param)
        {
            InnerSetParentRoot(true);
            m_UIView.OpenUI(param);
        }

        public void Close()
        {
            InnerSetParentRoot(false);
            m_UIView.CloseUI();
        }

        public void Destroy()
        {
            
        }

        private void InnerSetParentRoot(bool isOpen)
        {
            if (isOpen)
            {
                //TODO 根据面板层级类型决定显示在哪个根节点上
                m_PanelInfo.Obj.transform.SetParent(UIMgr.S.UIRoot.MainRoot);
                m_PanelInfo.Obj.SetActive(true);
            }
            else
            {
                m_PanelInfo.Obj.transform.SetParent(UIMgr.S.UIRoot.CacheRoot);
                m_PanelInfo.Obj.SetActive(false);
            }
        }
    }
}
