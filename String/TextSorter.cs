using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace String
{
    internal static class TextSorter
    {
        public static SortedDictionary<string, int> CreateSortedWordsDictionary(List<string> wordsList)
        {
            SortedDictionary<string, int> wordsDict = new SortedDictionary<string, int>();
            Regex reg = new Regex(@"[0-9]");
            for (int i = 0; i < wordsList.Count; i++)
            {
                wordsList[i] = wordsList[i].ToLower();
                if (wordsDict.ContainsKey(wordsList[i]))
                {
                    wordsDict[wordsList[i]] = wordsDict[wordsList[i]] + 1;
                }
                else
                {
                    MatchCollection mc = reg.Matches(wordsList[i]);
                    if (mc.Count == 0)
                    {
                        wordsDict.Add(wordsList[i], 1);
                    }
                }
            }

            return wordsDict;
        }
    }
}
