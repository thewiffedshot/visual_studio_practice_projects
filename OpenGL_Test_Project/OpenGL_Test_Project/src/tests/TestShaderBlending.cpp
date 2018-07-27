#include "TestShaderBlending.h"
#include "Macros.h"
#include <GLFW/glfw3.h>
#include "GL\glew.h"
#include "imgui\imgui.h"
#include "glm/gtc/matrix_transform.hpp"

#define _USE_MATH_DEFINES
#include <math.h>

test::TestShaderBlending::TestShaderBlending(GLFWwindow* window)
	: vbo(VertexBuffer(tri2Dpositions, sizeof(tri2Dpositions))), ibo(IndexBuffer(indices, 6)),
	slopeIncrement(0.04f), count(0), slope(0.0f), switched(false), color1{ 0.0f, 1.0f, 0.0f, 0.4f },
	color2{ 1.0f, 0.0f, 0.0f, 0.4f }, tslot(0)
{
	glfwGetWindowSize(window, &windowWidth, &windowHeight);
	windowSize[0] = windowWidth;
	windowSize[1] = windowHeight;

	layout.Push<float>(2);
	layout.Push<float>(2);
	va.AddBuffer(vbo, layout);

	program.Attach(testShaders, 2);
	secondProgram.Attach(testShaders2, 2);

	c1 = Uniform(color1, UniformType::FLOAT4, "u_Color", false);					
	c2 = Uniform(color2, UniformType::FLOAT4, "u_Color2", false);
	WindowSize = Uniform(windowSize, UniformType::FLOAT2, "u_WindowSize", false);
	SlopeBounds = Uniform(&slope, UniformType::FLOAT, "u_SlopeBoundary", false);
	ColorSwitched = Uniform(&switched, UniformType::INT, "u_Switched", false);

	projMatrix = glm::ortho(-1.777778f, 1.777778f, -1.0f, 1.0f, -1.0f, 1.0f);
	MVP = Uniform(&projMatrix[0][0], UniformType::fMAT4x4, "u_MVP", false);

	t1 = Texture("res/textures/groundT.png");
	t1.Bind(tslot);
	tslot_t1 = Uniform(&tslot, UniformType::INT, "u_Texture", false);

	program.Bind();
	program.AttachUniform(c1);				// Important: Need to rewrite GLProgram code so that it eliminates possible duplicate identifier uniforms from it's 'vector' Uniform cache.
	program.AttachUniform(c2);
	program.AttachUniform(WindowSize);
	program.AttachUniform(SlopeBounds);
	program.AttachUniform(ColorSwitched);
	program.AttachUniform(MVP);

	secondProgram.Bind();
	secondProgram.AttachUniform(tslot_t1);
	secondProgram.AttachUniform(MVP);
}

test::TestShaderBlending::~TestShaderBlending()
{
}

void test::TestShaderBlending::OnUpdate(float deltaTime)
{
}

void test::TestShaderBlending::OnRender(const Renderer& renderer)
{
	renderer.Draw(va, ibo, secondProgram);

	c1.SetData(color1);
	c2.SetData(color2);
	SlopeBounds.SetData(&slope);
	ColorSwitched.SetData(&switched);

	renderer.Draw(va, ibo, program);

	if (!clockwise)
	{
		slope += slopeIncrement;

		if (slope > M_PI)
		{
			slope = 0;
			switched = !switched;
		}
	}
	else if (clockwise)
	{
		slope -= slopeIncrement;

		if (slope < 0)
		{
			slope = M_PI;
			switched = !switched;
		}
	}

	ImGui::Render();
}

void test::TestShaderBlending::OnImGuiRender()
{
	ImGui::ShowDemoWindow(&show_demo_window);

	{
		static float f = 0.0f;
		static int counter = 0;

		ImGui::Begin("Controls.");                          // Create a window called "Hello, world!" and append into it.

		ImGui::Text("Use this form to control parameters.");					  // Display some text (you can use a format strings too)
		ImGui::Checkbox("Clockwise: ", &clockwise);								  // Edit bools storing our window open/close state

		ImGui::SliderFloat("Increment: ", &slopeIncrement, 0.0f, 1.0f);           // Edit 1 float using a slider from 0.0f to 1.0f    
		ImGui::ColorEdit4("color 1", (float*)&color1);							  // Edit 4 floats representing a color
		ImGui::ColorEdit4("color 2", (float*)&color2);					          // Edit 4 floats representing a color																			 

		ImGui::Text("Application average %.3f ms/frame (%.1f FPS)", 1000.0f / ImGui::GetIO().Framerate, ImGui::GetIO().Framerate);
		ImGui::End();
	}
}