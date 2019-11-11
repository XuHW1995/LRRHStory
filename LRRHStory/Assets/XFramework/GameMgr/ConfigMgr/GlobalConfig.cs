using UnityEngine;

namespace XFramework
{
    [CreateAssetMenu(fileName = "GlobalConfig", menuName = "ScriptableObjects/ClobalConfig", order = 1)]
    public class GlobalConfig : ScriptableObject
    {
        public bool EditorModel;
        public LogLevel LogLevel;
    }
}
