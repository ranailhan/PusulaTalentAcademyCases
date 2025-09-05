using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PusulaTalentAcademyCases
{
    public class LongestVowelSubsequence
    {
        public static string LongestVowelSubsequenceAsJson(List<string> words)
        {
            var vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u' };
            var results = new List<object>();

            foreach (var word in words)
            {
                string longest = "";
                string current = "";

                foreach (var ch in word.ToLower())
                {
                    if (vowels.Contains(ch))
                    {
                        current += ch;
                        if (current.Length > longest.Length)
                            longest = current;
                    }
                    else
                    {
                        current = "";
                    }
                }

                results.Add(new
                {
                    word = word,
                    sequence = longest,
                    length = longest.Length
                });
            }

            return JsonSerializer.Serialize(results);
        }
    }
}
