using UnityEngine;

namespace XFramework
{
    public static class DebugMgr
    {
        public static void Log(string msg)
        {
            if (ConfigMgr.S.GlobalConfig.LogLevel >= LogLevel.normal)
            {
                Debug.Log(msg);
            }
        }

        public static void LogWarning(string msg)
        {
            if (ConfigMgr.S.GlobalConfig.LogLevel >= LogLevel.warning)
            {
                Debug.LogWarning(msg);
            }
        }

        public static void LogError(string msg)
        {
            if (ConfigMgr.S.GlobalConfig.LogLevel >= LogLevel.error)
            {
                Debug.LogError(msg);
            }
        }
    }
}
