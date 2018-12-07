using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task10
{
    class Program
    {
        static Dictionary<char, int> MassTable = new Dictionary<char, int>()
            {
                {'G', 57},  {'A', 71},  {'S', 87},  {'P', 97},  {'V', 99},
                {'T', 101}, {'C', 103}, {'I', 113}, {'L', 113}, {'N', 114},
                {'D', 115}, {'K', 128}, {'Q', 128}, {'E', 129}, {'M', 131},
                {'H', 137}, {'F', 147}, {'R', 156}, {'Y', 163}, {'W', 186}
            };

        static string CycloSpectrum(string peptide)
        {
            List<int> Spectrum = new List<int>();
            Spectrum.Add(0);

            int m = 0;
            foreach (var s in peptide)
            {
                Spectrum.Add(MassTable[s]);
                m += MassTable[s];
            }
            Spectrum.Add(m);

            string CycloPeptide = peptide + peptide;
            for (int i = 2; i < peptide.Length; i++)
            {
                for (int j = 0; j < peptide.Length; j++)
                {
                    string subPeptide = CycloPeptide.Substring(j, i);
                    int curMass = 0;

                    foreach (var s in subPeptide)
                    {
                        curMass += MassTable[s];
                    }
                    Spectrum.Add(curMass);
                }
            }

            Spectrum.Sort();
            return string.Join(" ", Spectrum);
        }

        static int CountScore(string peptide, string spectrum)
        {
            List<string> peptideMasses = CycloSpectrum(peptide).Split(' ').ToList();
            List<string> spectrumMasses = spectrum.Split(' ').ToList();

            int score = 0;
            foreach (var mass in peptideMasses)
            {
                if (spectrumMasses.Contains(mass))
                {
                    spectrumMasses.Remove(mass);
                    score++;
                }
            }

            return score;
        }
        static void Main(string[] args)
        {
            string Peptide = Console.ReadLine();
            string Spectrum = Console.ReadLine();

            Console.WriteLine(CountScore(Peptide, Spectrum));
            Console.ReadKey();
        }
    }
}