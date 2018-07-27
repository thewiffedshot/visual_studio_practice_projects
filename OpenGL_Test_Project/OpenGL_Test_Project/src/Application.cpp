#include "Renderer.h"
#include <GLFW/glfw3.h>
#include "Macros.h"
#include "imgui\imgui.h"
#include "imgui\imgui_impl_opengl3.h"
#include "imgui\imgui_impl_glfw.h"
#include "tests\Test.h"
#include "tests\TestShaderBlending.h"

#define _USE_MATH_DEFINES
#include <math.h>

int main(void)
{
	GLFWwindow* window;

	/* Initialize the library */
	if (!glfwInit())
		return -1;

	//glfwWindowHint(GLFW_CONTEXT_VERSION_MAJOR, 3);
	//glfwWindowHint(GLFW_CONTEXT_VERSION_MINOR, 3);
	//glfwWindowHint(GLFW_OPENGL_PROFILE, GLFW_OPENGL_CORE_PROFILE);

	/* Create a windowed mode window and its OpenGL context */
	window = glfwCreateWindow(1280, 720, "OpenGL_Test", NULL, NULL);				// Window with OpenGL context is created but context is not set to current.

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

	ImGui::CreateContext();

	ImGui_ImplGlfw_InitForOpenGL(window, true);
	ImGui_ImplOpenGL3_Init("#version 330");										// ImGui is initialized with a hardcoded version of GLSL. Keep this in mind if having compatibility issues.

	ImGui::StyleColorsDark();

	GLCall(glEnable(GL_BLEND));													// Enable blending.
	GLCall(glBlendFunc(GL_SRC_ALPHA, GL_ONE_MINUS_SRC_ALPHA));					// Set blending function to enable transparency by alpha difference.

	Renderer renderer;
	test::TestShaderBlending test(window);

	while (!glfwWindowShouldClose(window))
	{
		renderer.Clear();

		ImGui_ImplOpenGL3_NewFrame();
		ImGui_ImplGlfw_NewFrame();
		ImGui::NewFrame();

		test.OnImGuiRender();

		ImGui_ImplOpenGL3_RenderDrawData(ImGui::GetDrawData());

		test.OnRender(renderer);

		glfwSwapBuffers(window);
		glfwPollEvents();
	}

	ImGui_ImplOpenGL3_Shutdown();
	ImGui_ImplGlfw_Shutdown();
	ImGui::DestroyContext();

	glfwTerminate();
	return 0;
}