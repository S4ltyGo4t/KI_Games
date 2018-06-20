using System;
using System.Collections.Generic;
using UnityEngine;

class VelocityMatchingBehavior : SteeringBehavior
{
    private List<GameObject> fishList;
    private float distanz;

    public VelocityMatchingBehavior()
    {
        fishList = GameObject.FindGameObjectWithTag("manager").GetComponent<SpawnManager>().allBoids;
        distanz = 2.0f;
    }

    public override void Behave()
    {
        Vector3 avgSpeed = new Vector3();
        foreach (GameObject go in fishList)
        {
            Vector3 dir = go.GetComponent<BasicBoidBehaviour>().kinematic.position - _Kinematic.position;
            if (dir.magnitude < distanz)
            {
                avgSpeed += go.GetComponent<BasicBoidBehaviour>().kinematic.speed;
            }
        }
        _Control.linear = avgSpeed;
    }
}

