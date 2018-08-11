#pragma once
#include "utility\Vectors.h"

enum Falloff
{
	// TODO: Implement different falloff methods in the future.
};

struct PointLight
{
	Vector4 lightColor = { 1.0f, 1.0f, 1.0f, 1.0f };
	float lightEnergy = 60.0f;
	float distance = 1.0f;

	Vector4 m_WorldPos = { 30.0f, 30.0f, 35.0f, 1.0f };
};