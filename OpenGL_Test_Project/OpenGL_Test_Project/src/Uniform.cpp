#include "Uniform.h"

Uniform::Uniform(void * data, UniformType type, const std::string& identifier)
{
	switch (type)
	{
		case FLOAT:
			m_Data = malloc(sizeof(float));
			InitData<float>(data, 1);
			m_UName = identifier;
			m_Type = type;
			break;
		case FLOAT2:
			m_Data = malloc(2 * sizeof(float));
			InitData<float>(data, 2);
			m_UName = identifier;
			m_Type = type;
			break;
		case FLOAT3:
			m_Data = malloc(3 * sizeof(float));
			InitData<float>(data, 3);
			m_UName = identifier;
			m_Type = type;
			break;
		case FLOAT4:
			m_Data = malloc(4 * sizeof(float));
			InitData<float>(data, 4);
			m_UName = identifier;
			m_Type = type;
			break;
		case DOUBLE:
			m_Data = malloc(sizeof(double));
			InitData<double>(data, 1);
			m_UName = identifier;
			m_Type = type;
			break;
		case DOUBLE2:
			m_Data = malloc(2 * sizeof(double));
			InitData<double>(data, 2);
			m_UName = identifier;
			m_Type = type;
			break;
		case DOUBLE3:
			m_Data = malloc(3 * sizeof(double));
			InitData<double>(data, 3);
			m_UName = identifier;
			m_Type = type;
			break;
		case DOUBLE4:
			m_Data = malloc(4 * sizeof(double));
			InitData<double>(data, 4);
			m_UName = identifier;
			m_Type = type;
			break;
		case INT:
			m_Data = malloc(sizeof(int));
			InitData<int>(data, 1);
			m_UName = identifier;
			m_Type = type;
			break;
		case INT2:
			m_Data = malloc(2 * sizeof(int));
			InitData<int>(data, 2);
			m_UName = identifier;
			m_Type = type;
			break;
		case INT3:
			m_Data = malloc(3 * sizeof(int));
			InitData<int>(data, 3);
			m_UName = identifier;
			m_Type = type;
			break;
		case INT4:
			m_Data = malloc(4 * sizeof(int));
			InitData<int>(data, 4);
			m_UName = identifier;
			m_Type = type;
			break;
		case fMAT2x2:
			m_Data = malloc(4 * sizeof(float));
			InitData<float>(data, 4);
			m_UName = identifier;
			m_Type = type;
			break;
		case fMAT3x3:
			m_Data = malloc(9 * sizeof(float));
			InitData<float>(data, 9);
			m_UName = identifier;
			m_Type = type;
			break;
		case fMAT4x4:
			m_Data = malloc(16 * sizeof(float));
			InitData<float>(data, 16);
			m_UName = identifier;
			m_Type = type;
			break;
		case dMAT2x2:
			m_Data = malloc(4 * sizeof(double));
			InitData<double>(data, 4);
			m_UName = identifier;
			m_Type = type;
			break;
		case dMAT3x3:
			m_Data = malloc(9 * sizeof(double));
			InitData<double>(data, 9);
			m_UName = identifier;
			m_Type = type;
			break;
		case dMAT4x4:
			m_Data = malloc(16 * sizeof(double));
			InitData<double>(data, 16);
			m_UName = identifier;
			m_Type = type;
			break;
		case iMAT2x2:
			m_Data = malloc(4 * sizeof(int));
			InitData<int>(data, 4);
			m_UName = identifier;
			m_Type = type;
			break;
		case iMAT3x3:
			m_Data = malloc(9 * sizeof(int));
			InitData<int>(data, 9);
			m_UName = identifier;
			m_Type = type;
			break;
		case iMAT4x4:
			m_Data = malloc(16 * sizeof(int));
			InitData<int>(data, 16);
			m_UName = identifier;
			m_Type = type;
			break;
		default:
		{
			std::cout << "Uniform not set, invalid type supplied." << std::endl;
			m_Type = UniformType::INVALID;
		}
	}
}

Uniform::~Uniform()
{
	if (m_Type >= 0 && m_Type <= 6)
	{
		free(m_Data);
	}
	else if (m_Type >= 7 && m_Type <= 13)
	{
		free(m_Data);
	}
	else if (m_Type > 13)
	{
		free(m_Data);
	}
}

template<>
void Uniform::InitData<int>(void* data, unsigned int count)
{
	int* ptr = (int*)data;

	for (unsigned int i = 0; i < count; ptr++, i++)
	{
		memset((int*)m_Data + i, *(ptr + i), sizeof(int));
	}
}

template<>
void Uniform::InitData<float>(void* data, unsigned int count)
{
	float* ptr = (float*)data;

	for (unsigned int i = 0; i < count; ptr++, i++)
	{
		memset((float*)m_Data + i, *(ptr + i), sizeof(float));
	}
}

template<>
void Uniform::InitData<double>(void* data, unsigned int count)
{
	double* ptr = (double*)data;

	for (unsigned int i = 0; i < count; ptr++, i++)
	{
		memset((double*)m_Data + i, *(ptr + i), sizeof(double));
	}
}
