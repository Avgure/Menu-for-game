using ProjectSettings;
using System;
using TMPro;
using UnityEngine;

namespace Menu
{
    public class ScreenSettingsUIBlock : SettingsUIBlock, IScreenSettingsCarrier
    {
        public int ChosenResolutionSimpleIndex => _resolutionsDropdown.value;
        public int ChosenScreenModeIndex => GetScreenMode();
        public int ChosenRefreshRateIndex => _refreshRatesDropdown.value;

        [SerializeField] private TMP_Dropdown _screenModesDropdown;
        [SerializeField] private TMP_Dropdown _resolutionsDropdown;
        [SerializeField] private TMP_Dropdown _refreshRatesDropdown;

        [SerializeField] private ScreenPropertiesGetter _screenProperties;

        public override void RefreshAll()
        {
            RefreshScreenModesDropdown();
            RefreshResolutionsDropdown();
            RefreshRefreshRatesDropdown();
        }

        public void RefreshScreenModesDropdown()
        {
            _screenModesDropdown.options.Clear();
            AddScreenMode(FullScreenMode.ExclusiveFullScreen);
            AddScreenMode(FullScreenMode.FullScreenWindow);
            AddScreenMode(FullScreenMode.Windowed);

            _screenModesDropdown.value = GetScreenModesDropdownValue();
            _screenModesDropdown.RefreshShownValue();

            void AddScreenMode(FullScreenMode screenMode)
            {
                TMP_Dropdown.OptionData screenModeOption = new TMP_Dropdown.OptionData();
                screenModeOption.text = screenMode.ToString();
                _screenModesDropdown.options.Add(screenModeOption);
            }

            int GetScreenModesDropdownValue()
            {
                FullScreenMode currentScreenMode = _screenProperties.CurrentScreenMode;
                int value = new int();
                for (int i = 0; i < _screenModesDropdown.options.Count; i++)
                {
                    string nameOfScreenMode = _screenModesDropdown.options[i].text;

                    if (currentScreenMode.ToString() == nameOfScreenMode)
                    {
                        value = i;
                        break;
                    }
                }
                return value;
            }
        }

        public void RefreshResolutionsDropdown()
        {
            _resolutionsDropdown.options.Clear();

            foreach (ResolutionSimple resolution in _screenProperties.AllResolutionsSimple)
            {
                int Width = resolution.Width;
                int Height = resolution.Height;
                TMP_Dropdown.OptionData optionData = new TMP_Dropdown.OptionData();
                optionData.text = $"{Width} x {Height}";
                _resolutionsDropdown.options.Add(optionData);
            }
            _resolutionsDropdown.value = _screenProperties.СurrentResolutionSimpleValue;
            _refreshRatesDropdown.RefreshShownValue();
        }

        public void RefreshRefreshRatesDropdown()
        {
            _refreshRatesDropdown.options.Clear();
            foreach (RefreshRate refreshRate in _screenProperties.AllRefreshRates)
            {
                float roundedRefreshRate = Convert.ToSingle(Math.Round(refreshRate.value, 3));
                TMP_Dropdown.OptionData optionData = new TMP_Dropdown.OptionData();
                optionData.text = roundedRefreshRate.ToString();
                _refreshRatesDropdown.options.Add(optionData);
            }
            _refreshRatesDropdown.value = _screenProperties.CurrentRefreshRateValue;
            _refreshRatesDropdown.RefreshShownValue();
            SetInteractivityForRefreshRatesDropdown();
        }

        private void OnEnable()
        {
            _screenModesDropdown.onValueChanged.AddListener
                (delegate { SetInteractivityForRefreshRatesDropdown(); });
        }

        private void OnDisable()
        {
            _screenModesDropdown.onValueChanged.RemoveAllListeners();
        }

        private void SetInteractivityForRefreshRatesDropdown()
        {
            FullScreenMode chosenScreenMode = Utily.GetFullScreenModeByIndex(ChosenScreenModeIndex);
            if (chosenScreenMode == FullScreenMode.ExclusiveFullScreen)
                _refreshRatesDropdown.interactable = true;
            else
            {
                _refreshRatesDropdown.interactable = false;
                int currentValue = _screenProperties.CurrentRefreshRateValue;
                _refreshRatesDropdown.value = currentValue;
            }
        }

        private int GetScreenMode()
        {
            if (CompareScreenModeWithEnum(FullScreenMode.ExclusiveFullScreen))
                return Convert.ToInt32(FullScreenMode.ExclusiveFullScreen);

            else if (CompareScreenModeWithEnum(FullScreenMode.FullScreenWindow))
                return Convert.ToInt32(FullScreenMode.FullScreenWindow);

            else return Convert.ToInt32(FullScreenMode.Windowed);

            bool CompareScreenModeWithEnum(FullScreenMode screenMode)
            {
                int value = _screenModesDropdown.value;
                return _screenModesDropdown.options[value].text == screenMode.ToString();
            }
        }
    }
}