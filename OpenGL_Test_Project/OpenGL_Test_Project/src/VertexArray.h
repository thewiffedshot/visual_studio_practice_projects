#pragma once
#include "VertexBuffer.h"
#include "BufferLayout.h"
#include "Renderer.h"

class VertexArray
{
private:
	unsigned int m_RendererID;
public:
	VertexArray();
	~VertexArray();
	void AddBuffer(const VertexBuffer& vbo, const BufferLayout& layout);
	void Bind() const;
	void Unbind() const;
};