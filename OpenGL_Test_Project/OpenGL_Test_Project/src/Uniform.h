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
	fMAT2x2,
	fMAT3x3,
	fMAT4x4,
	DOUBLE,
	DOUBLE2,
	DOUBLE3,
	DOUBLE4,
	dMAT2x2,
	dMAT3x3,
	dMAT4x4,
	INT,
	INT2,
	INT3,
	INT4,
	iMAT2x2,
	iMAT3x3,
	iMAT4x4
};

class Uniform
{
private:
	void* m_Data;
	UniformType m_Type = INVALID;
	std::string m_UName;

	template<typename T>
	void InitData(void* data, unsigned int count);

	template<>
	void InitData<int>(void* data, unsigned int count);

	template<>
	void InitData<double>(void* data, unsigned int count);

	template<>
	void InitData<float>(void* data, unsigned int count);

public:
	Uniform(void* data, UniformType type, const std::string& identifier);
	~Uniform();
	
	void* GetData(unsigned int& stride) const
	{
		if (m_Type < 0)
		{
			std::cout << "Error getting uniform data. Uniform is not initialized properly." << std::endl;
			stride = -1;
			return nullptr;
		}
		else if (m_Type >= 0 && m_Type <= 6)
		{
			stride = sizeof(float);
		}
		else if (m_Type >= 7 && m_Type <= 13)
		{
			stride = sizeof(double);
		}
		else if (m_Type > 13)
		{
			stride = sizeof(int);
		}

		return m_Data;
	}

	inline const std::string& GetName() const
	{
		return m_UName;
	}
};
