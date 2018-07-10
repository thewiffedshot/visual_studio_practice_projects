#pragma once
#include "Shader.h"
#include <vector>

class GLProgram
{
private:
	unsigned int m_RendererID;
	std::vector<Shader*> m_AttachedShaders;
	std::vector<Uniform*> m_Uniforms;
	int* m_UniformLocations = nullptr;

	void LinkProgram();
	int* GetUniformLocations();
	void ParseUniform(const std::string& uniformName);
	void ParseUniform(Uniform* uniform);
	
	template<typename T, enum type>
	void SetUniformData(Uniform* uniform, unsigned int count);

	template<typename T>
	void SetUniformData(Uniform* uniform, unsigned int count);

	template<>
	void SetUniformData<float>(Uniform* uniform, unsigned int count);

	template<>
	void SetUniformData<double>(Uniform* uniform, unsigned int count);

	template<>
	void SetUniformData<int>(Uniform* uniform, unsigned int count);

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

	inline int GetUniformLocation(Uniform* uniform) const;
};