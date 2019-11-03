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
        public int InstanceId;

        public UIPanelInfo(UIID uiId, GameObject prefab, int instanceId)
        {
            Id = uiId;
            Prefab = prefab;
            InstanceId = instanceId;
        }
    }
}
