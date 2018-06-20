 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityMatching : MonoBehaviour
{

    public List<GameObject> allBoids ,swarmBoids;
    private GameObject bossBoid;
    public Vector3 flockingSpeed;
    [SerializeField] private float range;

	// Use this for initialization
	void Start ()
	{
	    range = 3.0f;

	    allBoids = gameObject.GetComponent<CreateBoids>().redBoids;
        //set all boids to green + redBoids
	    foreach (GameObject go in gameObject.GetComponent<CreateBoids>().greenBoids)
	    {
	        allBoids.Add(go);
	    }

	    foreach (GameObject go in allBoids)
	    {
	        Debug.Log("Added Boid Number : " +allBoids.IndexOf(go) + " with name : " + go.name);
        }
	    bossBoid = allBoids[0].gameObject;
	    bossBoid.GetComponentInChildren<MeshRenderer>().material.color = Color.yellow;
	}
	
	// Update is called once per frame
	void Update ()
	{
        foreach (GameObject go in allBoids)
        {
            if (CheckInRange(bossBoid, go, range) && gameObject.GetComponent<CreateBoids>().currentBehavior == "d_flocking")
            {
                Debug.Log("In Range : " + bossBoid.name + " & " + go.name);
                if (!swarmBoids.Contains(go))
                {
                swarmBoids.Add(go);
                }
            }
        }

        //calulate the new direction by adding all direction together
        foreach (GameObject go in swarmBoids)
        {
            flockingSpeed += go.GetComponent<Move>()._kinematic.speed;
        }
        //change direction of the swarm
        foreach (GameObject go in swarmBoids)
        {
            go.GetComponent<Move>()._control.linear = flockingSpeed;
        }
	}

    private bool CheckInRange(GameObject target, GameObject other, float range)
    {
        if (target.gameObject != other.gameObject)
        {
            Vector3 distance = target.transform.position - other.transform.position;
            if (distance.magnitude <= range)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
}
