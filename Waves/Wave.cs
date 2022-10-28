using MarchingMarshmallow.TD.Enemies;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MarchingMarshmallow.TD.Waves
{
    [Serializable]
    public class Wave
    {
        [SerializeField] private Enemy[] enemies = new Enemy[0];

        public Enemy[] Enemies => enemies;
    }

}
