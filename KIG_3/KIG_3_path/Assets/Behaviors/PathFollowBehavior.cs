using UnityEngine;
using System.Collections.Generic;
class PathFollowBehavior : SteeringBehavior
{
    private SteeringBehavior seekBehavior;
    private int currentNode;
    private float seekDistance;
    private List<Vector3> nodes;
    public PathFollowBehavior()
    {
        currentNode = 0;
        seekDistance = 0.5f;
        nodes = GameObject.FindGameObjectWithTag("manager").GetComponent<SpawnManager>().path;
        seekBehavior = new SeekBehavior(nodes[currentNode]);
    }

    public PathFollowBehavior(List<Vector3> _nodes)
    {
        currentNode = 0;
        seekDistance = 0.1f;
        nodes = _nodes;
        seekBehavior = new SeekBehavior(nodes[currentNode]);
    }

    public override void Behave()
    {
        SelectNode();
        seekBehavior.setControl(_Control);
        seekBehavior.setKinematic(_Kinematic);
        seekBehavior.Move();

        _Control = seekBehavior.getControl();
        _Kinematic = seekBehavior.getKinematic();
    }

    private void SelectNode()
    {
        float distance;
        if (nodes != null)
        {
            distance = (_Kinematic.position - nodes[currentNode]).magnitude;
            if (distance <= seekDistance)
            {
                //If the nodes is raeched , change the seek to another node
                currentNode++;
                if (currentNode >= nodes.Count)
                {
                    currentNode = nodes.Count - 1;
                }
                seekBehavior = new SeekBehavior(nodes[currentNode]);
            }
        }
    }
}
