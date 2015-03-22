using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RegexPerformanceExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputCurrency = "$ 5.60";
            int count = 1000000;

            // Instance Regex
            Stopwatch sw = Stopwatch.StartNew();
            for (int i = 0; i < count; i++)
            {
                IsValidCurrencyInstance(inputCurrency);
            }
            Debug.WriteLine("Instance took {0} seconds", sw.Elapsed.TotalSeconds);

            sw.Reset();

            // Static Regex
            sw.Start();
            for (int i = 0; i < count; i++)
            {
                IsValidCurrencyStatic(inputCurrency);
            }
            Debug.WriteLine("Static took {0} seconds", sw.Elapsed.TotalSeconds);

            Console.ReadLine();
        }

        public static bool IsValidCurrencyInstance(string currencyValue)
        {
            string pattern = @"\p{Sc}+\s*\d+";
            Regex currencyRegex = new Regex(pattern);
            return currencyRegex.IsMatch(currencyValue);
        }

        public static bool IsValidCurrencyStatic(string currencyValue)
        {
            string pattern = @"\p{Sc}+\s*\d+";
            return Regex.IsMatch(currencyValue, pattern);
        }
    }
}
