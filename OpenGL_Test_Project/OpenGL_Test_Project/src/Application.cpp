#include <GL/glew.h>
#include <GLFW/glfw3.h>
#include <iostream>
#include <fstream>
#include <string>
#include <sstream>

#define _USE_MATH_DEFINES
#include <math.h>

// GL function calls error checking.
#ifdef _DEBUG
	#define ASSERT(x)\
	 if(!(x)) __debugbreak();
	#define GLCall(x) GLClearError(); x; ASSERT(GLCheckError(#x, __FILE__, __LINE__))
#else
	#define ASSERT(x) x;
	#define GLCall(x) x;
#endif

struct ShaderProgramSource
{
	std::string VertexSource;
	std::string FragmentSource;
};

struct Vector4
{
	float x, y, z, w;

	Vector4(float x, float y, float z, float w)
		: x(x), y(y), z(z), w(w)
	{

	}
};

static void GLClearError()
{
	while (glGetError() != GL_NO_ERROR);
}

static bool GLCheckError(const char* functionLog, const char* sourceFile, int line)
{
	while (GLenum error = glGetError())
	{
		std::cout << "\n[OpenGL Error " << error << "]: " << functionLog << " : " << sourceFile << " : " << line << std::endl;
		return false;
	}
	return true;
}

static ShaderProgramSource ParseShader(const std::string& filepath)
{
	std::ifstream stream(filepath);

	enum class ShaderType
	{
		NONE = -1, VERTEX = 0, FRAGMENT = 1
	};

	std::string line;
	std::stringstream stringStream[2];

	ShaderType type = ShaderType::NONE;

	while (getline(stream, line))
	{
		if (line.find("#shader") != std::string::npos)
		{
			if (line.find("vertex") != std::string::npos)
			{
				type = ShaderType::VERTEX;
			}
			else if (line.find("fragment") != std::string::npos)
			{
				type = ShaderType::FRAGMENT;
			}
		}
		else
		{
			stringStream[(int)type] << line << "\n"; 
			
		}
	}

	return { stringStream[0].str(), stringStream[1].str() };
}

static unsigned int CompileShader(unsigned int type, const std::string& source)
{
	unsigned int id = glCreateShader(type);          // Create a shader of given type and assign it a handle.
	const char* src = source.c_str();				 // Create a pointer to the beginning adress of the std::string, so basically a c_str...
	GLCall(glShaderSource(id, 1, &src, nullptr));    // Give glShaderSource the adress to the 'src' pointer. glShaderSource is called before compiling a shader.
	GLCall(glCompileShader(id));

	// TODO: Syntax error handling...
	// Here we go...

	int result;
	GLCall(glGetShaderiv(id, GL_COMPILE_STATUS, &result));  // glGetShaderiv is basically a debugging multitool and can return diagnostical data based on the GL definition you give it.
															// Here it returns compilation status and assigns it to 'result'...

	if (result == GL_FALSE)									// If 'result' is false then we need to get the compiler error message.
	{
		int length;
		GLCall(glGetShaderiv(id, GL_INFO_LOG_LENGTH, &length));			 // Store the length of the log in 'length'.
		
		char* message = (char*)(alloca(length * sizeof(char)));		     // Allocate the needed space in the stack for the error message string taking into account 'length' and get the pointer to it. 
		GLCall(glGetShaderInfoLog(id, length, &length, message));		 // Use glGetShaderInfoLog to output the message into our allocated memory.

		std::cout << "Failed to compile " << (type == GL_VERTEX_SHADER ? "vertex" : "fragment") << " shader" << std::endl;  // Print out said error message.
		std::cout << message << std::endl;

		GLCall(glDeleteShader(id));  // Delete the shader seeming as the function will not return proper anyway...
		return 0;
	}

	return id;
}

static unsigned int CreateShader(const std::string& vertexShader, const std::string& fragmentShader) // This is sort of like a utility function for better structured code.
{
	unsigned int program = glCreateProgram();									// Create program first and give it a handle.
	unsigned int vShader = CompileShader(GL_VERTEX_SHADER, vertexShader);		// Compile shader of type GL_VERTEX_SHADER with it's respective source code as a string.
	unsigned int fShader = CompileShader(GL_FRAGMENT_SHADER, fragmentShader);   // Compile shader of type GL_FRAGMENT_SHADER with it's respective source code as a string.

	GLCall(glAttachShader(program, vShader));  // Attach both shaders to our program.
	GLCall(glAttachShader(program, fShader));

	GLCall(glLinkProgram(program));			   // Link the program to our current context.
	GLCall(glValidateProgram(program));	       // Validate the program.

	GLCall(glDeleteShader(vShader));		   // Delete the shaders after they are compiled and attached to our program.
	GLCall(glDeleteShader(fShader));		   // NOTE: This does not delete the source code.

	return program;
}

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
	window = glfwCreateWindow(640, 480, "Hello World", NULL, NULL);  // Window with OpenGL context is created but context is not set to current.
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

	ShaderProgramSource shadersSource = ParseShader("res/shaders/Basic.shader");

	std::cout << "VERTEX:\n" << shadersSource.VertexSource << "FRAGMENT:\n" << shadersSource.FragmentSource << std::endl;

	unsigned int shader = CreateShader(shadersSource.VertexSource, shadersSource.FragmentSource);			// Create both our shaders using the respective source code strings.
	GLCall(glUseProgram(shader));																			// Bind the shader to the current context.

	std::cout << glGetString(GL_VERSION) << std::endl;														// Printing out OpenGL version...

	float tri2Dpositions[8] = {																				// Defined an array containing all our verticies for a simple triangle in this case.
		-0.4f, -0.35f,
		 0.8f, -0.35f,
		 0.4f,  0.35f,
		-0.8f,  0.35f
	};

	unsigned int indicies[6] = {
		 0, 1, 2,
		 2, 3, 0 
	};

	GLCall(int location = glGetUniformLocation(shader, "u_Color"));
	ASSERT(location != -1);
	GLCall(int location1 = glGetUniformLocation(shader, "u_WindowSize"));
	ASSERT(location1 != -1);
	GLCall(int location2 = glGetUniformLocation(shader, "u_SlopeBoundary"));
	ASSERT(location2 != -1);
	//GLCall(int location3 = glGetUniformLocation(shader, "u_Pi"));
	//ASSERT(location3 != -1);
	GLCall(int location4 = glGetUniformLocation(shader, "u_Switched"));
	ASSERT(location4 != -1);
	GLCall(int location5 = glGetUniformLocation(shader, "u_Color2"));
	ASSERT(location != -1);

	unsigned int vao;
	GLCall(glGenVertexArrays(1, &vao));
	GLCall(glBindVertexArray(vao));

	unsigned int buffer;																		// Variable created for our buffer's id.
	GLCall(glGenBuffers(1, &buffer));															// Generate the buffer and store its given ID in 'buffer' unsigned int.

	GLCall(glBindBuffer(GL_ARRAY_BUFFER, buffer));												// Bind the buffer to this specific purpose (target). Any other buffer previously bound to this target would be unbound 
																								// (OpenGL is currently working with our buffer corresponding to the ID stored in 'buffer').

	GLCall(glBufferData(GL_ARRAY_BUFFER, 8 * sizeof(float), tri2Dpositions, GL_STATIC_DRAW));   // Tell OpenGL how to interpret the data in the specified target array. This function assumes we have already bound a buffer to the specified target (in this case: GL_ARRAY_BUFFER).

	GLCall(glEnableVertexAttribArray(0));														// Enable the vertex attribute we are about to define.
	GLCall(glVertexAttribPointer(0, 2, GL_FLOAT, GL_FALSE, sizeof(float) * 2, 0)); 		        // Defining the position attribute. Last parameter needs to be cast as (const void*) if it's any value different than 0.

	unsigned int ibo;																	
	GLCall(glGenBuffers(1, &ibo));

	GLCall(glBindBuffer(GL_ELEMENT_ARRAY_BUFFER, ibo));											// Bind the ibo to the GL_ELEMENT_ARRAY_BUFFER place.									

	GLCall(glBufferData(GL_ELEMENT_ARRAY_BUFFER, 6 * sizeof(unsigned int), indicies, GL_STATIC_DRAW));

	GLCall(glBindVertexArray(0));
	GLCall(glBindBuffer(GL_ARRAY_BUFFER, 0));
	GLCall(glBindBuffer(GL_ELEMENT_ARRAY_BUFFER, 0));
	GLCall(glUseProgram(0));


	int windowWidth, windowHeight;
	glfwGetWindowSize(window, &windowWidth, &windowHeight);

	float slope = 0.0f;
	float slopeIncrement = 0.04f;
	bool switched = false;
	bool clockwise = true;
	unsigned long count = 0;
	Vector4 color1(0.0f, 1.0f, 0.0f, 1.0f);
	Vector4 color2(1.0f, 0.0f, 0.0f, 1.0f);

	/* Loop until the user closes the window */
	while (!glfwWindowShouldClose(window))
	{
		/* Render here */
		glClear(GL_COLOR_BUFFER_BIT);

		GLCall(glUseProgram(shader));
		GLCall(glUniform4f(location, color1.x, color1.y, color1.z, color1.w));		// u_Color
		GLCall(glUniform4f(location5, color2.x, color2.y, color2.z, color2.w));		// u_Color2
		GLCall(glUniform2f(location1, windowWidth, windowHeight));
		GLCall(glUniform1f(location2, slope));
		//GLCall(glUniform1f(location3, M_PI));
		GLCall(glUniform1i(location4, switched));

		GLCall(glBindBuffer(GL_ARRAY_BUFFER, buffer));
		GLCall(glBindBuffer(GL_ELEMENT_ARRAY_BUFFER, ibo));
		GLCall(glBindVertexArray(vao));
		
		GLCall(glDrawElements(GL_TRIANGLES, 6, GL_UNSIGNED_INT, nullptr));		// Draws the currently bound array with specified draw mode using default shaders (if available)
																				// in the occasion that we aren't calling 'glUseProgram' on any custom shaders prior. 
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

	GLCall(glDeleteProgram(shader));

	glfwTerminate();
	return 0;
}