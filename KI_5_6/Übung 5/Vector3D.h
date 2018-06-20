#pragma once
#include <math.h>
class Vector3D {
private:
	float x, y, z;
public:
	Vector3D(float x, float y, float z);
	float getX() const;
	float getY() const;
	float getZ() const;
	static Vector3D distance(const Vector3D &a, const Vector3D &b);
	float magnitude();
};