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

class Model
{
public:
	Model(const std::string& objectPath);
	Model(Vector3 worldPosition, const std::string& objectPath);
	Model();
	~Model();

	Material material;

	Vector3 GetPosition() const
	{
		return m_WorldPos;
	}

	void Translate(Vector3 vec)
	{
		m_WorldPos += vec;
		Update();
	}

private:
	Vector3 m_WorldPos = { 0, 0, 0 };
	VertexBuffer vbo;
	IndexBuffer ibo;

	BufferLayout layout;
	VertexArray va;

	void Update();
	void Parse(const std::string& vertexData, const std::string& indexData, const std::string& normalData, const std::string& normalIndexData);
};