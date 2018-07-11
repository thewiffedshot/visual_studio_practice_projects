#include "GLProgram.h"

GLProgram::GLProgram(Shader shaders[], unsigned int count)
{
	GLCall(m_RendererID = glCreateProgram());
	Attach(shaders, count);
	Bind();
}

GLProgram::GLProgram()
{
	GLCall(m_RendererID = glCreateProgram());
}

GLProgram::~GLProgram()
{
	GLCall(glDeleteProgram(m_RendererID));
}

void GLProgram::Bind()
{
	GLCall(glUseProgram(m_RendererID));
}

void GLProgram::Unbind()
{
	GLCall(glUseProgram(0));
}

void GLProgram::Attach(Shader shader)
{
	if (shader.Attachable())
	{
		GLCall(glAttachShader(m_RendererID, shader.GetHandle()));
		m_AttachedShaders.push_back(&shader);
	}
	else
		std::cout << "Shader of type '" << shader.GetType() << "' and handle '" << shader.GetHandle() << "' is not attachable. It was left off the final program with handle '" << m_RendererID << "'" << std::endl;

	LinkProgram();
}

void GLProgram::Attach(Shader shaders[], unsigned int count)
{
	for (unsigned int i = 0; i < count; i++)
	{
		if (shaders[i].Attachable())
		{
			GLCall(glAttachShader(m_RendererID, shaders[i].GetHandle()));
			m_AttachedShaders.push_back(&shaders[i]);
		}
		else
			std::cout << "Shader of type '" << shaders[i].GetType() << "' and handle '" << shaders[i].GetHandle() << "' is not attachable. It was left off the final program with handle '" << m_RendererID << "'" << std::endl;
	}

	LinkProgram();
}

void GLProgram::Detach(Shader& shader)
{
	unsigned int count = m_AttachedShaders.size();

	for (unsigned int i = 0; i < count; i++)
	{
		if (shader.SameInstance(*m_AttachedShaders[i]))
		{
			m_AttachedShaders.erase(m_AttachedShaders.begin() + i);
			GLCall(glDetachShader(m_RendererID, m_AttachedShaders[i]->GetHandle()));
		}
	}

	LinkProgram();
}

void GLProgram::Reattach()
{
	unsigned int count = m_AttachedShaders.size();

	for (unsigned int i = 0; i < count; i++)
	{
		GLCall(glDetachShader(m_RendererID, m_AttachedShaders[i]->GetHandle()));
		GLCall(glAttachShader(m_RendererID, m_AttachedShaders[i]->GetHandle()));
	}

	LinkProgram();
}

void GLProgram::LinkProgram()
{
	GLCall(glLinkProgram(m_RendererID));
	GLCall(glValidateProgram(m_RendererID));

	unsigned int count = m_AttachedShaders.size();
	
	for (unsigned int i = 0; i < count; i++)
	{
		GLCall(glDeleteShader(m_AttachedShaders[i]->GetHandle()));
	}
}

void GLProgram::AttachUniform(Uniform& uniform)		// Returns location of uniform in program (for modifying uniform data at runtime).
{
	m_Uniforms.push_back(&uniform);
	m_UniformLocations = GetUniformLocations();
	ParseUniform(&uniform);
}

void GLProgram::DeleteUniform(const std::string& identifier)
{
	unsigned int i = 0;

	for (Uniform* u : m_Uniforms)
	{
		if (u->GetName() == identifier)
			m_Uniforms.erase(m_Uniforms.begin() + i);

		i++;
	}

	m_UniformLocations = GetUniformLocations();
}


int* GLProgram::GetUniformLocations()
{
	if (m_UniformLocations != nullptr) free(m_UniformLocations);

	unsigned int count = m_Uniforms.size();
	int* ptr = (int*)malloc(count * sizeof(int));

	for (unsigned int i = 0; i < count; i++)
	{
		GLCall(*(ptr + i) = glGetUniformLocation(m_RendererID, m_Uniforms[i]->GetName().c_str()));
		ASSERT(*(ptr + i) != -1);
	}

	return ptr;
}

void GLProgram::ParseUniform(Uniform* uniform)
{
	unsigned int locationOffset = 0;

	for (Uniform* u : m_Uniforms)
	{
		if (u == uniform)
			break;

		locationOffset++;
	}

	if (locationOffset >= m_Uniforms.size())
	{
		std::cout << "No uniform with identifier '" << uniform->GetName() << "' present. It was not parsed." << std::endl;
		return;
	}

	UniformType type = uniform->GetType();
	void* data = nullptr;

	bool oneValue = type == UniformType::FLOAT || type == UniformType::DOUBLE || type == UniformType::INT;
	bool twoValues = type == UniformType::FLOAT2 || type == UniformType::DOUBLE2 || type == UniformType::INT2;
	bool threeValues = type == UniformType::FLOAT3 || type == UniformType::DOUBLE3 || type == UniformType::INT3;
	bool fourValues = type == UniformType::FLOAT4 || type == UniformType::DOUBLE4 || type == UniformType::INT4;
	bool mat2x2 = type == UniformType::fMAT2x2 || type == UniformType::dMAT2x2 || type == UniformType::iMAT2x2;
	bool mat3x3 = type == UniformType::fMAT3x3 || type == UniformType::dMAT3x3 || type == UniformType::iMAT3x3;
	bool mat4x4 = type == UniformType::fMAT4x4 || type == UniformType::dMAT4x4 || type == UniformType::iMAT4x4;
	bool floatCast = type >= 0 && type <= 6 ? true : false;
	bool doubleCast = type >= 7 && type <= 13 ? true : false;
	bool intCast = type > 13 ? true : false;


	if (oneValue)
	{
		if (floatCast)
		{
			data = uniform->GetData();

			GLCall(glUniform1f(*(m_UniformLocations + locationOffset), *((float*)data)));
		}
		else if (doubleCast)
		{
			data = uniform->GetData();

			GLCall(glUniform1d(*(m_UniformLocations + locationOffset), *((double*)data)));
		}
		else if (intCast)
		{
			data = uniform->GetData();

			GLCall(glUniform1i(*(m_UniformLocations + locationOffset), *((int*)data)));
		}
	}
	else if (twoValues)
	{
		if (floatCast)
		{
			data = uniform->GetData();

			GLCall(glUniform2f(*(m_UniformLocations + locationOffset), *(((float*)data)), *(((float*)data) + 1)));
		}
		else if (doubleCast)
		{
			data = uniform->GetData();

			GLCall(glUniform2d(*(m_UniformLocations + locationOffset), *(((double*)data)), *(((double*)data) + 1)));
		}
		else if (intCast)
		{
			data = uniform->GetData();

			GLCall(glUniform2i(*(m_UniformLocations + locationOffset), *(((int*)data)), *(((int*)data) + 1)));
		}
	}
	else if (threeValues)
	{
		if (floatCast)
		{
			data = uniform->GetData();

			GLCall(glUniform3f(*(m_UniformLocations + locationOffset), *(((float*)data)), *(((float*)data) + 1), *(((float*)data) + 2)));
		}
		else if (doubleCast)
		{
			data = uniform->GetData();

			GLCall(glUniform3d(*(m_UniformLocations + locationOffset), *(((double*)data)), *(((double*)data) + 1), *(((double*)data) + 2)));
		}
		else if (intCast)
		{
			data = uniform->GetData();

			GLCall(glUniform3i(*(m_UniformLocations + locationOffset), *(((int*)data)), *(((int*)data) + 1), *(((int*)data) + 2)));
		}
	}
	else if (fourValues)
	{
		if (floatCast)
		{
			data = uniform->GetData();

			GLCall(glUniform4f(*(m_UniformLocations + locationOffset), *(((float*)data)), *(((float*)data) + 1), *(((float*)data) + 2), *(((float*)data) + 3)));
		}
		else if (doubleCast)
		{
			data = uniform->GetData();

			GLCall(glUniform4d(*(m_UniformLocations + locationOffset), *(((double*)data)), *(((double*)data) + 1), *(((double*)data) + 2), *(((double*)data) + 3)));
		}
		else if (intCast)
		{
			data = uniform->GetData();

			GLCall(glUniform4i(*(m_UniformLocations + locationOffset), *(((int*)data)), *(((int*)data) + 1), *(((int*)data) + 2), *(((int*)data) + 3)));
		}
	}
	else if (mat2x2)
	{
		if (floatCast)
		{
			data = uniform->GetData();

			GLCall(glUniformMatrix2fv(*(m_UniformLocations + locationOffset), 1, uniform->Transpose(), (float*)data));
		}
		else if (doubleCast)
		{
			data = uniform->GetData();

			GLCall(glUniformMatrix2dv(*(m_UniformLocations + locationOffset), 1, uniform->Transpose(), (double*)data));
		}
	}
	else if (mat3x3)
	{
		if (floatCast)
		{
			data = uniform->GetData();

			GLCall(glUniformMatrix3fv(*(m_UniformLocations + locationOffset), 1, uniform->Transpose(), (float*)data));
		}
		else if (doubleCast)
		{
			data = uniform->GetData();

			GLCall(glUniformMatrix3dv(*(m_UniformLocations + locationOffset), 1, uniform->Transpose(), (double*)data));
		}
	}
	else if (mat4x4)
	{
		if (floatCast)
		{
			data = uniform->GetData();

			GLCall(glUniformMatrix4fv(*(m_UniformLocations + locationOffset), 1, uniform->Transpose(), (float*)data));
		}
		else if (doubleCast)
		{
			data = uniform->GetData();

			GLCall(glUniformMatrix4dv(*(m_UniformLocations + locationOffset), 1, uniform->Transpose(), (double*)data));
		}
	}
}

void GLProgram::RefreshUniforms()
{
	for (Uniform* u : m_Uniforms)
	{
		ParseUniform(u);
	}
}