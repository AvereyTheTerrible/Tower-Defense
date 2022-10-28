using MarchingMarshmallow.TD.Waves;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MarchingMarshmallow.TD.Combat
{
    public class HealthSystem : MonoBehaviour
    {
        [SerializeField] private int health = 100;

        public event Action<int> OnHealthChanged;
        public static Action OnPlayerLose;

        public int Health => health;

        private void OnEnable() => WaveDestination.OnEnemyReachedEnd += HandleEnemyReachedEnd;

        private void OnDisable() => WaveDestination.OnEnemyReachedEnd -= HandleEnemyReachedEnd;

        private void HandleEnemyReachedEnd(MarchingMarshmallow.TD.Enemies.EnemyData enemyData)
        {
            health = Mathf.Max(health - enemyData.Damage);

            OnHealthChanged?.Invoke(health);

            if (health != 0) { return; }

            OnPlayerLose?.Invoke();
        }
    }
}