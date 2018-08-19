#include "TestDrawSphere.h"
#include <string>

test::TestDrawSphere::TestDrawSphere(GLFWwindow* window, ImGuiContext* gui)
	: window(window), guiContext(gui)
{
	camera.Initialize(window);
	glEnable(GL_CULL_FACE);
	//glFrontFace(GL_CW);
	glEnable(GL_DEPTH_TEST);
	glDepthFunc(GL_LESS);

	ViewMatrix = new Uniform(&camera.GetViewMatrix()[0][0], fMAT4x4, "u_viewMatrix", false);
	ProjMatrix = new Uniform(&camera.GetProjectionMatrix()[0][0], fMAT4x4, "u_projMatrix", false);
	LightPos = new Uniform(&light.m_WorldPos, FLOAT3, "u_lightPos", false);
	MaterialColor = new Uniform(&sphereModel.material.diffuseColor, FLOAT4, "u_MaterialDiffuseColor", false);
	LightColor = new Uniform(&light.lightColor, FLOAT4, "u_LightColor", false);
	LightDistance = new Uniform(&light.distance, FLOAT, "u_LightDistance", false);
	LightPower = new Uniform(&light.lightEnergy, FLOAT, "u_LightPower", false);

	sphereModel.GetProgram()->Bind();
	sphereModel.GetProgram()->AttachUniform(*ViewMatrix);
	sphereModel.GetProgram()->AttachUniform(*ProjMatrix);
	sphereModel.GetProgram()->AttachUniform(*LightPos);
	sphereModel.GetProgram()->AttachUniform(*MaterialColor);
	sphereModel.GetProgram()->AttachUniform(*LightColor);
	sphereModel.GetProgram()->AttachUniform(*LightDistance);
	sphereModel.GetProgram()->AttachUniform(*LightPower);
}

test::TestDrawSphere::~TestDrawSphere()
{
	delete ViewMatrix;
	delete ProjMatrix;
	delete LightPos;
	delete MaterialColor;
	delete LightColor;
	delete LightDistance;
	delete LightPower;
}

void test::TestDrawSphere::OnRender(const Renderer& renderer)
{
	camera.Update();
	renderer.Draw(*sphereModel.GetVertexArray(), *sphereModel.GetIndexBuffer(), *sphereModel.GetProgram());
}

Vector4 translation = { 0.0f, 0.0f, 0.0f, 0.0f };
Vector4 look = { 0.0f, 0.0f, 0.0f, 0.0f };
float color[4] = { 1.0f, 0.0f, 1.0f, 1.0f };

void test::TestDrawSphere::OnImGuiRender()
{
	ImGui::SetCurrentContext(guiContext);

	ImGui::Begin("Controls.");

	ImGui::Text("Use this form to control parameters.");

	ImGui::ColorEdit4("Material Color: ", color);

	ImGui::SliderFloat("Light X: ", &light.m_WorldPos.x, -200.0f, 200.0f);
	ImGui::SliderFloat("Light Y: ", &light.m_WorldPos.y, -200.0f, 200.0f);
	ImGui::SliderFloat("Light Z: ", &light.m_WorldPos.z, -200.0f, 200.0f);

	ImGui::SliderFloat("Camera X: ", &translation.x, -200.0f, 200.0f);
	ImGui::SliderFloat("Camera Y: ", &translation.y, -200.0f, 200.0f);
	ImGui::SliderFloat("Camera Z: ", &translation.z, -200.0f, 200.0f);
	translation.w = 1.0f;

	ImGui::SliderFloat("Look X: ", &look.x, -200.0f, 200.0f);
	ImGui::SliderFloat("Look Y: ", &look.y, -200.0f, 200.0f);
	ImGui::SliderFloat("Look Z: ", &look.z, -200.0f, 200.0f);
	look.w = 1.0f;


	LightPos->SetData(&light.m_WorldPos);
	MaterialColor->SetData(&color);
	camera.Look(look);
	camera.Translate(translation);
	ViewMatrix->SetData(&camera.GetViewMatrix()[0][0]);

	ImGui::Text("Application average %.3f ms/frame (%.1f FPS)", 1000.0f / ImGui::GetIO().Framerate, ImGui::GetIO().Framerate);
	ImGui::End();
}

void test::TestDrawSphere::OnUpdate(float deltaTime)
{

}
