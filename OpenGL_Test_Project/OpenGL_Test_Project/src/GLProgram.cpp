#include "GLProgram.h"

GLProgram::GLProgram(Shader shaders[], unsigned int arraySize)
{
	GLCall(m_RendererID = glCreateProgram());
	Attach(shaders, arraySize);
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

void GLProgram::Attach(Shader shaders[], unsigned int arraySize)
{
	unsigned int count = arraySize / sizeof(Shader);
	ASSERT(count != 0);

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

