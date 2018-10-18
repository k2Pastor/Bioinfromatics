#include  <iostream>
#include <string>

using namespace std;

int main()
{
	string MainString, SubString;
	int count = 0;

	getline(cin, MainString);
	cout << endl;
	getline(cin, SubString);

	for (int i = 0; i < MainString.length(); ++i)
	{
		if (MainString[i] == SubString[0])
			if (MainString.substr(i, SubString.length()) == SubString)
			{
				++count;
				//i += SubString.length() - 1;
			}
	}
	cout << count;
	return 0;
}

/*
int main()
{
const int size = 64;
char MainString [size] = "";
char SubString [size] = "";
int count = 0, k = 0;

cin.getline(MainString, size);
cout << endl;
cin.getline(SubString, size);

for (int i = 0; i < strlen(MainString); i++)
{

char tmp[size] = "";
k = 0;
if (MainString[i] == SubString[0])
{

int j = i;
while ((MainString[j] == SubString[k]))
{

tmp[k] = MainString[j];
j++;
k++;
}

if (!(strcmp(SubString, tmp)))
count++;

if (MainString[i] == MainString[i + 1])
i++;
}
}

cout << endl;
cout << count;
return 0;

} */
