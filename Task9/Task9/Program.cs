using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task9
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
            int Mass = 0;
            foreach (var s in peptide)
            {
                Mass += MassTable[s];
            }
            return Mass;
        }
        static List<string> Expand(List<string> peptides)
        {
            List<string> newPeptides = new List<string>();

            foreach (var peptide in peptides)
            {
                foreach (var k in MassTable.Keys)
                {
                    newPeptides.Add(peptide + k);
                }
            }
            return newPeptides;
        }
        static string CycloSpectrum(string peptide)
        {
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
                for (int j = 0; j < peptide.Length; j++)
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

        static bool IsConsistent(string peptide, string spectrum)
        {
            List<string> specMass = spectrum.Split(' ').ToList();
            List<string> peptideMass = LinearSpectrum(peptide).Split(' ').ToList();

            foreach (var m in peptideMass)
            {
                if (!specMass.Contains(m))
                {
                    return false;
                }

            }

            return true;
        }


        static void Main(string[] args)
        {
            string Spectrum = Console.ReadLine();
            int ParentMass = int.Parse(Spectrum.Split(' ').Last());

            List<string> peptides = new List<string>() { "" };
            List<string> outputPeptides = new List<string>();

            while (peptides.Count > 0)
            {
                peptides = Expand(peptides);
                List<string> immutablePeptides = new List<string>(peptides);
                foreach (var peptide in immutablePeptides)
                {
                    if (CountMass(peptide) == ParentMass)
                    {
                        if (CycloSpectrum(peptide) == Spectrum)
                        {
                            outputPeptides.Add(peptide);
                        }
                        peptides.Remove(peptide);
                    }
                    else if (!IsConsistent(peptide, Spectrum))
                    {
                        peptides.Remove(peptide);
                    }
                }
            }

            List<string> outputMasses = new List<string>();
            foreach (var p in outputPeptides)
            {
                List<string> m = new List<string>();
                foreach (var s in p)
                {
                    m.Add(MassTable[s].ToString());
                }

                outputMasses.Add(string.Join("-", m));
            }

            Console.WriteLine(string.Join(" ", outputMasses.Distinct()));
            Console.ReadKey();
        }
    }
}
