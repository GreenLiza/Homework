using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace String
{
    internal static class TextParser
    {
        public static string[] GetSentences(string text)
        {
            text = text.Replace("--", " ");
            string[] sentenceSeparators = { ". ", "! ", "? ", "\n", "... ", ".\"", "?\"", "!\"", ".\'", "?\'", "!\'", ".\n", ".\t", "?\n", "!\n" };
            string[] sentences = text.Split(sentenceSeparators, StringSplitOptions.RemoveEmptyEntries);

            return sentences;
        }

        public static List<string> GetWords(string[] sentences)
        {
            string[] wordSeparators = { " ", "\n", };
            List<string> wordsList = new List<string>();

            foreach (string sentence in sentences)
            {
                List<string> words = new List<string>(sentence.Split(wordSeparators, StringSplitOptions.RemoveEmptyEntries));
                for (int i = 0; i < words.Count; i++)
                {
                    List<string> extraSymbols = new List<string> { "=", "_", ";", "\"", "*", "#", "!", "|", "&", "-", "~", "+", "[", "]", "(", ")", " " };
                    for (int n = 0; n < extraSymbols.Count; n++)
                    {
                        words[i] = words[i].Replace(extraSymbols[n], "");
                    }

                    while (
                        words[i].Length != 0
                        && (words[i][0].CompareTo('\'') == 0
                        || words[i][0].CompareTo('.') == 0
                            )
                        )
                    {
                        words[i] = words[i].Remove(0, 1);
                    }

                    while (words[i].Length != 0 && (words[i][words[i].Length - 1].CompareTo('\'') == 0 || words[i][words[i].Length - 1].CompareTo(',') == 0
                        || words[i][words[i].Length - 1].CompareTo(':') == 0 || words[i][words[i].Length - 1].CompareTo('.') == 0))
                    {
                        words[i] = words[i].Remove(words[i].Length - 1);
                    }

                    if (words[i].Length == 0)
                    {
                        words.RemoveAt(i);
                        i--;
                    }


                }
                wordsList.AddRange(words);
            }

            return wordsList;
        }

        public static MatchCollection GetSymbols(string text)
        {
            string pattern = @"[^\w \f\n\r\t\v#=+*]";

            Regex regex = new Regex(pattern);
            MatchCollection mc = regex.Matches(text);
            return mc;
        }
    }
}
