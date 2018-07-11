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
	bool m_Transpose = false;

	template<typename T>
	void ChangeData(void* data, unsigned int count);

	template<>
	void ChangeData<float>(void* data, unsigned int count);

	template<>
	void ChangeData<double>(void* data, unsigned int count);

	template<>
	void ChangeData<int>(void* data, unsigned int count);

public:
	Uniform(void* data, UniformType type, const std::string& identifier, bool transpose);
	~Uniform();

	void* GetData() const
	{
		if (m_Type < 0)
		{
			std::cout << "Error getting uniform data. Uniform is not initialized properly." << std::endl;
			return nullptr;
		}

		return m_Data;
	}

	inline const std::string& GetName() const
	{
		return m_UName;
	}

	inline const UniformType GetType() const
	{
		return m_Type;
	}

	inline const bool Transpose() const
	{
		return m_Transpose;
	}

	void SetData(void* data);
};