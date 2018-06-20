using System.Collections.Generic;
using UnityEngine;

public class CreateBoids : MonoBehaviour
{

    [SerializeField] private GameObject ground;
    [SerializeField] private GameObject redBoidPrefab;
    [SerializeField] private GameObject greenBoidPrefab;
    [SerializeField] private int boidCount;
    [SerializeField] public string currentBehavior;
    private bool bFishmode;

    public List<GameObject> redBoids, greenBoids;

	// Use this for initialization
	void Start ()
	{
        redBoids = new List<GameObject>();
	    greenBoids = new List<GameObject>();
        bFishmode = false;

        for (int i = 0; i <= boidCount; i++)
        {
            redBoids.Add(Instantiate(redBoidPrefab));
            redBoids[i].transform.position = RandomPointOnPlane(ground);
            redBoids[i].transform.rotation = Quaternion.Euler(0,Random.Range(0f, 360f),0);
            redBoids[i].name = "RedBoid " + i;

            greenBoids.Add(Instantiate(greenBoidPrefab));
            greenBoids[i].transform.position = RandomPointOnPlane(ground);
            greenBoids[i].transform.rotation = Quaternion.Euler(0,Random.Range(0f, 360f), 0);
            greenBoids[i].name = "GreenBoid " + i;
        }
	    currentBehavior = "wander";
        SetCurrentBehavior(currentBehavior);
	}

    private Vector3 RandomPointOnPlane(GameObject plane)
    {
        float height = plane.transform.lossyScale.x * 2.5f * 2f;
        float width = plane.transform.lossyScale.z *2.5f*2f;

        float rngX = Random.Range(-height, height);
        float rngZ = Random.Range(-width, width);

        return new Vector3(rngX,0,rngZ);
    }

    public void SetCurrentBehavior(string s)
    {
        currentBehavior = s;
        for (int i = 0; i <= boidCount; i++)
        {
            redBoids[i].gameObject.GetComponent<Move>().setBehavior(s);
            greenBoids[i].gameObject.GetComponent<Move>().setBehavior(s);
        }
    }

    private void Update()
    {
        if (bFishmode)
        {
            //TODO toggle through modes
             
        }
    }

    public void setFishMode()
    {
        if (bFishmode)
        {
            bFishmode = false;
            SetCurrentBehavior(currentBehavior);
        }
        else
        {
            bFishmode = true;
            currentBehavior = "wander";
            SetCurrentBehavior(currentBehavior);
        }
    }
}
