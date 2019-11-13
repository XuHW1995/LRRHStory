using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine; 

namespace XFramework
{
    public class UIView : MonoBehaviour
    {

        public virtual void OpenUI(params object[] param) { }
        public virtual void CloseUI() { }
    }
}
