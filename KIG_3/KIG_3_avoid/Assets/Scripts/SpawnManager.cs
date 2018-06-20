using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

    [SerializeField] private GameObject ground;
    [SerializeField] private GameObject boidPrefab;
    [SerializeField] private int boidCount;

    public List<GameObject> allBoids;
    public List<GameObject> allObstacles;

    // Use this for initialization
    void Start()
    {
        allBoids = new List<GameObject>();

        for (int i = 0; i <= boidCount; i++)
        {
            allBoids.Add(Instantiate(boidPrefab));
            allBoids[i].transform.position = RandomPointOnPlane(ground);
            allBoids[i].transform.rotation = Quaternion.Euler(0, Random.Range(0f, 360f), 0);
            allBoids[i].name = "Fish " + i;
        }

        GameObject[] tmpObstacle = GameObject.FindGameObjectsWithTag("obstacle");
        foreach (GameObject go in tmpObstacle)
        {
            allObstacles.Add(go);
        }
    }


    private Vector3 RandomPointOnPlane(GameObject plane)
    {
        float height = plane.transform.lossyScale.x * 2.5f * 2f;
        float width = plane.transform.lossyScale.z * 2.5f * 2f;

        float rngX = Random.Range(-height, height);
        float rngZ = Random.Range(-width, width);

        return new Vector3(rngX, 0, rngZ);
    }
}
