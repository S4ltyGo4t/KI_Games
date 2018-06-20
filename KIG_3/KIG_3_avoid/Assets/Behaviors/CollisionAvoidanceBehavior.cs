using UnityEngine;
using System.Collections.Generic;

class CollisionAvoidanceBehavior : SteeringBehavior
{
    private float maxSeeAhead;
    private float maxAvoidanceForce;
    private Vector3 ahead;
    private Vector3 ahead2;
    private List<GameObject> obstacles;
    
    public CollisionAvoidanceBehavior()
    {
        maxSeeAhead = 1;
        maxAvoidanceForce =  20.0f;
        //obstacles = GameObject.FindGameObjectWithTag("manager").GetComponent<SpawnManager>().allObstacles;
        obstacles = GameObject.FindGameObjectWithTag("manager").GetComponent<SpawnManager>().allBoids;
    }


    public override void Behave()
    {
        ahead = _Kinematic.position + _Kinematic.speed.normalized * maxSeeAhead;
        ahead2 = ahead *0.5f;

        GameObject mostThreat = findMostThreateningObstacle();
        Vector3 avoidance = new Vector3();

        if (mostThreat != null)
        {
            avoidance.x = ahead.x - mostThreat.transform.position.x;
            avoidance.z = ahead.z - mostThreat.transform.position.z;

            avoidance.Normalize();
            avoidance *= maxAvoidanceForce;
        }
        else
        {
            avoidance *= 0;
        }
        _Control.linear = avoidance;
    }

    private float distance(Vector3 a, Vector3 b)
    {
        return Mathf.Sqrt((a.x - b.x) * (a.x - b.x) + (a.z - b.z) * (a.z - b.z));
    }

    private bool lineIntersectsCircle(Vector3 _ahead, Vector3 _ahead2, GameObject _obstacle)
    {
        float radius = _obstacle.transform.localScale.x;
        return distance(_obstacle.transform.position, _ahead) <= radius ||
               distance(_obstacle.transform.position, _ahead2) <= radius;
    }

    private GameObject findMostThreateningObstacle()
    {
        GameObject ret = null;
        foreach (GameObject go in obstacles)
        {
            bool collision = lineIntersectsCircle(ahead, ahead2, go);
            if (collision && (ret == null || 
                distance(_Kinematic.position, go.transform.position) < distance(_Kinematic.position, ret.transform.position)) && distance(_Kinematic.position, go.transform.position) >= 0.1f)
            {
                ret = go;
            }
        }
        return ret;
    }

}
