using MarchingMarshmallow.TD.Enemies;
using MarchingMarshmallow.TD.Towers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MarchingMarshmallow.TD.Combat
{
    public class LaserAttack : MonoBehaviour
    {
        [SerializeField] private float fireRate = 0.5f;
        [SerializeField] private TowerData towerData = null;
        [SerializeField] private Transform spawnPoint = null;
        [SerializeField] private LineRenderer lineRenderer = null;

        private float timer;

        private Targeter targeter;

        private void Start() => targeter = GetComponent<Targeter>();

        private void Update()
        {
            Enemy target = targeter.Target;

            if (target != null)
            {
                lineRenderer.positionCount = 2;

                lineRenderer.SetPositions(new Vector3[]
                {
                    spawnPoint.position,
                    target.transform.position
                });
            }


            else
            {
                lineRenderer.positionCount = 0;
            }

            timer -= Time.deltaTime;

            if (timer > 0f) { return; }

            timer = fireRate;

            if (target != null)
            {
                target.DealDamage(Mathf.CeilToInt(towerData.DPS * fireRate));
            }
        }
    }
}