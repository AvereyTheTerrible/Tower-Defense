using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MarchingMarshmallow.TD.Towers
{
    public class Tower : MonoBehaviour
    {
        [SerializeField] private TowerData towerData = null;
        [SerializeField] private GameObject rangeVisualizer = null;

        public static event Action<TowerHolder> OnTowerLeftClickSelected;

        private TowerHolder towerHolder;

        public TowerData TowerData => towerData;

        public void Initialise(TowerHolder towerHolder)
        {
            this.towerHolder = towerHolder;
        }


        private void OnMouseDown()
        {
            OnTowerLeftClickSelected?.Invoke(towerHolder);
        }
    }
}