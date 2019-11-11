using UnityEngine;
using UnityEditor;

namespace XFramework
{
    public class ConfigMgr : GameMgr<ConfigMgr>
    {
        private GlobalConfig m_globalConfig;
        public GlobalConfig GlobalConfig
        {
            get { return m_globalConfig; }
        }

        public override void Init()
        {
            m_globalConfig = AssetDatabase.LoadAssetAtPath<GlobalConfig>("Assets/XFramework/GameMgr/Config/GlobalConfig.asset");
            if (m_globalConfig == null)
            {
                DebugMgr.instance.LogError("GlobalConfig is invalid!");
            }
        }
    }
}
