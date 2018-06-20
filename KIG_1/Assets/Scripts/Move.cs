using UnityEngine;

public class Move : MonoBehaviour
{

    private GameObject target;
    public string behavior;
    public Kinematic _kinematic;
    public Control _control;

    //Wander
    private Vector3 wayPoint;
    private float range;
    [SerializeField] private float offset;
    [SerializeField] private float radius;
    [SerializeField] private float maxChange;
    [SerializeField] private float angleChange;

    //Arrive
    private float brakeRadius, timeToEnd;
    
    public struct Kinematic
    {
        public Vector3 pos;
        public Vector3 speed;
        public float orientation;
        public float maxSpeed;
        public float rotation;
    }

    public struct Control
    {
        public Vector3 linear;
        public float angular;
        public float maxStrenght;
    }

    void Start()
    {
        range = 2.0f;
        _kinematic.maxSpeed = 10.0f;
        _control.maxStrenght = 2.0f;
        target = GameObject.FindGameObjectWithTag("target");
        float a = Random.Range(-3, 3);
        float b = Random.Range(-3, 3);
        _kinematic.pos = transform.position;
        //to prevent standing boids
        while (a == 0 || b == 0)
        {
            a = Random.Range(-3, 3);
            b = Random.Range(-3, 3);
        }

        _kinematic.speed = new Vector3(a, 0, b);
    }

    void Update()
    {
        switch (behavior)
        {
            case "k_seek":
                KinematicSeek();
                break;

            case "k_flee":
                KinematicFlee();
                break;

            case "k_arrive":
                KinematicArrive();
                break;

            case "d_wander":
                    DynamicWander();
                break;

            case "d_seek":
                DynamicSeek();
                break;

            case "d_flee":
                DynamicFlee();
                break;

            case "d_arrive":
                DynamicArrive();
                break;

            case "d_flocking":      
                //controled by velocityManager         
                break;
        }
        UpdatePosition();
    }

    private void UpdatePosition()
    {
        _kinematic.speed = Vector3.ClampMagnitude(_kinematic.speed, _kinematic.maxSpeed);
        _control.linear = Vector3.ClampMagnitude(_control.linear, _control.maxStrenght);

        _kinematic.pos += _kinematic.speed * Time.deltaTime;
        _kinematic.orientation += _kinematic.rotation * Time.deltaTime;

        _kinematic.speed += _control.linear*Time.deltaTime;
        _kinematic.rotation += _control.angular*Time.deltaTime;

        transform.position = _kinematic.pos;
    }

    private void DynamicWander()
    {
        offset = 5.0f;
        radius = 5.0f;
        //maxChange = DegreeToRadiant(10);
        maxChange = 0.174533f;

        Vector3 midle = _kinematic.speed.normalized * offset;
        //Vector3 midle = new Vector3((float)Mathf.Cos(_kinematic.orientation), 0, (float)Mathf.Sin(_kinematic.orientation));

        float p1 = Random.Range(0, 100) / 100.0f;
        float p2 = Random.Range(0, 100) / 100.0f;
        float pFinal = 1 - (p1 + p2);

        angleChange += pFinal * maxChange;

        Vector3 tmp = new Vector3((float) Mathf.Cos(angleChange), 0, (float) Mathf.Sin(angleChange));
        wayPoint = midle + tmp.normalized * radius;

        _control.linear = wayPoint * _control.maxStrenght;
    }

    public void KinematicFlee()
    {
        _control.linear = target.transform.position;
        _control.angular = 0.0f;

        if (target == null)
            return;

        _kinematic.speed = _kinematic.pos - target.transform.position;
        _kinematic.speed = _kinematic.speed.normalized * _kinematic.maxSpeed;
    }

    private void KinematicSeek()
    {
        _control.linear = target.transform.position;
        _control.angular = 0.0f;

        if (target == null)
            return;

        _kinematic.speed = target.transform.position - _kinematic.pos;
        _kinematic.speed = _kinematic.speed.normalized * _kinematic.maxSpeed;
    }

    private void KinematicArrive()
    {
        brakeRadius = 2.0f;
        timeToEnd = 0.5f;
        Vector3 temp = target.transform.position - _kinematic.pos;

        if (_kinematic.speed.magnitude < brakeRadius)
        {
            _kinematic.speed = new Vector3(0, 0, 0);
            return;
        }
        else
        {
            _kinematic.speed = temp;
            _kinematic.speed *= timeToEnd;
            _kinematic.rotation = 0.0f;
        }
        return;
    }

    private void DynamicFlee()
    {
        _control.linear = _kinematic.pos - target.transform.position;
        _control.linear = _control.linear.normalized * _control.maxStrenght;
        _control.angular = 0;
    }

    private void DynamicSeek()
    {
        _control.linear = target.transform.position - _kinematic.pos;
        _control.linear = _control.linear.normalized  * _control.maxStrenght;
        _control.angular = 0;
    }

    private void DynamicArrive()
    {
        float targetSpeed = 0.0f;
        timeToEnd = 0.5f;

        Vector3 direction = target.transform.position - _kinematic.pos;

        if (direction.magnitude > brakeRadius)
        {
            targetSpeed = _kinematic.maxSpeed;
        }
        else
        {
            targetSpeed = _kinematic.maxSpeed * direction.magnitude / brakeRadius;
        }
        direction = direction - _kinematic.pos * targetSpeed;

        _control.linear = direction - _kinematic.speed;
        _control.linear /= timeToEnd;

        _control.angular = 0;
    }

    private float DegreeToRadiant(float angle)
    {
        return Mathf.PI * angle / 180;
    }

    public void setBehavior(string s)
    {
        behavior = s;
    }
}
