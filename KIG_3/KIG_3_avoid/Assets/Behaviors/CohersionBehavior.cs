using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

class CohersionBehavior : SteeringBehavior
{
    private List<GameObject> fishList;
    private float activateDistance;
    private Vector3 CenterOfGravity;
    private int activatedFishCount;

    public CohersionBehavior()
    {
        fishList = GameObject.FindGameObjectWithTag("manager").GetComponent<SpawnManager>().allBoids;
        activateDistance = 5.0f;
        activatedFishCount = 0;

    }

    public override void Behave()
    {
        foreach (GameObject go in fishList)
        {
            Vector3 dir = _Kinematic.position - go.GetComponent<BasicBoidBehaviour>().kinematic.position -
                          _Kinematic.position;
            float distance = dir.magnitude;
            if (distance < activateDistance)
            {
                CenterOfGravity += go.GetComponent<BasicBoidBehaviour>().kinematic.position - _Kinematic.position;
                activatedFishCount++;
            }
        }
        if (activatedFishCount > 0)
        {
            CenterOfGravity /= activatedFishCount;
            Vector3 dir = CenterOfGravity - _Kinematic.position;
            float force = _Control.maxStrength * dir.magnitude / activateDistance;
            dir = dir.normalized * force;

            _Control.linear = dir - _Kinematic.speed;
            _Control.linear /= 0.25f;
        }
    }

}
