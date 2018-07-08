#pragma once
#include "Shader.h"
#include <vector>

class GLProgram
{
private:
	unsigned int m_RendererID;
	std::vector<Shader*> m_AttachedShaders;

	void LinkProgram();

public:
	GLProgram(Shader shaders[], unsigned int arraySize);
	GLProgram();
	~GLProgram();

	void Attach(Shader shaders[], unsigned int arraySize);
	void Detach(Shader& shader);
	void Reattach();
	void Bind();
	void Unbind();

	inline const std::vector<Shader*> AttachedShaders() const
	{
		return m_AttachedShaders;
	}

	inline const unsigned int GetHandle() const
	{
		return m_RendererID;
	}

	inline int GetUniform(const char* uName) const
	{
		GLCall(int id = glGetUniformLocation(m_RendererID, uName));
		ASSERT(id != -1);

		return id;
	}
};