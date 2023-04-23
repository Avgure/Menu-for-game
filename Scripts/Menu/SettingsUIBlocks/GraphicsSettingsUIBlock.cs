using Menu;
using ProjectSettings;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Menu
{
    public class GraphicsSettingsUIBlock : SettingsUIBlock, IGraphicsSettingsCarrier
    {
        public int ChosenQualityLevelValue => _qualityLevelsDropdown.value;
        public int ChosenVsyncToggleValue => Convert.ToInt32(_vsyncToggle.isOn);
        public int ChosenMaxFPSValue => _maxFPSSliderUI.ChosenMaxFPS;

        [SerializeField] private TMP_Dropdown _qualityLevelsDropdown;
        [SerializeField] private Toggle _vsyncToggle;
        [SerializeField] private MaxFPSSliderUI _maxFPSSliderUI;

        [SerializeField] private GraphicsPropertiesGetter _graphicsProperties;

        public override void RefreshAll()
        {
            RefreshVsyncToggle();
            RefreshMaxFPSSlider();
            FillQualityLevelsDropdown();
        }

        public void RefreshVsyncToggle()
        {
            _vsyncToggle.isOn = _graphicsProperties.CurrentVsyncCount == 1;
        }

        public void RefreshMaxFPSSlider()
        {
            _maxFPSSliderUI.MaxFPSSlider.value = _graphicsProperties.CurrentMaxFPSValue;
            SetInteractivityForMaxFPSSlider();
        }

        public void FillQualityLevelsDropdown()
        {
            _qualityLevelsDropdown.options.Clear();
            for (int i = 0; i < Utily.GraphicsQualityLevels.Length; i++)
            {
                TMP_Dropdown.OptionData qualityLevel = new TMP_Dropdown.OptionData();
                qualityLevel.text = Utily.GraphicsQualityLevels[i];

                _qualityLevelsDropdown.options.Add(qualityLevel);
            }
            _qualityLevelsDropdown.value = _graphicsProperties.CurrentQualityLevel;
            _qualityLevelsDropdown.RefreshShownValue();
        }

        private void OnEnable()
        {
            SetInteractivityForMaxFPSSlider();
            _vsyncToggle.onValueChanged.AddListener
                (delegate { SetInteractivityForMaxFPSSlider(); });
        }

        private void OnDisable()
        {
            _vsyncToggle.onValueChanged.RemoveAllListeners();
        }

        private void SetInteractivityForMaxFPSSlider()
        {
            if (_vsyncToggle.isOn)
            {
                _maxFPSSliderUI.MaxFPSSlider.interactable = false;
                _maxFPSSliderUI.SetNonInteractiveColor();
            }
            else
            {
                _maxFPSSliderUI.MaxFPSSlider.interactable = true;
                _maxFPSSliderUI.SetInteractiveColor();
            }
        }
    }
}