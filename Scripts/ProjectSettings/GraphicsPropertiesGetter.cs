using UnityEngine;

namespace ProjectSettings
{
    public class GraphicsPropertiesGetter : MonoBehaviour
    {
        public int CurrentVsyncCount => QualitySettings.vSyncCount;
        public int CurrentMaxFPSValue => Application.targetFrameRate;
        public int CurrentQualityLevel => QualitySettings.GetQualityLevel();
    }
}