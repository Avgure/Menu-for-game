using Menu;
using UnityEngine;

namespace ProjectSettings
{
    public class PreferencesInSettingsSaver : MonoBehaviour, IScreenSettingsCarrier, IGraphicsSettingsCarrier
    {
        /// <summary>
        /// ScreenSettings
        /// </summary>
        public int ChosenScreenModeIndex =>
            PlayerPrefs.GetInt
                  (Utily.PreferencesInSettings.ChosenScreenModeIndex.ToString());
        public int ChosenResolutionSimpleIndex =>
            PlayerPrefs.GetInt
                  (Utily.PreferencesInSettings.ChosenResolutionSimpleIndex.ToString());
        public int ChosenRefreshRateIndex =>
            PlayerPrefs.GetInt
                  (Utily.PreferencesInSettings.ChosenRefreshRateIndex.ToString());

        /// <summary>
        /// GraphicsSettings
        /// </summary>
        public int ChosenVsyncToggleValue =>
            PlayerPrefs.GetInt
                 (Utily.PreferencesInSettings.ChosenVsyncToggleValue.ToString());
        public int ChosenMaxFPSValue =>
            PlayerPrefs.GetInt
                 (Utily.PreferencesInSettings.ChosenMaxFPSValue.ToString());
        public int ChosenQualityLevelValue =>
            PlayerPrefs.GetInt
                (Utily.PreferencesInSettings.ChosenQualityLevelValue.ToString());

        [SerializeField] private GraphicsSettingsUIBlock _graphicsSettingsUI;
        [SerializeField] private ScreenSettingsUIBlock _screenSettingsUI;

        [SerializeField] private ProjectSettingsChanger _projectSettingsChanger;

        public void SaveAllPreferences()
        {
            if (_screenSettingsUI != null)
                SaveScreenSettings(_screenSettingsUI);

            if (_graphicsSettingsUI != null)
                SaveGraphicsSettings(_graphicsSettingsUI);

            PlayerPrefs.Save();
            Debug.Log("Preferences Saved!");
        }

        private void SaveScreenSettings(ScreenSettingsUIBlock screenSettingsUI)
        {
            int value;


            value = screenSettingsUI.ChosenResolutionSimpleIndex;
            SetIntPlayerPreference
                (Utily.PreferencesInSettings.ChosenResolutionSimpleIndex, value);


            value = screenSettingsUI.ChosenScreenModeIndex;
            SetIntPlayerPreference
                (Utily.PreferencesInSettings.ChosenScreenModeIndex, value);


            value = screenSettingsUI.ChosenRefreshRateIndex;
            SetIntPlayerPreference
                (Utily.PreferencesInSettings.ChosenRefreshRateIndex, value);
        }

        private void SaveGraphicsSettings(GraphicsSettingsUIBlock graphicsSettingsUI)
        {
            int value;


            value = graphicsSettingsUI.ChosenVsyncToggleValue;
            SetIntPlayerPreference
                (Utily.PreferencesInSettings.ChosenVsyncToggleValue, value);


            value = graphicsSettingsUI.ChosenQualityLevelValue;
            SetIntPlayerPreference
                (Utily.PreferencesInSettings.ChosenQualityLevelValue, value);

            value = graphicsSettingsUI.ChosenMaxFPSValue;
            SetIntPlayerPreference
                (Utily.PreferencesInSettings.ChosenMaxFPSValue, value);
        }

        private void Awake()
        {
            if (PlayerPrefs.HasKey(Utily.PreferencesInSettings.ChosenScreenModeIndex.ToString()))
                LoadPreferencesInSettings();
        }

        private void LoadPreferencesInSettings()
        {
            _projectSettingsChanger.SetAllSettings(this);
        }


        private void SetIntPlayerPreference(Utily.PreferencesInSettings name, int value)
        {
            string nameString = name.ToString();
            PlayerPrefs.SetInt(nameString, value);
        }
    }
}