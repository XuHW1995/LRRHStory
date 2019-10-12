using UnityEngine;

namespace XFramework
{
    public class DebugMgr : GameMgr<DebugMgr>
    {
        public void Log(string msg)
        {
            if (ConfigMgr.instance.GlobalConfig.LogLevel >= LogLevel.normal)
            {
                Debug.Log(msg);
            }
        }

        public void LogWarning(string msg)
        {
            if (ConfigMgr.instance.GlobalConfig.LogLevel >= LogLevel.warning)
            {
                Debug.LogWarning(msg);
            }
        }

        public void LogError(string msg)
        {
            if (ConfigMgr.instance.GlobalConfig.LogLevel >= LogLevel.error)
            {
                Debug.LogError(msg);
            }
        }
    }
}
