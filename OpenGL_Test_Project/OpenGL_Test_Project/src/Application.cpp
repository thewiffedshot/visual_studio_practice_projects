#include <GL/glew.h>
#include <GLFW/glfw3.h>
#include <iostream>
#include <fstream>
#include <string>
#include <sstream>
#include "Renderer.h"
#include "IndexBuffer.h"
#include "VertexBuffer.h"
#include "VertexArray.h"
#include "BufferLayout.h"
#include "Shader.h"
#include "GLProgram.h"
#include "Uniform.h"

#define _USE_MATH_DEFINES
#include <math.h>

struct Vector4
{
	float x, y, z, w;

	Vector4(float x, float y, float z, float w)
		: x(x), y(y), z(z), w(w)
	{

	}
};

int main(void)
{
	GLFWwindow* window;

	/* Initialize the library */
	if (!glfwInit())
		return -1;

	glfwWindowHint(GLFW_CONTEXT_VERSION_MAJOR, 3);
	glfwWindowHint(GLFW_CONTEXT_VERSION_MINOR, 3);
	glfwWindowHint(GLFW_OPENGL_PROFILE, GLFW_OPENGL_CORE_PROFILE);

	/* Create a windowed mode window and its OpenGL context */
	window = glfwCreateWindow(640, 480, "Hello World", NULL, NULL);				// Window with OpenGL context is created but context is not set to current.
	if (!window)
	{
		glfwTerminate();
		return -1;
	}

	/* Make the window's context current */
	glfwMakeContextCurrent(window);												// Setting the window's OpenGL context before initializing GLEW is critical.
	glfwSwapInterval(1);

	if (glewInit() != GLEW_OK)													// GLEW needs to be initialized before attempting to call any GL functions. Beware of the scary NULL pointers.
		std::cout << "GLEW initialization error. Terminating..." << std::endl;													

	std::cout << glGetString(GL_VERSION) << std::endl;														

	float tri2Dpositions[8] = {				// Defined an array containing all our verticies for a simple quad in this case.
		-0.4f, -0.35f,
		 0.8f, -0.35f,
		 0.4f,  0.35f,
		-0.8f,  0.35f
	};

	unsigned int indicies[6] = {			// Defined indicies of drawing order.
		 0, 1, 2,
		 2, 3, 0 
	};

	{
		VertexBuffer vbo(tri2Dpositions, sizeof(tri2Dpositions));
		IndexBuffer ibo(indicies, 6);

		BufferLayout layout;
		layout.Push<float>(2);

		VertexArray va;
		va.AddBuffer(vbo, layout);

		Shader testShaders[2] =
		{
			Shader(GL_VERTEX_SHADER, "res/shaders/Basic.shader"),
			Shader(GL_FRAGMENT_SHADER, "res/shaders/Basic.shader")
		};

		GLProgram program(testShaders, 2);

		GLCall(int location = glGetUniformLocation(program.GetHandle(), "u_Color"));
		ASSERT(location != -1);
		GLCall(int location1 = glGetUniformLocation(program.GetHandle(), "u_WindowSize"));
		ASSERT(location1 != -1);
		GLCall(int location2 = glGetUniformLocation(program.GetHandle(), "u_SlopeBoundary"));
		ASSERT(location2 != -1);
		GLCall(int location4 = glGetUniformLocation(program.GetHandle(), "u_Switched"));
		ASSERT(location4 != -1);
		GLCall(int location5 = glGetUniformLocation(program.GetHandle(), "u_Color2"));
		ASSERT(location != -1);

		int windowWidth, windowHeight;
		glfwGetWindowSize(window, &windowWidth, &windowHeight);

		float slope = 0.0f;
		float slopeIncrement = 0.04f;
		bool switched = false;
		bool clockwise = true;
		unsigned long count = 0;
		Vector4 color1(0.0f, 1.0f, 0.0f, 1.0f);
		Vector4 color2(1.0f, 0.0f, 0.0f, 1.0f);

		program.Bind();

		// TODO: Find a way to abstract uniforms and continue with tutorial series.

		GLCall(glUniform4f(location, color1.x, color1.y, color1.z, color1.w));		// u_Color
		GLCall(glUniform4f(location5, color2.x, color2.y, color2.z, color2.w));		// u_Color2
		GLCall(glUniform2f(location1, windowWidth, windowHeight));

		/* Loop until the user closes the window */
		while (!glfwWindowShouldClose(window))
		{
			/* Render here */
			glClear(GL_COLOR_BUFFER_BIT);

			ibo.Bind();
			va.Bind();

			GLCall(glUniform1f(location2, slope));
			GLCall(glUniform1i(location4, switched));

			GLCall(glDrawElements(GL_TRIANGLES, 6, GL_UNSIGNED_INT, nullptr));		// Draws the currently bound array with specified draw mode using default shaders (if available)
																					// in the occasion that we aren't binding any custom shaders prior. 
			if (!clockwise)
			{
				slopeIncrement = abs(slopeIncrement);

				if (slope > M_PI)
				{
					slope = 0;
					switched = !switched;
					count++;
					if (count % 4 == 0) clockwise = !clockwise;
				}
			}
			else if (clockwise)
			{
				slopeIncrement = -abs(slopeIncrement);

				if (slope < 0)
				{
					slope = M_PI;
					switched = !switched;
					count++;
					if (count % 4 == 0) clockwise = !clockwise;
				}
			}

			slope += slopeIncrement;

			/* Swap front and back buffers */
			glfwSwapBuffers(window);

			/* Poll for and process events */
			glfwPollEvents();
		}
	}

	glfwTerminate();
	return 0;
}