#include "Vector3D.h"

Vector3D::Vector3D(float x, float y, float z) : x(x), y(y), z(z) {}

float Vector3D::getX() const
{
	return x;
}

float Vector3D::getY() const
{
	return y;
}

float Vector3D::getZ() const
{
	return z;
}

Vector3D Vector3D::distance(const Vector3D & a, const Vector3D & b)
{
	Vector3D ret(
		b.getX() - a.getX(),
		b.getY() - a.getY(),
		b.getZ() - a.getZ()
	);
	return ret;
}

float Vector3D::magnitude()
{
	return static_cast<float>(sqrt(x*x + y*y + z*z));
}
