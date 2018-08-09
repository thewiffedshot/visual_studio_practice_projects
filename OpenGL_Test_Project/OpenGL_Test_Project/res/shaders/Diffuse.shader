#shader vertex
#version 330 core

layout(location = 0) in vec3 position_worldspace;
layout(location = 1) in vec3 vNormal_worldspace;

uniform mat4 u_viewMatrix;
uniform mat4 u_projMatrix;

out vec4 normal_cameraspace;
out vec4 pos_cameraspace;

void main()
{
	mat4 transformation = u_projMatrix * u_viewMatrix;
	vec4 position_cameraspace = transformation * vec4(position_worldspace, 1.0);
	gl_Position = position_cameraspace;
	normal_cameraspace = u_viewMatrix * vec4(vNormal_worldspace, 0.0);
	pos_cameraspace = position_cameraspace;
}

#shader fragment
#version 330 core

in vec4 normal_cameraspace;
in vec4 pos_cameraspace;

uniform vec4 u_MaterialDiffuseColor;
uniform vec4 u_LightColor;

void main()
{

}