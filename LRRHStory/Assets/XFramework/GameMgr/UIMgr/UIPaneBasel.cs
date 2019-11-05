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
  
        public void LoadSuccess(Transform root, UIID uiId, GameObject prefab, int instanceId)
        {
            Info = new UIPanelInfo(uiId, prefab, instanceId);
            Instantiate(Info.Prefab, root);
        }

        public virtual void OpenUI(params object[] param)
        {
            
        }

        public virtual void CloseUI()
        {

        }
    }
}
