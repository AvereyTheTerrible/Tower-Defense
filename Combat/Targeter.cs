using MarchingMarshmallow.TD.Enemies;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MarchingMarshmallow.TD.Towers
{
    public abstract class Targeter : MonoBehaviour
    {
        [SerializeField] protected TowerData towerData = null;
        [SerializeField] private float checkRate = 0.5f;
        [SerializeField] protected LayerMask layerMask = new LayerMask();

        private float timer;

        protected readonly Collider[] colliderBuffer = new Collider[50];

        public Enemy Target { get; protected set; }

        private void Update()
        {
            timer -= Time.deltaTime;

            if (timer <= 0f)
            {
                timer = checkRate;

                FindTarget();
            }

            if (Target == null) { return; }

            transform.LookAt(Target.transform);
        }

        protected abstract void FindTarget();
    }
}


