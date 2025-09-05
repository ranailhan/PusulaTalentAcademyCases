using System.Runtime.InteropServices;

namespace PusulaTalentAcademyCases
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var numbers = new List<int> { 1, 2, 3, 1, 2 };
            string jsonResult = MaxIncreasingSubArrayAsJson.MaxIncreasingSubarrayAsJson(numbers);
            Console.WriteLine(jsonResult);

            Console.WriteLine(LongestVowelSubsequence.LongestVowelSubsequenceAsJson(
    new List<string> { "miscellaneous", "queue", "sky", "cooperative" }));
        }

    }
}
