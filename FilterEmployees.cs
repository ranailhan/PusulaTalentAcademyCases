using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PusulaTalentAcademyCases
{
    public class FilterEmployees
    {
        public static string filterEmployees(IEnumerable<(string Name, int Age, string Department, decimal Salary, DateTime HireDate)> employees)
        {
            var filtered = employees
                .Where(e => e.Age >= 25 && e.Age <= 40)
                .Where(e => e.Department == "IT" || e.Department == "Finance")
                .Where(e => e.Salary >= 5000 && e.Salary <= 9000)
                .Where(e => e.HireDate > new DateTime(2017, 12, 31))
                .ToList();

            var names = filtered
                .Select(e => e.Name)
                .OrderByDescending(n => n.Length)
                .ThenBy(n => n)
                .ToList();

            var totalSalary = filtered.Sum(e => e.Salary);
            var count = filtered.Count;
            var avgSalary = count > 0 ? Math.Round(filtered.Average(e => e.Salary), 2) : 0;
            var minSalary = count > 0 ? filtered.Min(e => e.Salary) : 0;
            var maxSalary = count > 0 ? filtered.Max(e => e.Salary) : 0;

            var result = new
            {
                Names = names,
                TotalSalary = totalSalary,
                AverageSalary = avgSalary,
                MinSalary = minSalary,
                MaxSalary = maxSalary,
                Count = count
            };

            return JsonSerializer.Serialize(result);
        }
    }
}
