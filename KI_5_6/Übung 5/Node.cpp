#include "Node.h"

Node::Node(Vector3D position, std::string name, unsigned id) : position(position), name(name), id(id)
{
}

Vector3D Node::getPosition() const
{
	return position;
}

void Node::addEdge(Node & node)
{
	Vector3D distance = Vector3D::distance(node.getPosition(), getPosition());
	float cost = distance.magnitude();
	std::cout << "From " << getName() << " to " << node.getName() << " Cost " << cost << " " << endl;
	edges.push_back(make_pair(reference_wrapper<Node>(node), cost));
}

unsigned Node::getID() const
{
	return id;
}

string Node::getName() const
{
	return name;
}

std::vector<pair<Node&, float>>& Node::getEdges()
{
	return edges;
}