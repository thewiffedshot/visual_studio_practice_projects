#include "TestDrawSphere.h"
#include <string>

test::TestDrawSphere::TestDrawSphere(GLFWwindow* window)
	: window(window)
{
	camera.Initialize(window);

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
	//sphereModel.GetProgram()->AttachUniform(*LightDistance);
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
	renderer.Draw(*sphereModel.GetVertexArray(), *sphereModel.GetIndexBuffer(), *sphereModel.GetProgram());
}

void test::TestDrawSphere::OnImGuiRender()
{
	
}

void test::TestDrawSphere::OnUpdate(float deltaTime)
{

}
