#include "Camera.h"
#include "glm/glm.hpp"
#include "glm/gtc/matrix_transform.hpp"
#define GLM_ENABLE_EXPERIMENTAL
#include "glm/gtx/transform.hpp"

Camera::Camera(Vector4 worldPosition, float fov, Vector4 lookAt, GLFWwindow* window)
	: m_WorldPos(worldPosition), fov(fov), initialized(true)
{
	glfwGetWindowSize(window, &windowWidth, &windowHeight);
	projection = glm::perspective(fov, (float)windowWidth / (float)windowHeight, 0.1f, 100.0f);

	Look(lookAt);
}

Camera::Camera(Vector4 worldPosition, GLFWwindow * window)
	: initialized(true)
{
	glfwGetWindowSize(window, &windowWidth, &windowHeight);
	projection = glm::perspective(fov, (float)windowWidth / (float)windowHeight, 0.1f, 100.0f);
}

Camera::Camera(float fov, GLFWwindow * window)
	: fov(fov), initialized(true)
{
	glfwGetWindowSize(window, &windowWidth, &windowHeight);
	projection = glm::perspective(fov, (float)windowWidth / (float)windowHeight, 0.1f, 100.0f);
}

Camera::Camera(GLFWwindow * window)
	: initialized(true)
{
	glfwGetWindowSize(window, &windowWidth, &windowHeight);
	projection = glm::perspective(fov, (float)windowWidth / (float)windowHeight, 0.1f, 100.0f);
}

Camera::Camera()
{

}

Camera::~Camera()
{

}

void Camera::Update()
{
	view = glm::lookAt(glm::vec3(m_WorldPos.x, m_WorldPos.y, m_WorldPos.z), glm::vec3(lookPos.x, lookPos.y, lookPos.z), glm::vec3(0.0f, 1.0f, 0.0f));
}

void Camera::Initialize(GLFWwindow* window)
{
	initialized = true;
	glfwGetWindowSize(window, &windowWidth, &windowHeight);
	projection = glm::perspective(fov, (float)windowWidth / (float)windowHeight, 0.1f, 100.0f);
}
