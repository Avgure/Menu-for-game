using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace Menu
{
    public class MaxFPSSliderUI : MonoBehaviour
    {
        public Slider MaxFPSSlider;
        public int ChosenMaxFPS =>
            Convert.ToInt32(MaxFPSSlider.value);

        [SerializeField] private TextMeshProUGUI _valuerText;
        [SerializeField] private Image _backgroundImage;
        [SerializeField] private Image _fillAreaImage;
        [SerializeField] private float _alphaComponentOnTransparency = 0.4f;

        private Color _backgroundImageDefaultColor;
        private Color _fillAreaImageDefaultColor;
        private Color _valuerTextDefaultColor;

        public void SetNonInteractiveColor()
        {
            if (_backgroundImageDefaultColor == Color.clear ||
                _fillAreaImageDefaultColor == Color.clear)
            {
                GetDefaultColors();
            }
            _backgroundImage.color = GetTransparentColor
                (_backgroundImage.color, _backgroundImageDefaultColor);
            _fillAreaImage.color = GetTransparentColor
                (_fillAreaImage.color, _fillAreaImageDefaultColor);
            _valuerText.color = GetTransparentColor
                (_valuerText.color, _valuerTextDefaultColor);
        }

        public void SetInteractiveColor()
        {
            if (_backgroundImageDefaultColor == Color.clear ||
                _fillAreaImageDefaultColor == Color.clear)
            {
                GetDefaultColors();
            }
            _backgroundImage.color = _backgroundImageDefaultColor;
            _fillAreaImage.color = _fillAreaImageDefaultColor;
            _valuerText.color = _valuerTextDefaultColor;
        }

        private Color GetTransparentColor(Color color, Color defaultColor)
        {
            return color = new Color(
                 defaultColor.r,
                 defaultColor.g,
                 defaultColor.b,
                 _alphaComponentOnTransparency);
        }

        private void GetDefaultColors()
        {
            _backgroundImageDefaultColor = _backgroundImage.color;
            _fillAreaImageDefaultColor = _fillAreaImage.color;
            _valuerTextDefaultColor = _valuerText.color;
        }

        private void OnEnable()
        {
            SetValuerText();
            MaxFPSSlider.onValueChanged.AddListener(delegate { SetValuerText(); });
        }

        private void OnDisable()
        {
            MaxFPSSlider.onValueChanged.RemoveAllListeners();
        }

        private void SetValuerText()
        {
            _valuerText.text = MaxFPSSlider.value.ToString();
        }
    }
}