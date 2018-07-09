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

void GLProgram::AttachUniform(Uniform* uniform)
{
	m_Uniforms.push_back(uniform);

	m_UniformLocations = GetUniformLocations();
}

void GLProgram::AttachUniform(Uniform* uniform[], unsigned int count)
{
	for (unsigned int i = 0; i < count; i++)
	{
		m_Uniforms.push_back(uniform[i]);
	}

	m_UniformLocations = GetUniformLocations();
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

inline int GLProgram::GetUniformLocation(Uniform* uniform) const
{
	for (unsigned int i = 0; i < m_Uniforms.size(); i++)
	{
		if (&uniform == &m_Uniforms[i])
		{
			return *(m_UniformLocations + i);
		}
	}
}

void GLProgram::ParseUniforms()
{
	
}

