using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBoidBehaviour : MonoBehaviour
{

    public  Kinematic kinematic;
    public Control control;
    private SteeringBehavior behavior;
    //private FlockingBehavior flockBehaviour;
    private SteeringBehavior collisionAvoidance;
    
    public float energy;

 
    //private GameObject foodTarget;
    
    public struct Kinematic
    {
        public Vector3 position;
        public Vector3 speed;
        public float direction;
        public float rotation;
        public float maxSpeed;
    }

    public struct Control
    {
        public Vector3 linear;
        public float angular;
        public float maxStrength;
    }

    private void Start()
    {
        kinematic.position = transform.position;
        kinematic.speed = new Vector3(Random.Range(0, 5), 0, Random.Range(0, 5));
        kinematic.maxSpeed = 2.0f;
        control.maxStrength = 2.0f;
        energy = 89;

        behavior = new WanderBehavior();
        collisionAvoidance = new CollisionAvoidanceBehavior();
    }

    private void Update()
    {
        behavior.setControl(control);
        behavior.setKinematic(kinematic);
        behavior.Move();

        collisionAvoidance.setControl(control);
        collisionAvoidance.setKinematic(kinematic);
        collisionAvoidance.Move();

        control = behavior.getControl();
        kinematic = behavior.getKinematic();

        control = collisionAvoidance.getControl();
        //kinematic = collisionAvoidance.getKinematic();

        transform.position = kinematic.position;
    }
}
