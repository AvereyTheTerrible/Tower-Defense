using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MarchingMarshmallow.TD.Enemies
{
    [CreateAssetMenu(fileName = "New Enemy Data", menuName = "Enemies/EnemyData")]
    public class EnemyData : ScriptableObject
    {
        [SerializeField] private int damage = 1;
        [SerializeField] private int health = 50;
        [SerializeField] private int resourceValue = 25;
        [SerializeField] private float movementSpeed = 5f;

        public int Damage => damage;
        public int Health => health;
        public int ResourceValue => resourceValue;
        public float MovementSpeed => movementSpeed;
    }
}

