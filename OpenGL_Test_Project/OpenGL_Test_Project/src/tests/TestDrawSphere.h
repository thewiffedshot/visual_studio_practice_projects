#pragma once
#include "Test.h"
#include "glm\glm.hpp"
#include "glm\gtc\matrix_transform.hpp"
#include "Model.h"
#include "Camera.h";
#include <string>
#include "GLFW\glfw3.h"

#define _USE_MATH_DEFINES
#include <math.h>

namespace test
{
	class TestDrawSphere : public Test
	{
	public:
		TestDrawSphere(GLFWwindow* window);
		~TestDrawSphere();

		void OnRender(const Renderer& renderer) override;
		void OnImGuiRender() override;
		void OnUpdate(float deltaTime) override;

	private:
		GLFWwindow* window;
		PointLight light;
		Model sphereModel;
		Camera camera;

		Shader shaders[2] = {
			Shader(GL_VERTEX_SHADER, "res/shaders/BasicLighting.shader"),
			Shader(GL_FRAGMENT_SHADER, "res/shaders/BasicLighting.shader")
		};

		GLProgram program;
	};
}