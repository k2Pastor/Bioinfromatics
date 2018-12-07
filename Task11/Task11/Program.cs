using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task11
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
        static int CountMass(string peptide)
        {
            int mass = 0;
            foreach (var s in peptide)
            {
                mass += MassTable[s];
            }

            return mass;
        }
        static List<string> Expand(List<string> peptides)
        {
            List<string> newPeptides = new List<string>();

            foreach (var peptide in peptides)
            {
                foreach (var p in MassTable.Keys)
                {
                    newPeptides.Add(peptide + p);
                }
            }
            return newPeptides;
        }
        static string LinearSpectrum(string peptide)
        {
            if (peptide.Length == 1)
                return MassTable[peptide[0]].ToString();

            List<int> outMasses = new List<int>() { 0 };
            int m = 0;

            foreach (var s in peptide)
            {
                outMasses.Add(MassTable[s]);
                m += MassTable[s];
            }
            outMasses.Add(m);

            string cyclePeptide = peptide + peptide;

            for (int i = 2; i < peptide.Length; i++)
            {
                for (int j = 0; j < peptide.Length - i; j++)
                {
                    string subpeptide = cyclePeptide.Substring(j, i);
                    int curMass = 0;

                    foreach (var s in subpeptide)
                    {
                        curMass += MassTable[s];
                    }
                    outMasses.Add(curMass);
                }
            }

            outMasses.Sort();

            return string.Join(" ", outMasses);
        }
        static int CountScore(string peptide, string spectrum)
        {
            List<string> peptideMasses = LinearSpectrum(peptide).Split(' ').ToList();
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
        static List<string> Trim(List<string> leaderboard, string spectrum, int n)
        {
            leaderboard.Sort((a, b) => CountScore(b, spectrum).CompareTo(CountScore(a, spectrum)));
            if (leaderboard.Count > n)
            {
                int last = n;
                for (int i = n; i < leaderboard.Count; i++)
                {
                    if (CountScore(leaderboard[n - 1], spectrum) == CountScore(leaderboard[i], spectrum))
                    {
                        last = i;
                    }
                    else break;
                }

                leaderboard = leaderboard.Take(last + 1).ToList();
            }

            return leaderboard;
        }
        static void Main(string[] args)
        {
            Console.SetIn(new StreamReader(Console.OpenStandardInput(),
                               Console.InputEncoding,
                               false,
                               bufferSize: 1024));

            int N = int.Parse(Console.ReadLine());
            string Spectrum = Console.ReadLine();
            int ParentMass = int.Parse(Spectrum.Split(' ').Last());

            List<string> Board = new List<string>() { "" };
            string ForwardPeptide = "";

            while (Board.Count() > 0)
            {
                Board = Expand(Board);
                List<string> immutablePeptides = new List<string>(Board);
                foreach (var peptide in immutablePeptides)
                {
                    if (CountMass(peptide) == ParentMass)
                    {
                        if (CountScore(peptide, Spectrum) > CountScore(ForwardPeptide, Spectrum))
                        {
                            ForwardPeptide = peptide;
                        }
                    }
                    else if (CountMass(peptide) > ParentMass)
                    {
                        Board.Remove(peptide);
                    }
                }

                Board = Trim(Board, Spectrum, N);
            }

            List<string> outputMasses = new List<string>();
            foreach (var s in ForwardPeptide)
            {
                outputMasses.Add(MassTable[s].ToString());
            }

            Console.WriteLine(string.Join("-", outputMasses));
            Console.ReadKey();
        }
    }
}
