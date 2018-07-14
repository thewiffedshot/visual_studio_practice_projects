#include "Renderer.h"

void Renderer::Draw(const VertexArray& va, const IndexBuffer& ib, GLProgram& program) const
{
	program.Bind();
	ib.Bind();
	va.Bind();
	GLCall(glDrawElements(GL_TRIANGLES, ib.GetVertexCount(), GL_UNSIGNED_INT, nullptr));
}