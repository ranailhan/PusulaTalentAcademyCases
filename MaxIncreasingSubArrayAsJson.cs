using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PusulaTalentAcademyCases
{
    public class MaxIncreasingSubArrayAsJson
    {
        //        En Büyük Artan Alt Diziyi JSON Olarak Döndür
        //Açıklama
        //Bir tamsayı listesi veriliyor.Bu listede ardışık olarak artış gösteren alt dizilerden toplamı en yüksek
        //olan alt diziyi bulun.Bulduğunuz alt diziyi JSON formatında döndürün.
        //Metod
        //public static string MaxIncreasingSubarrayAsJson(List<int> numbers)
        public static string MaxIncreasingSubarrayAsJson(List<int> numbers)
        {

            if (numbers == null || numbers.Count == 0)
            {
                return JsonSerializer.Serialize(Array.Empty<int>());
            }
            if (numbers == null || numbers.Count == 0)
            {
                return JsonSerializer.Serialize(Array.Empty<int>());
            }

            int MaxIncreasingStart = 0, MaxIncreasingEnd = 0, MaxIncreasingSum = numbers[0];

            int currentStart = 0, currentSum = numbers[0];

            for (int i = 1; i < numbers.Count; i++)
            {
                if (numbers[i] > numbers[i - 1])
                {
                    currentSum += numbers[i];
                }
                else
                {
                    if (currentSum > MaxIncreasingSum)
                    {
                        MaxIncreasingSum = currentSum;
                        MaxIncreasingStart = currentStart;
                        MaxIncreasingEnd = i - 1;
                    }
                    currentStart = i;
                    currentSum = numbers[i];
                }
            }

            if (currentSum > MaxIncreasingSum)
            {
                MaxIncreasingSum = currentSum;
                MaxIncreasingStart = currentStart;
                MaxIncreasingEnd = numbers.Count - 1;
            }

            var subarray = numbers.Skip(MaxIncreasingStart).Take(MaxIncreasingEnd - MaxIncreasingStart + 1).ToArray();

            return JsonSerializer.Serialize(subarray);

        }

    }
}
