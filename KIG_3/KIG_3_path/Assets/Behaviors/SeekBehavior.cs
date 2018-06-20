using System;
using System.Collections.Generic;
using UnityEngine;

class SeekBehavior : SteeringBehavior
{
    private Vector3 targetPos;
    public SeekBehavior(Vector3 pos )
    {
        targetPos = pos;
    }

    public override void Behave()
    {
        //Dynamic
        //_Control.linear = targetPos - _Kinematic.position;
        //_Control.linear = _Control.linear.normalized * _Control.maxStrength;
        //_Control.angular = 0;

        //Kinematic
        _Control.linear = new Vector3(0,0,0);
        _Control.angular = 0;

        _Kinematic.speed = targetPos - _Kinematic.position;
        _Kinematic.speed = _Kinematic.speed.normalized * _Kinematic.maxSpeed;
    }
}
