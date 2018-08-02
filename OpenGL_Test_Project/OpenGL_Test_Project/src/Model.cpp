#include "Model.h"
#include <fstream>
#include <vector>

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
	std::stringstream faceNormalStream;

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
			std::string values = line.substr(2, line.size() - 2);

			bool skip = false;

			for (int i = 0; i < values.size(); i++)
			{
				if (!skip)
				{
					if (values[i] == '/')
						skip = true;
		
					else if (values[i] != ' ')
						faceNormalStream << values[i];
				}

				if (skip == true && values[i] == ' ')
				{
					skip = false;
					faceNormalStream << ' ';
				}
			}

			faceNormalStream << ' ';
		}
	}

	Parse(vertexStream.str(), faceNormalStream.str(), normalStream.str());
}

void Model::Parse(const std::string& vertexData, const std::string& normalData, const std::string& faceNormalData)
{
	std::vector<float> verteces;
	std::string value;

	for (char ch : vertexData)
	{
		if (ch == ' ')
		{
			verteces.push_back(std::stof(value, 0));
			value = "";
		}
		else
		{
			value += ch;
		}
	}

	for (auto ch : faceNormalData)
	{
		
	}
}

Model::~Model()
{

}
