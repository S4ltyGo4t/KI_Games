using UnityEngine;

abstract class SteeringBehavior
{
    protected BasicBoidBehaviour.Control _Control;
    protected BasicBoidBehaviour.Kinematic _Kinematic;

    public void setControl(BasicBoidBehaviour.Control control)
    {
        _Control = control;
    }

    public void setKinematic(BasicBoidBehaviour.Kinematic kinematic)
    {
        _Kinematic = kinematic;
    }

    public BasicBoidBehaviour.Control getControl()
    {
        return _Control;
    }

    public BasicBoidBehaviour.Kinematic getKinematic()
    {
        return _Kinematic;
    }
    public abstract void Behave();

    public void Move()
    {
        //Maybe Time als übergabe-Parameter
        //IF it works remove comment
        Behave();
        _Kinematic.speed = Vector3.ClampMagnitude(_Kinematic.speed, _Kinematic.maxSpeed);
        _Control.linear = Vector3.ClampMagnitude(_Control.linear, _Control.maxStrength);

        _Kinematic.position += _Kinematic.speed * Time.deltaTime;
        _Kinematic.direction += _Kinematic.rotation * Time.deltaTime;

        _Kinematic.speed += _Control.linear * Time.deltaTime;
        _Kinematic.rotation += _Control.angular * Time.deltaTime;
    }

}