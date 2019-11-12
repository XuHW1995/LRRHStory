using UnityEngine;
using System.Collections.Generic;

namespace XFramework
{
    public class DontDestroy : MonoBehaviour
    {
        static List<GameObject> m_AllDontDestoryObjs = new List<GameObject>();

        public static GameObject[] allDontDestoryObjs
        {
            get
            {
                return m_AllDontDestoryObjs.ToArray();
            }
        }

        void Awake()
        {
            m_AllDontDestoryObjs.Add(gameObject);
            GameObject.DontDestroyOnLoad(gameObject);
        }

        void OnDestroy()
        {
            if (m_AllDontDestoryObjs.Contains(gameObject))
            {
                m_AllDontDestoryObjs.Remove(gameObject);
            }
        }
    }
}
