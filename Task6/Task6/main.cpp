#include <iostream>

using namespace std;

int main()
{
	long int LengthOfCyclicPeptide;
	cin >> LengthOfCyclicPeptide;

	cout << LengthOfCyclicPeptide * (LengthOfCyclicPeptide - 1);

	return 0;
}