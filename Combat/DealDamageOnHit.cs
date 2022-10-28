using MarchingMarshmallow.TD.Enemies;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MarchingMarshmallow.TD.Combat
{
    public class DealDamageOnHit : MonoBehaviour
    {
        [SerializeField] private int damage = 1;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent<Enemy>(out var enemy)) { return; }

            enemy.DealDamage(damage);
        }
    }
}

