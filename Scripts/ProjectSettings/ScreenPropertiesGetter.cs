using System.Collections.Generic;
using UnityEngine;

namespace ProjectSettings
{
    public class ScreenPropertiesGetter : MonoBehaviour
    {
        public ResolutionSimple[] AllResolutionsSimple => GetResolutionsSimple();
        public RefreshRate[] AllRefreshRates => GetRefreshRates();
        public ResolutionSimple СurrentResolutionSimple => GetСurrentResolutionSimple();
        public FullScreenMode CurrentScreenMode => Screen.fullScreenMode;
        public RefreshRate CurrentRefreshRate => Screen.currentResolution.refreshRateRatio;
        public int СurrentResolutionSimpleValue => GetСurrentResolutionSimpleIndex();
        public int CurrentRefreshRateValue => GetCurrentRefreshRateIndex();
        private Resolution[] _allResolutions => Screen.resolutions;

        private ResolutionSimple[] GetResolutionsSimple()
        {
            List<ResolutionSimple> resolutionsSimple = new List<ResolutionSimple>();

            foreach (Resolution resolution in _allResolutions)
            {
                int width = resolution.width;
                int height = resolution.height;
                ResolutionSimple addedResolution;
                addedResolution = new ResolutionSimple(width, height);
                bool isNewValue = true;

                foreach (ResolutionSimple resolutionSimple in resolutionsSimple)
                    if (resolutionSimple.Width == width && resolutionSimple.Height == height)
                        isNewValue = false;

                if (isNewValue == true) resolutionsSimple.Add(addedResolution);
            }
            return resolutionsSimple.ToArray();
        }

        private RefreshRate[] GetRefreshRates()
        {
            List<RefreshRate> refreshRates = new List<RefreshRate>();
            bool isNewValue = true;

            foreach (Resolution resolution in _allResolutions)
            {
                RefreshRate addedRefreshRate;
                addedRefreshRate = resolution.refreshRateRatio;

                foreach (RefreshRate refreshRate in refreshRates)
                    if (refreshRate.value == resolution.refreshRateRatio.value)
                        isNewValue = false;

                if (isNewValue == false) break;
                else refreshRates.Add(addedRefreshRate);
            }
            return refreshRates.ToArray();
        }

        private ResolutionSimple GetСurrentResolutionSimple()
        {
            int width = Screen.width;
            int height = Screen.height;
            ResolutionSimple resolutionSimple = new ResolutionSimple(width, height);
            return resolutionSimple;
        }

        private int GetСurrentResolutionSimpleIndex()
        {
            int index = new int();
            for (int i = 0; i < AllResolutionsSimple.Length; i++)
            {
                int width = AllResolutionsSimple[i].Width;
                int height = AllResolutionsSimple[i].Height;
                ResolutionSimple resolution = СurrentResolutionSimple;

                if (resolution.Width == width && resolution.Height == height)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }

        private int GetCurrentRefreshRateIndex()
        {
            int index = new int();
            for (int i = 0; i < AllRefreshRates.Length; i++)
            {
                RefreshRate refreshRate = CurrentRefreshRate;

                if (refreshRate.value == AllRefreshRates[i].value)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }
    }
}