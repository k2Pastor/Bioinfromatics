#include <iostream>
#include <string>
#include <unordered_map>

using namespace std;

unordered_map<string, char> RNATranslationTable = { { "AAA", 'K' },{ "AAC", 'N' },{ "AAG", 'K' },{ "AAU", 'N' },{ "ACA", 'T' },
{ "ACC", 'T' },{ "ACG", 'T' },{ "ACU", 'T' },
{ "AGA", 'R' },{ "AGC", 'S' },{ "AGG", 'R' },{ "AGU", 'S' },{ "AUA", 'I' },{ "AUC", 'I' },{ "AUG", 'M' },{ "AUU", 'I' },
{ "CAA", 'Q' },{ "CAC", 'H' },{ "CAG", 'Q' },{ "CAU", 'H' },{ "CCA", 'P' },{ "CCC", 'P' },{ "CCG", 'P' },{ "CCU", 'P' },
{ "CGA", 'R' },{ "CGC", 'R' },{ "CGG", 'R' },{ "CGU", 'R' },{ "CUA", 'L' },{ "CUC", 'L' },{ "CUG", 'L' },{ "CUU", 'L' },
{ "GAA", 'E' },{ "GAC", 'D' },{ "GAG", 'E' },{ "GAU", 'D' },{ "GCA", 'A' },{ "GCC", 'A' },{ "GCG", 'A' },{ "GCU", 'A' },
{ "GGA", 'G' },{ "GGC", 'G' },{ "GGG", 'G' },{ "GGU", 'G' },{ "GUA", 'V' },{ "GUC", 'V' },{ "GUG", 'V' },{ "GUU", 'V' },
{ "UAA", ' ' },{ "UAC", 'Y' },{ "UAG", ' ' },{ "UAU", 'Y' },{ "UCA", 'S' },{ "UCC", 'S' },{ "UCG", 'S' },{ "UCU", 'S' },
{ "UGA", ' ' },{ "UGC", 'C' },{ "UGG", 'W' },{ "UGU", 'C' },{ "UUA", 'L' },{ "UUC", 'F' },{ "UUG", 'L' },{ "UUU", 'F' } };

 
string Reverse(string _pattern)
{
	string ReversePattern = "";

	for ( int i = 0; i < _pattern.length(); i++ )
	{
		switch (_pattern[i])
		{
			case 'A': ReversePattern = 'T' + ReversePattern; break;
			case 'T': ReversePattern = 'A' + ReversePattern; break;
			case 'C': ReversePattern = 'G' + ReversePattern; break;
			case 'G': ReversePattern = 'C' + ReversePattern; break;
		}
	}

	return ReversePattern;
}

string Translation(string _pattern)
{
	string Peptide = "";

	for (int i = 0; i < _pattern.length(); i += 3)
	{
		Peptide += RNATranslationTable.at(_pattern.substr( i, 3 ));
	}

	return Peptide;
}

string Transcription(string DNA)
{
	string RNA = "";

	for (int i = 0; i < DNA.length(); i++)
	{
		if (DNA[i] == 'T')
		{
			RNA.push_back('U');
		}

		else RNA.push_back(DNA[i]);
	}

	return RNA;
}

int main()
{
	string DNAText;
	string Peptide;
	string GeneticCode;

	getline(cin, DNAText);
	getline(cin, Peptide);

	for (int i = 0; i < DNAText.length() - Peptide.length() * 3 + 1; i++)
	{
		string RNA = Transcription(DNAText.substr(i, Peptide.length() * 3));
		string ReverseRNA = Transcription(Reverse(DNAText.substr(i, Peptide.length() * 3)));

		if (Peptide == Translation(RNA) || Peptide == Translation(ReverseRNA))
		{
			GeneticCode += DNAText.substr(i, Peptide.length() * 3) + '\n';
		}
	}


	cout << GeneticCode;

	return 0;
} 