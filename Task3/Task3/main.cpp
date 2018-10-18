#include <iostream>
#include <string>
#include <unordered_map>
using namespace std;

int main ()
{
	string MainString, ReverseString;

	getline(cin, MainString);

	ReverseString = MainString;
	//reverse(ReverseString.begin(), ReverseString.end());
	for (int i = 0; i < ReverseString.length(); i++)
		ReverseString[i] = MainString[MainString.length() - i - 1];

	cout << ReverseString;
	
	unordered_map< char, char> umap;

	umap['A'] = 'T';
	umap['T'] = 'A';
	umap['G'] = 'C';
	umap['C'] = 'G';

	

		for (int i = 0; i < ReverseString.length(); i++)
		{
			ReverseString[i] = umap[ReverseString[i]];
		}
	
		//cout << ReverseString << endl;
	return 0;
}