using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task12
{
    class Program
    {

        static void get_all_words(ref List<string> words, string alphabet, int length, string prefix)
        {
            if (length == 0)
            {
                words.Add(prefix);
            }
            else
            {
                foreach (char it in alphabet)
                {
                    get_all_words(ref words, alphabet, length - 1, prefix + it);
                }
            }
        }


        static List<string> get_all_words(string alphabet, int length)
        {
            List<string> words = new List<string>((int)Math.Pow(4, length));
            get_all_words(ref words, alphabet, length, "");
            return words;
        }

        static bool IsAcceptableContradictions(string original, string replica, int AcceptableContradictions)
        {
            int length = original.Length;

            int mismatches = 0;
            for (int i = 0; i < length; i++)
            {
                if (original[i] != replica[i])
                {
                    mismatches++;
                }

                if (mismatches > AcceptableContradictions)
                {
                    return false;
                }
            }

            return true;
        }
        static List<string> GetAllKDMotifs(string kMer, int validMismatches)
        {
            string alphabet = "AGCT";
            List<string> patterns = new List<string>();

            foreach (var item in get_all_words(alphabet, kMer.Length))
            {
                if (IsAcceptableContradictions(item.ToString(), kMer, validMismatches))
                {
                    patterns.Add(item.ToString());
                }
            }

            return patterns;
        }

        static void Main(string[] args)
        {
            string[] tokens = Console.ReadLine().Split(' ');
            int k = int.Parse(tokens[0]);
            int q = int.Parse(tokens[1]);

            string buf = "";
            while (true)
            {
                string s = Console.ReadLine();
                if (string.IsNullOrEmpty(s))
                    break;

                buf += s + ' ';
            }

            string[] dna = buf.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            List<string> patterns = new List<string>();

            foreach (string src in dna)
            {
                int length = src.Length;
                for (int i = 0; i < length - k + 1; i++)
                {
                    string kMer = src.Substring(i, k);

                    foreach (string pattern in GetAllKDMotifs(kMer, q))
                    {
                        int num = 0;
                        foreach (string substring in dna)
                        {
                            for (int j = 0; j < length - k + 1; j++)
                            {
                                if (IsAcceptableContradictions(substring.Substring(j, k), pattern, q))
                                {
                                    num++;
                                    break;
                                }
                            }
                        }

                        if (num == dna.Length)
                        {
                            patterns.Add(pattern);
                        }
                    }
                }
            }

            patterns = patterns.Distinct().ToList();

            Console.WriteLine(string.Join(" ", patterns));
            Console.ReadKey();
        }
    }
}