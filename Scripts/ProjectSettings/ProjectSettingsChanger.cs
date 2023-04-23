using Menu;
using UnityEngine;
using System;

namespace ProjectSettings
{
    public class ProjectSettingsChanger : MonoBehaviour
    {
        [SerializeField] private ScreenSettingsUIBlock _screenSettingsUIBlock;
        [SerializeField] private GraphicsSettingsUIBlock _graphicsSettingsUIBlock;

        [SerializeField] private ScreenPropertiesGetter _screenPropertiesGetter;
        [SerializeField] private GraphicsPropertiesGetter _graphicsPropertiesGetter;


        public void SetAllSettings()
        {
            if (_graphicsSettingsUIBlock != null)
                SetGraphicsSettings();
            if (_screenSettingsUIBlock != null)
                SetScreenSettings();
        }
        public void SetAllSettings(PreferencesInSettingsSaver preferencesInSettingsSaver)
        {
            if (_graphicsSettingsUIBlock != null)
                SetGraphicsSettings(preferencesInSettingsSaver);
            if (_screenSettingsUIBlock != null)
                SetScreenSettings(preferencesInSettingsSaver);
        }


        public void SetGraphicsSettings()
        {
            SetQualityLevel();
            SetVsync();
            SetMaxFPS();

            void SetQualityLevel()
            {
                int value = _graphicsSettingsUIBlock.ChosenQualityLevelValue;
                QualitySettings.SetQualityLevel(value);
                Debug.Log($"Graphics quality level set to: {_graphicsPropertiesGetter.CurrentQualityLevel}");
            }
            void SetVsync()
            {
                int value = _graphicsSettingsUIBlock.ChosenVsyncToggleValue;
                QualitySettings.vSyncCount = value;
                Debug.Log($"V-sync count: {_graphicsPropertiesGetter.CurrentVsyncCount}");
            }
            void SetMaxFPS()
            {
                int value = _graphicsSettingsUIBlock.ChosenMaxFPSValue;
                Application.targetFrameRate = value;
                Debug.Log("Target FrameRate = " + value);
            }
        }
        public void SetGraphicsSettings(PreferencesInSettingsSaver preferencesInSettingsSaver)
        {
            SetQualityLevel(preferencesInSettingsSaver);
            SetVsync(preferencesInSettingsSaver);
            SetMaxFPS(preferencesInSettingsSaver);

            void SetQualityLevel(PreferencesInSettingsSaver preferencesInSettingsSaver)
            {
                int value = preferencesInSettingsSaver.ChosenQualityLevelValue;
                QualitySettings.SetQualityLevel(value);
                Debug.Log($"Graphics quality level set to: {_graphicsPropertiesGetter.CurrentQualityLevel}");
            }
            void SetVsync(PreferencesInSettingsSaver preferencesInSettingsSaver)
            {
                int value = preferencesInSettingsSaver.ChosenVsyncToggleValue;
                QualitySettings.vSyncCount = value;
                Debug.Log($"V-sync count: {_graphicsPropertiesGetter.CurrentVsyncCount}");
            }
            void SetMaxFPS(PreferencesInSettingsSaver preferencesInSettingsSaver)
            {
                int value = preferencesInSettingsSaver.ChosenMaxFPSValue;
                Application.targetFrameRate = value;
                Debug.Log("Target FrameRate = " + value);
            }
        }


        public void SetScreenSettings()
        {
            SetResolution();

            void SetResolution()
            {
                FullScreenMode screenMode;
                RefreshRate refreshRate;
                int resolutionIndex = _screenSettingsUIBlock.ChosenResolutionSimpleIndex;
                ResolutionSimple resolutionSimple = _screenPropertiesGetter.AllResolutionsSimple[resolutionIndex];

                int width = resolutionSimple.Width;
                int height = resolutionSimple.Height;

                screenMode = Utily.GetFullScreenModeByIndex
                    (_screenSettingsUIBlock.ChosenScreenModeIndex);

                if (screenMode != FullScreenMode.ExclusiveFullScreen)
                    refreshRate = _screenPropertiesGetter.AllRefreshRates[^1];
                else
                {
                    int refreshRateIndex = _screenSettingsUIBlock.ChosenRefreshRateIndex;
                    refreshRate = _screenPropertiesGetter.AllRefreshRates[refreshRateIndex];
                }

                Screen.SetResolution(width, height, screenMode, refreshRate);
                Debug.Log($"Screen resolution set to: {width} x {height}, {screenMode}, {refreshRate}Hz");
            }
        }
        public void SetScreenSettings(PreferencesInSettingsSaver preferencesInSettingsSaver)
        {
            SetResolution(preferencesInSettingsSaver);

            void SetResolution(PreferencesInSettingsSaver preferencesInSettingsSaver)
            {
                FullScreenMode screenMode;
                RefreshRate refreshRate;
                int resolutionIndex = preferencesInSettingsSaver.ChosenResolutionSimpleIndex;
                ResolutionSimple resolutionSimple = _screenPropertiesGetter.AllResolutionsSimple[resolutionIndex];

                int width = resolutionSimple.Width;
                int height = resolutionSimple.Height;

                screenMode = Utily.GetFullScreenModeByIndex
                    (preferencesInSettingsSaver.ChosenScreenModeIndex);

                if (screenMode != FullScreenMode.ExclusiveFullScreen)
                    refreshRate = _screenPropertiesGetter.AllRefreshRates[^1];
                else
                {
                    int refreshRateIndex = preferencesInSettingsSaver.ChosenRefreshRateIndex;
                    refreshRate = _screenPropertiesGetter.AllRefreshRates[refreshRateIndex];
                }

                Screen.SetResolution(width, height, screenMode, refreshRate);
                Debug.Log($"Screen resolution set to: {width} x {height}, {screenMode}, {refreshRate}Hz");
            }
        }
    }
}