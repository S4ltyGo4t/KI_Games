using UnityEngine;

class ArriveBehavior : SteeringBehavior
{
    private float timeToEnd;
    private float breakRadius;
    private GameObject target;
    public ArriveBehavior()
    {
        breakRadius = 5.0f;
        timeToEnd = 5.0f;
        target = GameObject.FindGameObjectWithTag("target");
    }

    public override void Behave()
    {
        float targetSpeed;
        timeToEnd = 0.5f;
        
        Vector3 direction = target.transform.position - _Kinematic.position;

        if (direction.magnitude > breakRadius)
        {
            targetSpeed = _Kinematic.maxSpeed;
        }
        else
        {
            targetSpeed = _Kinematic.maxSpeed * direction.magnitude / breakRadius;
        }
        direction = direction.normalized * targetSpeed;

        _Control.linear = direction - _Kinematic.speed;
        _Control.linear /= timeToEnd;

        _Control.angular = 0;
    }
}
