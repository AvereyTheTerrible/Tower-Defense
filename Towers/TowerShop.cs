
using MarchingMarshmallow.TD.Enemies;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MarchingMarshmallow.TD.Towers
{
    public class TowerShop : MonoBehaviour
    {
        [SerializeField] private int resources;
        [SerializeField] private Transform buttonHolder = null;
        [SerializeField] private TowerShopButton towerShopButton = null;
        [SerializeField] private TowerData[] towerDatas = new TowerData[0];

        public event Action<int> OnResourcesChanged;

        public int Resources => resources;

        private void OnEnable()
        {
            Enemy.OnKilled += HandleEnemyKilled;
        }

        private void OnDisable()
        {
            Enemy.OnKilled -= HandleEnemyKilled;
        }

        private void Start()
        {
            foreach (var towerData in towerDatas)
            {
                TowerShopButton towerShopButtonInstance = Instantiate(towerShopButton, buttonHolder);

                towerShopButtonInstance.Initialise(towerData, this);
            }
        }
        
        private void HandleEnemyKilled(EnemyData enemyData)
        {
            resources += enemyData.ResourceValue;

            OnResourcesChanged?.Invoke(resources);
        }

        public void SpendResources(int amountToSpend)
        {
            resources -= amountToSpend;

            OnResourcesChanged?.Invoke(resources);
        }

        public void Sell(TowerData towerData)
        {
            resources += (int)(towerData.Price * 2 / 3);

            OnResourcesChanged?.Invoke(resources);
        }
    }
}

