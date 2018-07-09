#pragma once
#include "Shader.h"
#include <vector>

class GLProgram
{
private:
	unsigned int m_RendererID;
	std::vector<Shader*> m_AttachedShaders;
	std::vector<Uniform*> m_Uniforms;
	unsigned int* m_UniformLocations = nullptr;

	void LinkProgram();
	unsigned int* GetUniformLocations();
	void ParseUniforms();

public:
	GLProgram(Shader shaders[], unsigned int count);
	GLProgram();
	~GLProgram();

	void Attach(Shader shaders[], unsigned int count);
	void Attach(Shader shader);
	void Detach(Shader& shader);
	void Reattach();

	void AttachUniform(Uniform* uniform);
	void AttachUniform(Uniform* uniform[], unsigned int count);
	void DeleteUniform(const std::string& identifier);

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