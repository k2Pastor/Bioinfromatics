#include <iostream>
#include <vector>
#include <unordered_map>
using namespace std;



int main()
{
	vector<int> VectorOfMasses = { { 57, 71, 87, 97, 99, 101, 103, 113, 114, 115, 128, 129, 131, 137, 147, 156, 163, 186 } };
	unordered_map<int, uint64_t> N = { { 0, 1 } };

	int Mass;
	cin >> Mass;

	for (int i = 57; i <= Mass; i++)
	{
		N[i] = 0;

		for (int j = 0; j < 18; j++)
		{
			if (N.find(i - VectorOfMasses[j]) != N.end())
			{
				N[i] += N[i - VectorOfMasses[j]];
			}
		}
	}

	cout << N[Mass];

	return 0;
} 

