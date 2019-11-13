using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace XFramework
{
    public class UIPanelBase
    {
        private UIPanelInfo Info;
        private UIView m_UIView;

        public UIPanelBase(Transform root, UIID uiId, GameObject prefab, int instanceId, params object[] param)
        {
            Info = new UIPanelInfo(uiId, prefab, instanceId);
            UnityEngine.Object.Instantiate(Info.Prefab, root);
            m_UIView = Info.Prefab.GetComponent<UIView>();
        }

        public void Open(params object[] param)
        {
            m_UIView.OpenUI(param);
        }
    }
}
