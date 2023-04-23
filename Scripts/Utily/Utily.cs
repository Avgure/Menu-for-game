using UnityEngine;

public static class Utily
{
    public static string[] GraphicsQualityLevels { get; } =
        { "Very Low", "Low", "Medium", "High", "Very High", "Ultra" };
    public enum PreferencesInSettings
    {
        /// <summary>
        /// ScreenSettings
        /// </summary>
        ChosenScreenModeIndex,
        ChosenResolutionSimpleIndex,
        ChosenRefreshRateIndex,

        /// <summary>
        /// GraphicsSettings
        /// </summary>
        ChosenVsyncToggleValue,
        ChosenMaxFPSValue,
        ChosenQualityLevelValue
    }
    public static FullScreenMode GetFullScreenModeByIndex(int index)
    {
        return index switch
        {
            0 => FullScreenMode.ExclusiveFullScreen,
            1 => FullScreenMode.FullScreenWindow,
            3 => FullScreenMode.Windowed,
            _ => throw new System.NotImplementedException(),
        };
    }
}