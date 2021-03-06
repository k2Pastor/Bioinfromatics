﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task13
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

        static int hamming(string str1, string str2)
        {
            int num = 0;
            int length = str1.Length;

            for (int i = 0; i < length; i++)
            {
                if (str1[i] != str2[i])
                {
                    num++;
                }
            }

            return num;
        }
        static int d(string pattern, string text)
        {
            int length = text.Length;
            int k = pattern.Length;

            List<int> dist = new List<int>();

            for (int i = 0; i < length - k + 1; i++)
            {
                dist.Add(hamming(pattern, text.Substring(i, k)));
            }

            return dist.Min();
        }
        static int DDNA(string pattern, string[] dna)
        {
            int sum = 0;

            foreach (string dnai in dna)
            {
                sum += d(pattern, dnai);
            }

            return sum;
        }
        static string MedianString(string[] dna, int k)
        {
            int distance = int.MaxValue;
            string median = "";
            List<string> allKmers = get_all_words("AGCT", k);

            foreach (string kmer in allKmers)
            {
                if (distance > DDNA(kmer, dna))
                {
                    distance = DDNA(kmer, dna);
                    median = kmer;
                }
            }

            return median;
        }
        static void Main(string[] args)
        {
            int k = int.Parse(Console.ReadLine());

            string buf = "";
            while (true)
            {
                string s = Console.ReadLine();
                if (string.IsNullOrEmpty(s))
                    break;

                buf += s + ' ';
            }

            string[] dna = buf.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
         

            Console.WriteLine(MedianString(dna, k));
            Console.ReadKey();
        }
    }
}
