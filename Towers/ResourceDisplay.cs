using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace MarchingMarshmallow.TD.Towers
{
    public class ResourceDisplay : MonoBehaviour
    {
        [SerializeField] private TowerShop towerShop = null;
        [SerializeField] private TMP_Text resourceText = null;

        private void OnEnable()
        {
            HandleResourceChanged(towerShop.Resources);

            towerShop.OnResourcesChanged += HandleResourceChanged;
        }

        private void OnDisable() => towerShop.OnResourcesChanged -= HandleResourceChanged;

        private void HandleResourceChanged(int resource) => resourceText.text = $"${resource}";
    }

}
