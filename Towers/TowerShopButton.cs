using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace MarchingMarshmallow.TD.Towers
{
    public class TowerShopButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] private TMP_Text priceText = null;
        [SerializeField] private Image towerIconImage = null;


        private TowerPreview previewInstance;
        private Camera mainCamera;
        private TowerData towerData;
        private TowerShop towerShop;

        private void Start() => mainCamera = Camera.main;

        public void Initialise(TowerData towerData, TowerShop towerShop)
        {
            priceText.text = $"${towerData.Price}";

            towerIconImage.sprite = towerData.Icon;

            this.towerData = towerData;
            this.towerShop = towerShop;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (towerShop.Resources < towerData.Price) { return;  }
            previewInstance = Instantiate(towerData.PreviewPrefab);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (previewInstance == null) { return; }

            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.TryGetComponent<TowerHolder>(out var towerHolder))
                {
                    if (towerHolder.Tower == null)
                    {
                        towerHolder.SetTower(towerData);

                        towerShop.SpendResources(towerData.Price);
                    }
                }
            }

            Destroy(previewInstance.gameObject);
        }
    }
}
