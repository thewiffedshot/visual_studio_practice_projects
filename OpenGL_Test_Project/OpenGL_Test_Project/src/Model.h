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
	Model(Vector4 worldPosition, const std::string& objPath);
	Model();
	~Model();

	Material material;

	void ChangeShaders(Shader* shaders, unsigned int count = 2);

	VertexArray* GetVertexArray()
	{
		return va;
	}

	IndexBuffer* GetIndexBuffer()
	{
		return ibo;
	}

	GLProgram* GetProgram()
	{
		return program;
	}

	Vector4 GetPosition() const
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

	void Translate(Vector4 vec)
	{
		m_WorldPos.x += vec.x;
		m_WorldPos.y += vec.y;
		m_WorldPos.z += vec.z;
		Update();
	}

private:
	Vector4 m_WorldPos = { 0.0f, 0.0f, 0.0f, 1.0f };
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