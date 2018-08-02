#pragma once
#include "utility\Vectors.h"

enum Falloff
{
	// TODO: Implement different falloff methods in the future.
};

struct PointLight
{
	Vector4 lightColor = { 1.0f, 1.0f, 1.0f, 1.0f };
	float lightEnergy = 10.0f;
	float distance = 20.0f;
};