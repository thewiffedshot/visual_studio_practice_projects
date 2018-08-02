#pragma once
#include "glm\glm.hpp"
#include "utility\Vectors.h"

class Camera
{
public:
	Camera(Vector3 worldPosition, float xRot, float yRot, float zRot);
	Camera();
	~Camera();

	Vector3 GetPosition() const
	{
		return m_WorldPos;
	}

	void Translate(Vector3 vec)
	{
		m_WorldPos += vec;
		Update();
	}

	void RotateX(float rot)
	{
		xRot += rot;
		Update();
	}

	void RotateY(float rot)
	{
		yRot += rot;
		Update();
	}

	void RotateZ(float rot)
	{
		zRot += rot;
		Update();
	}

private:
	Vector3 m_WorldPos = { 0, 0, 0 };
	float xRot = 0, yRot = 0, zRot = 0;

	glm::mat4 viewProjection;

	void Update();
};