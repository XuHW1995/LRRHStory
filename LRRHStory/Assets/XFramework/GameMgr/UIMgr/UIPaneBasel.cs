using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace XFramework
{
    public class UIPanelBase : MonoBehaviour
    {
        public UIPanelInfo Info;

        public UIPanelBase(UIID uiId, GameObject prefab, int instanceId)
        {
            Info = new UIPanelInfo(uiId, prefab, instanceId);
        }
    

        public void OpenUI(Transform root, params object[] param)
        {
            Instantiate(Info.Prefab, root);
        }

        public void CloseUI()
        {

        }
    }
}
