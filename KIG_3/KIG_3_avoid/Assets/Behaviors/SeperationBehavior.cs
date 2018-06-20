using System;
using System.Collections.Generic;
using UnityEngine;

class SeperationBehavior : SteeringBehavior
{
    private List<GameObject> fishList;
    private float distanz;
    private float FOV;

    public SeperationBehavior()
    {
        fishList = GameObject.FindGameObjectWithTag("manager").GetComponent<SpawnManager>().allBoids;
        distanz = 2.0f;
        FOV = Mathf.Deg2Rad * 360;

    }

    public override void Behave()
    {
        if (fishList.Count != 0)
        {
            foreach (GameObject go in fishList)
            {
                Vector3 me2target = go.GetComponent<BasicBoidBehaviour>().kinematic.position - _Kinematic.position;
                Vector3 target2me = _Kinematic.position - go.GetComponent<BasicBoidBehaviour>().kinematic.position;
                float _distanz = me2target.magnitude;
                if (_distanz < distanz)
                {
                    float force = _Control.maxStrength * (distanz - _distanz) / distanz;
                    _Control.linear += target2me.normalized * force;
                }
            }
        }
    }
}
