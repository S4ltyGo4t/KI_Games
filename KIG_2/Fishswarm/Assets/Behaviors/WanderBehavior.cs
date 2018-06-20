
using UnityEngine;


class WanderBehavior : SteeringBehavior
{
    private float offset;
    private float radius;
    Vector3 positionOnCircle;
    float maxDirectionChange;
    float angleChange;


    public WanderBehavior()
    {
        offset = 2.0f;
        radius = 3.0f;
        maxDirectionChange = 5.0f;
    }

    public override void Behave()
    {
        Vector3 circleCenterPosition = _Kinematic.speed * offset;

        float percent1 = Random.Range(0, 100) / 100.0f;
        float percent2 = Random.Range(0, 100) / 100.0f;
        float percent = 1 - (percent1 + percent2);

        angleChange += percent * maxDirectionChange;

        positionOnCircle = circleCenterPosition + (new Vector3(Mathf.Sin(Mathf.Deg2Rad * angleChange), 0, Mathf.Sin(Mathf.Deg2Rad * angleChange))).normalized * radius;

        _Control.linear = positionOnCircle * _Control.maxStrength;



    }

}

