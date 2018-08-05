#include "Model.h"
#include <fstream>
#include <vector>
#include <memory>

static void ParseData(const std::string& data, std::vector<Vector3>* parsed);

Model::Model(const std::string & objectPath)
{

}

Model::Model(Vector3 worldPosition, const std::string & objectPath)
{

}

Model::Model()
{
	std::string objPath = "res/models/sphere.obj";

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

void Model::Parse(const std::string& vertexData, const std::string& indexData, const std::string& normalData, const std::string& normalIndexData)
{
	std::vector<Vector3> verteces;
	ParseData(vertexData, &verteces);
	std::vector<Vector3> vNormals;
	ParseData(normalData, &vNormals);
	std::vector<Vector3> indeces;
	ParseData(indexData, &indeces);
	std::vector<Vector3> nIndeces;
	ParseData(normalIndexData, &nIndeces);
	
	m_Faces = indeces.size();
	m_Verteces = verteces.size();

	unsigned long counter = 0;

	std::unique_ptr<float> vertexArray(new float[18 * indeces.size()]);
	float vData[3];
	float nData[3];

	for (unsigned int i = 0; i < m_Faces; i++)
	{
		Vector3* ptr = &indeces[i];
		Vector3* nPtr = &nIndeces[i];

		for (int j = 0; j < 3; j++)
		{
			float val = *((float*)(ptr) + j);
			int index = val - 1;

			vData[0] = verteces[index].x;
			vData[1] = verteces[index].y;
			vData[2] = verteces[index].z;

			val = *((float*)(nPtr) + j);
			index = val - 1;

			nData[0] = vNormals[index].x;
			nData[1] = vNormals[index].y;
			nData[2] = vNormals[index].z;


			memcpy(vertexArray.get() + sizeof(nData) / sizeof(float) * counter, vData, sizeof(vData));
			counter++;
			memcpy(vertexArray.get() + sizeof(nData) / sizeof(float) * counter, nData, sizeof(nData));
			counter++;
		}
	}

	vbo = new VertexBuffer(vertexArray.get(), 18 * m_Faces);
	ibo = new IndexBuffer;
	
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

Model::~Model()
{

}
