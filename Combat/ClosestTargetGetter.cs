using MarchingMarshmallow.TD.Enemies;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MarchingMarshmallow.TD.Towers
{
    public class ClosestTargetGetter : Targeter
    {
        protected override void FindTarget()
        {
            int colliderCount = 
                Physics.OverlapSphereNonAlloc(
                    transform.position,
                    towerData.Range,
                    colliderBuffer,
                    layerMask);
            Enemy closestEnemy = null;
            float closestDistance = Mathf.Infinity;

            for (int i = 0; i < colliderCount; i++)
            {
                float distanceSquared = (colliderBuffer[i].transform.position - transform.position).sqrMagnitude;

                if (distanceSquared < closestDistance * closestDistance)
                {
                    if (colliderBuffer[i].TryGetComponent<Enemy>(out var enemy))
                    {
                        closestDistance = distanceSquared;
                        closestEnemy = enemy;
                    }
                }
            }

            Target = closestEnemy;
        }
    }
}