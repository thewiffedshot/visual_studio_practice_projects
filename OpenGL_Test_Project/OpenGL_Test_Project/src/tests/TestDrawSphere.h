#pragma once
#include "Test.h"
#include "glm\glm.hpp"
#include "glm\gtc\matrix_transform.hpp"
#include "Model.h"
#include "Camera.h";
#include <string>
#include "GLFW\glfw3.h"
#include <memory>

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

		Uniform* ViewMatrix;
		Uniform* ProjMatrix;
		Uniform* LightPos;
		Uniform* MaterialColor;
		Uniform* LightColor;
		Uniform* LightDistance;
		Uniform* LightPower;
	};
}