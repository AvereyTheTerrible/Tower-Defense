using MarchingMarshmallow.TD.Enemies;
using MarchingMarshmallow.TD.Towers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MarchingMarshmallow.TD.Combat
{
    public class ProjectileAttack : MonoBehaviour
    {
        [SerializeField] private float fireRate = 0.5f;
        [SerializeField] private Transform spawnPoint = null;
        [SerializeField] private Rigidbody projectilePrefab = null;
        [SerializeField] private float launchForce = 5f;

        private float timer;

        private Targeter targeter;

        private void Start() => targeter = GetComponent<Targeter>();

        private void Update()
        {
            timer -= Time.deltaTime;

            if (timer > 0f) { return; }

            timer = fireRate;

            Enemy target = targeter.Target;

            if (target == null) { return; }

            Rigidbody projectileInstance = Instantiate(projectilePrefab, spawnPoint.position, spawnPoint.rotation);

            projectileInstance.AddForce(spawnPoint.forward * launchForce, ForceMode.VelocityChange);
        }
    }
}


