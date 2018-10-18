#include <iostream>
#include <string>

using namespace std;

int SearchOfSubstringEntries(string _MainString, string _SubString, int pos)
{
	int _count = 0;

	for (int i = pos; i < _MainString.length(); ++i)
	{
		if (_MainString[i] == _SubString[0])
		{
			if (_MainString.substr(i, _SubString.length()) == _SubString)
			{
				++_count;
				//i += _SubString.length() - 1;
			}
		}
	}

	return _count;
}



int main()
{
	int size = 100000;
	int count, max_count = 1 , num = 1, len = 0;


	string MainString;
	string *tmp = new string [size];
	int *FreqUsed = new int [size];
	int k;

	getline(cin, MainString);
	cout << endl;
	cin >> k;
	cout << endl;

	
	for (int i = 0; i < MainString.length(); ++i)
	{
		
		tmp[i] = MainString.substr(i, k);

		if (tmp[i].length() == k)
		{
			count = SearchOfSubstringEntries(MainString, tmp[i], i);
			
				if (count == max_count)
				{
					FreqUsed[len] = i;
					len++;
				}
		

			if (count > max_count)
			{
				max_count = count;
				num = i;
				len = 1;
				FreqUsed[0] = i;
			}
		}
	}
	
	for (int i = 0; i < len; i++)
		cout << tmp[FreqUsed[i]] << endl;


	return 0; 
} 
