#include "Renderer.h"
#include <GLFW/glfw3.h>
#include "IndexBuffer.h"
#include "VertexBuffer.h"
#include "VertexArray.h"
#include "BufferLayout.h"
#include "Shader.h"
#include "GLProgram.h"
#include "Uniform.h"
#include "Macros.h"

#define _USE_MATH_DEFINES
#include <math.h>

// TODO: Check in CodeReview and fix all the major issues (memory management and error checking) and all the stylistic and formating errors.

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

	float tri2Dpositions[8] = {				// Defined an array containing all our verticies.
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

		Shader testShaders[2] =										// Shader abstraction in use.
		{
			Shader(GL_VERTEX_SHADER, "res/shaders/Basic.shader"),
			Shader(GL_FRAGMENT_SHADER, "res/shaders/Basic.shader")
		};

		GLProgram program(testShaders, 2);							

		float slopeIncrement = 0.04f;
		bool clockwise = true;
		unsigned long count = 0;

		int windowWidth, windowHeight;
		glfwGetWindowSize(window, &windowWidth, &windowHeight);

		float color1[4] = { 0.0f, 1.0f, 0.0f, 1.0f };
		float color2[4] = { 1.0f, 0.0f, 0.0f, 1.0f };
		float windowSize[2] = { windowWidth, windowHeight };
		float slope = 0.0f;
		int switched = false;

		Uniform c1(color1, UniformType::FLOAT4, "u_Color", false);					// Uniform abstraction in use.
		Uniform c2(color2, UniformType::FLOAT4, "u_Color2", false);
		Uniform WindowSize(windowSize, UniformType::FLOAT2, "u_WindowSize", false);
		Uniform SlopeBounds(&slope, UniformType::FLOAT, "u_SlopeBoundary", false);
		Uniform ColorSwitched(&switched, UniformType::INT, "u_Switched", false);

		program.AttachUniform(c1);
		program.AttachUniform(c2);
		program.AttachUniform(WindowSize);
		program.AttachUniform(SlopeBounds);
		program.AttachUniform(ColorSwitched);

		Renderer renderer;

		/* Loop until the user closes the window */
		while (!glfwWindowShouldClose(window))
		{
			/* Render here */
			renderer.Clear();

			SlopeBounds.SetData(&slope);
			ColorSwitched.SetData(&switched);

			renderer.Draw(va, ibo, program);
																				
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