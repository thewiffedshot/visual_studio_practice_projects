#pragma once
#include "VertexBuffer.h"
#include "IndexBuffer.h"
#include "utility\Vectors.h"
#include <string>
#include <sstream>
#include "BufferLayout.h"
#include "VertexArray.h"
#include "lighting\Material.h"
#include "lighting\PointLight.h"
#include "GLProgram.h"

class Model
{
public:
	Model(const std::string& objPath);
	Model(Vector3 worldPosition, const std::string& objPath);
	Model();
	~Model();

	Material material;

	void ChangeShaders(Shader* shaders, unsigned int count = 2);

	Vector3 GetPosition() const
	{
		return m_WorldPos;
	}

	unsigned long GetFaces() const
	{
		return m_Faces;
	}

	unsigned long GetVerteces() const
	{
		return m_Verteces;
	}

	void Translate(Vector3 vec)
	{
		m_WorldPos += vec;
		Update();
	}

private:
	Vector3 m_WorldPos = { 0, 0, 0 };
	unsigned long m_Faces = -1;
	unsigned long m_Verteces = -1;

	Shader shaders[2] = 
	{
		Shader(GL_VERTEX_SHADER, "res/shaders/Diffuse.shader"),
		Shader(GL_FRAGMENT_SHADER, "res/shaders/Diffuse.shader")
	};

	GLProgram* program;

	VertexBuffer* vbo;
	IndexBuffer* ibo;

	BufferLayout* layout;
	VertexArray* va;

	void Update();
	void Parse(const std::string& vertexData, const std::string& indexData, const std::string& normalData, const std::string& normalIndexData);
};