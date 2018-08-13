#include "Model.h"
#include <fstream>
#include <vector>
#include <memory>
#include "glm/glm.hpp"
#include "glm/gtc/matrix_transform.hpp"

static void ParseData(const std::string& data, std::vector<unsigned long>* parsed);
static void ParseData(const std::string& data, std::vector<Vector3>* parsed);

Model::Model(const std::string & objPath)
{
	program = new GLProgram;
	program->Attach(shaders[0]);
	program->Attach(shaders[1]);

	std::string line;

	std::ifstream stream(objPath);

	std::stringstream vertexStream;
	std::stringstream normalStream;
	std::stringstream textureStream;   // TODO
	std::stringstream faceVertexIndexStream;
	std::stringstream faceNormalIndexStream;

	while (getline(stream, line))
	{
		if (line.find("v ") != std::string::npos)
		{
			std::string values = line.substr(2, line.size() - 2);

			vertexStream << values << ' ';
		}
		else if (line.find("vn ") != std::string::npos)
		{
			std::string values = line.substr(3, line.size() - 3);

			normalStream << values << ' ';
		}
		else if (line.find("f ") != std::string::npos)
		{
			int counter = 0;
			std::string values = line.substr(2, line.size() - 2);
			std::stringstream ss;

			bool skip = false;

			for (int i = 0; i < values.size(); i++)
			{
				if (!skip)
				{
					if (values[i] != '/')
					{
						ss << values[i];
					}
					else
					{
						skip = true;
						ss << ' ';

						continue;
					}
				}

				skip = false;
			}

			ss << ' ';

			for (char ch : ss.str())
			{
				if (ch == ' ')
				{
					counter++;

					if (counter % 2 == 0)
						faceVertexIndexStream << ch;
					else if (counter != 1)
						faceNormalIndexStream << ch;
				}
				else
				{
					if (counter % 2 == 0)
					{
						faceVertexIndexStream << ch;
					}
					else
					{
						faceNormalIndexStream << ch;
					}
				}
			}

			faceNormalIndexStream << ' ';
		}
	}

	Parse(vertexStream.str(), faceVertexIndexStream.str(), normalStream.str(), faceNormalIndexStream.str());
}

Model::Model(Vector4 worldPosition, const std::string & objPath)
	: m_WorldPos(worldPosition)
{
	program = new GLProgram;
	program->Attach(shaders[0]);
	program->Attach(shaders[1]);
	
	std::string line;

	std::ifstream stream(objPath);

	std::stringstream vertexStream;
	std::stringstream normalStream;
	std::stringstream textureStream;   // TODO
	std::stringstream faceVertexIndexStream;
	std::stringstream faceNormalIndexStream;

	while (getline(stream, line))
	{
		if (line.find("v ") != std::string::npos)
		{
			std::string values = line.substr(2, line.size() - 2);

			vertexStream << values << ' ';
		}
		else if (line.find("vn ") != std::string::npos)
		{
			std::string values = line.substr(3, line.size() - 3);

			normalStream << values << ' ';
		}
		else if (line.find("f ") != std::string::npos)
		{
			int counter = 0;
			std::string values = line.substr(2, line.size() - 2);
			std::stringstream ss;

			bool skip = false;

			for (int i = 0; i < values.size(); i++)
			{
				if (!skip)
				{
					if (values[i] != '/')
					{
						ss << values[i];
					}
					else
					{
						skip = true;
						ss << ' ';

						continue;
					}
				}

				skip = false;
			}

			ss << ' ';

			for (char ch : ss.str())
			{
				if (ch == ' ')
				{
					counter++;

					if (counter % 2 == 0)
						faceVertexIndexStream << ch;
					else if (counter != 1)
						faceNormalIndexStream << ch;
				}
				else
				{
					if (counter % 2 == 0)
					{
						faceVertexIndexStream << ch;
					}
					else
					{
						faceNormalIndexStream << ch;
					}
				}
			}

			faceNormalIndexStream << ' ';
		}
	}

	Parse(vertexStream.str(), faceVertexIndexStream.str(), normalStream.str(), faceNormalIndexStream.str());
}

Model::Model()
{
	program = new GLProgram;
	program->Attach(shaders[0]);
	program->Attach(shaders[1]);

	std::string objPath = "res/models/monkey.obj";

	std::string line;

	std::ifstream stream(objPath);

	std::stringstream vertexStream;
	std::stringstream normalStream;
	std::stringstream textureStream;   // TODO
	std::stringstream faceVertexIndexStream;
	std::stringstream faceNormalIndexStream;

	unsigned int faceCounter = 0;

	while (getline(stream, line))
	{
		if (line.find("v ") != std::string::npos)
		{
			std::string values = line.substr(2, line.size() - 2);

			vertexStream << values << ' ';
		}
		else if (line.find("vn ") != std::string::npos)
		{
			std::string values = line.substr(3, line.size() - 3);

			normalStream << values << ' ';
		}
		else if (line.find("f ") != std::string::npos)
		{
			int counter = 0;
			std::string values = line.substr(2, line.size() - 2);
			std::stringstream ss;

			bool skip = false;

			for (int i = 0; i < values.size(); i++)
			{
				if (!skip)
				{
					if (values[i] != '/')
					{
						ss << values[i];
					}
					else
					{
						skip = true;
						ss << ' ';

						continue;
					}
				}

				skip = false;
			}

			ss << ' ';

			for (char ch : ss.str())
			{
				if (ch == ' ')
				{
					counter++;

					if (counter % 2 == 0)
						faceVertexIndexStream << ch;
					else if (counter != 1)
						faceNormalIndexStream << ch;
				}
				else
				{
					if (counter % 2 == 0)
					{
						faceVertexIndexStream << ch;
					}
					else
					{
						faceNormalIndexStream << ch;
					}
				}
			}

			faceNormalIndexStream << ' ';
			faceCounter++;
		}
	}

	m_Faces = faceCounter;
	Parse(vertexStream.str(), faceVertexIndexStream.str(), normalStream.str(), faceNormalIndexStream.str());
}

void Model::Parse(const std::string& vertexData, const std::string& indexData, const std::string& normalData, const std::string& normalIndexData)
{
	std::vector<Vector3> verteces;
	ParseData(vertexData, &verteces);
	std::vector<Vector3> vNormals;
	ParseData(normalData, &vNormals);
	std::vector<unsigned long> indeces;
	ParseData(indexData, &indeces);
	std::vector<unsigned long> nIndeces;
	ParseData(normalIndexData, &nIndeces);
	
	m_Verteces = verteces.size();

	unsigned long counter = 0;

	std::unique_ptr<float> vertexArray(new float[18 * indeces.size()]);
	std::unique_ptr<unsigned int> indexArray(new unsigned int[indeces.size()]);
	float vData[3];
	float nData[3];

	for (unsigned int i = 0; i < indeces.size(); i++)
	{
		unsigned int* iPtr = indexArray.get() + i;
		*iPtr = indeces[i] - 1;
		Vector3 vertex = verteces[indeces[i] - 1];
		Vector3 vNormal = vNormals[nIndeces[i] - 1];

		vData[0] = vertex.x;
		vData[1] = vertex.y;
		vData[2] = vertex.z;

		nData[0] = vNormal.x;
		nData[1] = vNormal.y;
		nData[2] = vNormal.z;

		memcpy(vertexArray.get() + sizeof(vData) / sizeof(float) * counter, vData, sizeof(vData));
		counter++;
		memcpy(vertexArray.get() + sizeof(nData) / sizeof(float) * counter, nData, sizeof(nData));
		counter++;
	}

	vbo = new VertexBuffer(vertexArray.get(), 18 * indeces.size());
	ibo = new IndexBuffer(indexArray.get(), sizeof(unsigned int) * indeces.size());
	ibo->SetVertexCount(indeces.size());
	
	layout = new BufferLayout;
	layout->Push<float>(3);
	layout->Push<float>(3);
	
	va = new VertexArray;
	va->AddBuffer(*vbo, *layout);
}

static void ParseData(const std::string& data, std::vector<Vector3>* parsed)
{
	int counter = 0;
	float vData[3];

	std::stringstream ph;

	for (unsigned long i = 0; i < data.size(); i++)
	{
		if (data[i] == ' ')
		{
			vData[counter % 3] = std::stof(ph.str());
			counter++;
			ph.str("");

			if (counter % 3 == 0)
			{
				parsed->push_back({ vData[0], vData[1], vData[2] });
			}
		}
		else
		{
			ph << data[i];
		}
	}
}

static void ParseData(const std::string& data, std::vector<unsigned long>* parsed)
{
	std::stringstream ph;

	for (unsigned long i = 0; i < data.size(); i++)
	{
		if (data[i] == ' ')
		{
			float data = std::stof(ph.str());

			parsed->push_back(data);

			ph.str("");
		}
		else
		{
			ph << data[i];
		}
	}
}

Model::~Model()
{
	delete vbo;
	delete ibo;
	delete va;
	delete layout;
	delete program;
}

void Model::ChangeShaders(Shader * shaders, unsigned int count)
{
	program->Detach();
	program->Attach(shaders, count);
}
