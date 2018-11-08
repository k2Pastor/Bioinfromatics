#include <iostream>
#include <unordered_map>
#include <string>
#include <vector> 
#include <algorithm>
#include <iterator>

using namespace std;

unordered_map<char, int> MassTable = { 
{ 'G', 57 },
{ 'A', 71 },
{ 'S', 87 },
{ 'P', 97 },
{ 'V', 99 },
{ 'T', 101 },
{ 'C', 103 },
{ 'I', 113 },
{ 'L', 113 },
{ 'N', 114 },
{ 'D', 115 },
{ 'K', 128 },
{ 'Q', 128 },
{ 'E', 129 },
{ 'M', 131 },
{ 'H', 137 },
{ 'F', 147 },
{ 'R', 156 },
{ 'Y', 163 },
{ 'W', 186 } 
};

int CountMass(string _pattern)
{
	int Mass = 0;

	for (int i = 0; i < _pattern.length(); i++)
	{
		Mass += MassTable.at(_pattern[i]);
	}

	return Mass;
}

int main()
{
	vector<int> Masses{ 0 };
	

	string Peptide;
	string tmp;

	getline(cin, Peptide);
	
	tmp = Peptide;

	for (int i = 0; i < Peptide.length(); i++)
	{
		tmp.push_back(Peptide[i]);
	}

	for (int i = 1; i < Peptide.length(); i++)
	{
		for (int j = 0; j < Peptide.length(); j++)
		{
			Masses.push_back(CountMass(tmp.substr(j, i)));

		}
	}

	Masses.push_back(CountMass(Peptide));

	sort(Masses.begin(), Masses.end());
	copy(Masses.begin(), Masses.end(), ostream_iterator<int>(cout, " "));

	return 0;
}


