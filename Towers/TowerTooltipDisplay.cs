using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace MarchingMarshmallow.TD.Towers
{
    public class TowerTooltipDisplay : MonoBehaviour, IPointerExitHandler
    {
        [SerializeField] private TowerShop towerShop = null;
        [SerializeField] private GameObject tooltipDisplay = null;
        [SerializeField] private Image towerIconImage = null;
        [SerializeField] private TMP_Text towerNameText = null;
        [SerializeField] private TMP_Text towerPriceText = null;
        [SerializeField] private TMP_Text towerDPSText = null;
        [SerializeField] private TMP_Text towerRangeText = null;

        private Camera mainCamera;

        private TowerHolder towerHolder;

        private void OnEnable() => Tower.OnTowerLeftClickSelected += HandleTowerSelected;

        private void Start() => mainCamera = Camera.main;

        private void OnDisable() => Tower.OnTowerLeftClickSelected -= HandleTowerSelected;

        private void HandleTowerSelected(TowerHolder towerHolder)
        {
            tooltipDisplay.transform.position =
                mainCamera.WorldToScreenPoint(towerHolder.Tower.transform.position);

            towerIconImage.sprite = towerHolder.Tower.TowerData.Icon;
            towerNameText.text = towerHolder.Tower.TowerData.Name;
            towerPriceText.text = $"${(int)(towerHolder.Tower.TowerData.Price * 2 / 3)}";
            towerDPSText.text = $"DPS: {towerHolder.Tower.TowerData.DPS}";
            towerRangeText.text = $"Range: {towerHolder.Tower.TowerData.Range}";

            this.towerHolder = towerHolder;

            tooltipDisplay.SetActive(true);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            tooltipDisplay.SetActive(false);
        }

        public void Sell()
        {
            towerShop.Sell(towerHolder.Tower.TowerData);

            towerHolder.RemoveTower();

            tooltipDisplay.SetActive(false);
        }
    }
}
