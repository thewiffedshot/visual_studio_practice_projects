#pragma once
#include <iostream>
#include <vector>
#include <GL\glew.h>
#include "Renderer.h"

enum UniformType
{
	INVALID = -1,
	FLOAT,
	FLOAT2,
	FLOAT3,
	FLOAT4,
	DOUBLE,
	DOUBLE2,
	DOUBLE3,
	DOUBLE4,
	INT,
	INT1,
	INT2,
	INT3,
	INT4,
};

class Uniform
{
private:
	void* m_Values;

public:

};