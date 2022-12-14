using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MarchingMarshmallow.TD.Combat
{
    public class DestroyAfterDuration : MonoBehaviour
    {
        [SerializeField] private float duration = 10f;

        private void Start() => Destroy(gameObject, duration);
    }
}


