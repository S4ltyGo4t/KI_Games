using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBoidBehaviour : MonoBehaviour
{

    public  Kinematic kinematic;
    public Control control;
    private SteeringBehavior behavior;
    private FlockingBehavior flockBehaviour;
    
    public float energy;

 
    private GameObject foodTarget;
    
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

        flockBehaviour = new FlockingBehavior();

        behavior = flockBehaviour;
        foodTarget = GameObject.FindGameObjectWithTag("target");
    }

    private void Update()
    {
        behavior.setControl(control);
        behavior.setKinematic(kinematic);
        behavior.Move();
        control = behavior.getControl();
        kinematic = behavior.getKinematic();

        transform.position = kinematic.position;
        FishSimulation();
    }


    public  void FishSimulation()
    {
        if (energy > 0 )
            energy -= 0.09f;

        if (kinematic.maxSpeed >= 1.5f)
            kinematic.maxSpeed -= 0.01f;
        

        Debug.Log("Energie"+energy);
        

        if (energy > 25 && energy < 40)
        {
            flockBehaviour.SetWeights(0.4f, 0f);

        }

        else

            if (energy < 15)
        {
            if (!(behavior is ArriveBehavior))
                behavior = new ArriveBehavior();
            while ((kinematic.position - foodTarget.transform.position).magnitude <= 0.5f && energy <= 100)
            {
                energy += 0.5f;
                if (kinematic.maxSpeed < 2.0f)
                    kinematic.maxSpeed += 0.5f;

            }

        }

        else

            if (energy > 90)
        {
            if (!(behavior is WanderBehavior))
            {
                behavior = new WanderBehavior();
             
            }
                
        }

        else 
           if(energy <= 90)
           {
            if (!(behavior is FlockingBehavior))
            {
                flockBehaviour.SetWeights(1, 1);
                behavior = flockBehaviour;
            }
            
           }
    }

}
