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
        public UIID Id;
        public GameObject Prefab;

        public UIPanelInfo(UIID uiId, GameObject prefab)
        {
            Id = uiId;
            Prefab = prefab;
        }
    }

    public class UIPanelBase
    {
        private UIPanelInfo Info;
        private UIView m_UIView;

        public UIPanelBase(UIRoot root, UIID uiId, GameObject prefab)
        {
            Info = new UIPanelInfo(uiId, prefab);
            //TODO 根据面板层级类型决定显示在哪个根节点上
            UnityEngine.Object.Instantiate(Info.Prefab, root.mainRoot);
            m_UIView = Info.Prefab.GetComponent<UIView>();
        }

        public void Open(params object[] param)
        {
            m_UIView.OpenUI(param);
        }
    }
}
