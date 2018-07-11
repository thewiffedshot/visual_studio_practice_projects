#include "Uniform.h"

Uniform::Uniform(void * data, UniformType type, const std::string& identifier, bool transpose)
{
	switch (type)
	{
		case FLOAT:
			m_Data = new float;
			m_Type = type;
			SetData(data);
			m_UName = identifier;
			break;
		case FLOAT2:
			m_Data = new float[2];
			m_Type = type;
			SetData(data);
			m_UName = identifier;
			break;
		case FLOAT3:
			m_Data = new float[3];
			m_Type = type;
			SetData(data);
			m_UName = identifier;
			break;
		case FLOAT4:
			m_Data = new float[4];
			m_Type = type;
			SetData(data);
			m_UName = identifier;
			break;
		case DOUBLE:
			m_Data = new double;
			m_Type = type;
			SetData(data);
			m_UName = identifier;
			break;
		case DOUBLE2:
			m_Data = new double[2];
			m_Type = type;
			SetData(data);
			m_UName = identifier;
			break;
		case DOUBLE3:
			m_Data = new double[3];
			m_Type = type;
			SetData(data);
			m_UName = identifier;
			break;
		case DOUBLE4:
			m_Data = new double[4];
			m_Type = type;
			SetData(data);
			m_UName = identifier;
			break;
		case INT:
			m_Data = new int;
			m_Type = type;
			SetData(data);
			m_UName = identifier;
			break;
		case INT2:
			m_Data = new int[2];
			m_Type = type;
			SetData(data);
			m_UName = identifier;
			break;
		case INT3:
			m_Data = new int[3];
			m_Type = type;
			SetData(data);
			m_UName = identifier;
			break;
		case INT4:
			m_Data = new int[4];
			m_Type = type;
			SetData(data);
			m_UName = identifier;
			break;
		case fMAT2x2:
			m_Data = new float[4];
			m_Type = type;
			SetData(data);
			m_UName = identifier;
			m_Transpose = transpose;
			break;
		case fMAT3x3:
			m_Data = new float[9];
			m_Type = type;
			SetData(data);
			m_UName = identifier;
			m_Transpose = transpose;
			break;
		case fMAT4x4:
			m_Data = new float[16];
			m_Type = type;
			SetData(data);
			m_UName = identifier;
			m_Transpose = transpose;
			break;
		case dMAT2x2:
			m_Data = new double[4];
			m_Type = type;
			SetData(data);
			m_UName = identifier;
			m_Transpose = transpose;
			break;
		case dMAT3x3:
			m_Data = new double[9];
			m_Type = type;
			SetData(data);
			m_UName = identifier;
			m_Transpose = transpose;
			break;
		case dMAT4x4:
			m_Data = new double[16];
			m_Type = type;
			SetData(data);
			m_UName = identifier;
			m_Transpose = transpose;
			break;
		case iMAT2x2:
			m_Data = new int[4];
			m_Type = type;
			SetData(data);
			m_UName = identifier;
			m_Transpose = transpose;
			break;
		case iMAT3x3:
			m_Data = new int[9];
			m_Type = type;
			SetData(data);
			m_UName = identifier;
			m_Transpose = transpose;
			break;
		case iMAT4x4:
			m_Data = new int[16];
			m_Type = type;
			SetData(data);
			m_UName = identifier;
			m_Transpose = transpose;
			break;
	}
}

Uniform::~Uniform()
{
	if ((m_Type >= 0 && m_Type <= 3))
	{
		delete (float*)m_Data;
	}
	else if ((m_Type >= 4 && m_Type <= 6))
	{
		delete[] (float*)m_Data;
	}
	else if ((m_Type >= 7 && m_Type <= 10))
	{
		delete (double*)m_Data;
	}
	else if ((m_Type >= 11 && m_Type <= 13))
	{
		delete[] (double*)m_Data;
	}
	else if ((m_Type >= 14 && m_Type <= 16))
	{
		delete (int*)m_Data;
	}
	else if ((m_Type >= 17 && m_Type <= 20))
	{
		delete[] (int*)m_Data;
	}
}

void Uniform::SetData(void* data)
{
	switch (m_Type)
	{
		case FLOAT:
			ChangeData<float>(data, 1);
			break;
		case FLOAT2:
			ChangeData<float>(data, 2);
			break;
		case FLOAT3:
			ChangeData<float>(data, 3);
			break;
		case FLOAT4:
			ChangeData<float>(data, 4);
			break;
		case DOUBLE:
			ChangeData<double>(data, 1);
			break;
		case DOUBLE2:
			ChangeData<double>(data, 2);
			break;
		case DOUBLE3:
			ChangeData<double>(data, 3);
			break;
		case DOUBLE4:
			ChangeData<double>(data, 4);
			break;
		case INT:
			ChangeData<int>(data, 1);
			break;
		case INT2:
			ChangeData<int>(data, 2);
		case INT3:
			ChangeData<int>(data, 3);
			break;
		case INT4:
			ChangeData<int>(data, 4);
			break;
		case fMAT2x2:
			ChangeData<float>(data, 4);
			break;
		case fMAT3x3:
			ChangeData<float>(data, 9);
			break;
		case fMAT4x4:
			ChangeData<float>(data, 16);
			break;
		case dMAT2x2:
			ChangeData<double>(data, 4);
			break;
		case dMAT3x3:
			ChangeData<double>(data, 9);
			break;
		case dMAT4x4:
			ChangeData<double>(data, 16);
			break;
		case iMAT2x2:
			ChangeData<int>(data, 4);
			break;
		case iMAT3x3:
			ChangeData<int>(data, 9);
			break;
		case iMAT4x4:
			ChangeData<int>(data, 16);
			break;
	}
}

template<>
void Uniform::ChangeData<float>(void* data, unsigned int count)
{
	for (unsigned int i = 0; i < count; i++)
	{
		*((float*)m_Data + i) = *((float*)data + i);
	}
}

template<>
void Uniform::ChangeData<double>(void* data, unsigned int count)
{
	for (unsigned int i = 0; i < count; i++)
	{
		*((double*)m_Data + i) = *((double*)data + i);
	}
}

template<>
void Uniform::ChangeData<int>(void* data, unsigned int count)
{
	for (unsigned int i = 0; i < count; i++)
	{
		*((int*)m_Data + i) = *((int*)data + i);
	}
}
