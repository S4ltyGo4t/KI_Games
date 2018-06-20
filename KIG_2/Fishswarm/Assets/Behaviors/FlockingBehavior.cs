using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

class FlockingBehavior : SteeringBehavior
{
    private SeperationBehavior seperation;
    private CohersionBehavior cohersion;
    private VelocityMatchingBehavior vmBehavior;

    private float sepWeight;
    private float cohWeight;
   

    public FlockingBehavior()
    {
        seperation = new SeperationBehavior();
        cohersion = new CohersionBehavior();
        vmBehavior = new VelocityMatchingBehavior();

        sepWeight = 1.0f;
        cohWeight = 1.0f;
    
    }

    public  void SetWeights(float sep, float coh)
    {
        sepWeight = sep;
        cohWeight = coh;
       
    }

    public override void Behave()
    {
        seperation.setKinematic(_Kinematic);
        cohersion.setKinematic(_Kinematic);
        vmBehavior.setKinematic(_Kinematic);

        seperation.setControl(_Control);
        cohersion.setControl(_Control);
        vmBehavior.setControl(_Control);

        seperation.Move();
        cohersion.Move();
        vmBehavior.Move();

        _Control.linear += seperation.getControl().linear * sepWeight;
        _Control.linear += cohersion.getControl().linear * cohWeight;
        _Control.linear += vmBehavior.getControl().linear;
    }
}
