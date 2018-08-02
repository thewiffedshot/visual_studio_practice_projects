#pragma once
#include "utility\Vectors.h"

struct Material
{
	Vector4 diffuseColor = { 1.0f, 0.0f, 1.0f, 1.0f };
	float diffuseIntensity = 0.8f;

	Vector4 specularColor = { 1.0f, 0.0f, 1.0f, 1.0f };
	float specularIntensity = 1.0f;
	float specularHardness = 1.0f;
};