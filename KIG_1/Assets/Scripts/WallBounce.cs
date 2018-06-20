
using UnityEngine;

public class WallBounce : MonoBehaviour {

    private GameObject ground;
    private float height;
    private float width;

    // Use this for initialization
    void Start ()
    {
        ground = GameObject.FindWithTag("Ground");
        height = ground.transform.lossyScale.x * 2.5f * 2f;
        width = ground.transform.lossyScale.z * 2.5f * 2f;
    }
	
	// Update is called once per frame
	void Update ()
    {
        BounceBorder();
    }

    private void BounceBorder()
    {
        //bounce from Left- and RightBorder
        if (transform.position.x <= -height || transform.position.x >= height)
        {
            gameObject.GetComponent<Move>()._kinematic.speed =
                new Vector3(-gameObject.transform.position.x, 0, gameObject.transform.position.z);
            Vector3.ClampMagnitude(gameObject.GetComponent<Move>()._kinematic.speed,
                gameObject.GetComponent<Move>()._kinematic.maxSpeed);


        }
        //bounce from Buttom- and TopBorder
        else if (transform.position.z <= -width || transform.position.z >= width)
        {
            gameObject.GetComponent<Move>()._kinematic.speed =
                new Vector3(gameObject.transform.position.x, 0, -gameObject.transform.position.z);
            Vector3.ClampMagnitude(gameObject.GetComponent<Move>()._kinematic.speed,
                gameObject.GetComponent<Move>()._kinematic.maxSpeed);
        }
    }
}
