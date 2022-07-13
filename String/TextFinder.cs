using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace String
{
    internal static class TextFinder
    {
        public static List<KeyValuePair<string, int>> FindShortestSentence(string[] sentences)
        {
            string[] wordSeparators = { " ", "\n", };
            Dictionary<string, int> wordsAmountInSent = new Dictionary<string, int>();

            foreach (string sentence in sentences)
            {
                string[] words = sentence.Split(wordSeparators, StringSplitOptions.RemoveEmptyEntries);

                if (!wordsAmountInSent.ContainsKey(sentence) && words.Length != 0)
                {
                    wordsAmountInSent.Add(sentence, words.Length);
                }
            }
            List<int> wordsAmount = wordsAmountInSent.Select(keyValuePair => keyValuePair.Value).ToList();
            int min;
            if (wordsAmount.Count != 0)
            {
                min = wordsAmount.Min();
            }
            else
            {
                min = 0;
            }
            var minWordsSents = wordsAmountInSent.Where(keyValuePair => keyValuePair.Value == min).ToList();

            return minWordsSents;
        }

        public static List<KeyValuePair<string, int>> FindLongestSentence(string[] sentences)
        {
            Dictionary<string, int> charsAmountInSent = new Dictionary<string, int>();
            for (int i = 0; i < sentences.Length; i++)
            {
                if (!charsAmountInSent.ContainsKey(sentences[i]))
                {
                    charsAmountInSent.Add(sentences[i], sentences[i].Length);
                }
            }

            List<int> charsAmount = charsAmountInSent.Select(keyValuePair => keyValuePair.Value).ToList();
            int max;
            if (charsAmount.Count != 0)
            {
                max = charsAmount.Max();
            }
            else
            {
                max = 0;
            }
            var maxSymbolSents = charsAmountInSent.Where(keyValuePair => keyValuePair.Value == max).ToList();

            return maxSymbolSents;
        }

        public static List<KeyValuePair<char, int>> FindMostCommonChars(string text)
        {
            string lowerText = text.ToLower();

            SortedDictionary<char, int> sortedСharsDict = new SortedDictionary<char, int>();

            for (int i = 'a'; i <= 'z'; i++)
            {
                var count = lowerText.Count(x => x.CompareTo(Convert.ToChar(i)) == 0);
                sortedСharsDict.Add(Convert.ToChar(i), count);
            }

            List<int> counters = sortedСharsDict.Select(keyValuePair => keyValuePair.Value).ToList();

            int max = counters.Max();
            var maxСhars = sortedСharsDict.Where(keyValuePair => keyValuePair.Value == max).ToList();
            return maxСhars;
        }
    }
}
