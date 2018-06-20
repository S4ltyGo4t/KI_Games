using UnityEngine;

public class BounceEdge : MonoBehaviour
{
    private GameObject ground;
	// Use this for initialization
	void Start ()
	{
	    ground = GameObject.FindGameObjectWithTag("ground");

    }

    public void bounce()
    {
        Vector3 size = ground.GetComponent<Renderer>().bounds.size;

        if (GetComponent<BasicBoidBehaviour>().kinematic.position.x > size.x / 2)
        {
            GetComponent<BasicBoidBehaviour>().kinematic.position.x = size.x / 2;
            GetComponent<BasicBoidBehaviour>().kinematic.speed.x = -GetComponent<BasicBoidBehaviour>().kinematic.speed.x;
        }

        if (GetComponent<BasicBoidBehaviour>().kinematic.position.x < -(size.x / 2))
        {
            GetComponent<BasicBoidBehaviour>().kinematic.position.x = -(size.x / 2);
            GetComponent<BasicBoidBehaviour>().kinematic.speed.x = -GetComponent<BasicBoidBehaviour>().kinematic.speed.x;
        }

        if (GetComponent<BasicBoidBehaviour>().kinematic.position.z > size.z / 2)
        {
            GetComponent<BasicBoidBehaviour>().kinematic.position.z = size.z / 2;
            GetComponent<BasicBoidBehaviour>().kinematic.speed.z = -GetComponent<BasicBoidBehaviour>().kinematic.speed.z;
        }

        if (GetComponent<BasicBoidBehaviour>().kinematic.position.z < -(size.z / 2))
        {
            GetComponent<BasicBoidBehaviour>().kinematic.position.z = -(size.z / 2);
            GetComponent<BasicBoidBehaviour>().kinematic.speed.z = -GetComponent<BasicBoidBehaviour>().kinematic.speed.z;
        }
    }

    // Update is called once per frame
    void Update ()
    {
        bounce();
    }
}
