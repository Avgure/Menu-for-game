using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Menu
{
    public class SettingsUIRefresher : MonoBehaviour
    {
        [SerializeField] private List<SettingsUIBlock> _settingsUIBlocks;

        private void OnEnable()
        {
            StartCoroutine(RefreshSettingsUI());
        }

        public IEnumerator RefreshSettingsUI()
        {
            foreach (SettingsUIBlock block in _settingsUIBlocks)
            {
                yield return null;
                block.RefreshAll();
            }
        }
    }
}