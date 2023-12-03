using Kerstpuzzel;
using Microsoft.Maui.Storage;
using System;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

namespace AoC2023ClassLib
{
    public static class CalibrationValueCalculator
    {
       
        static CalibrationValueCalculator()
        {
            BestandHelper.ApplicationPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);BestandHelper.ApplicationPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            
        }

        public static void Calculate(string fileName)
        {
            string[] file = BestandHelper.Readfile(string.Format(@"Input\{0}.txt", fileName));

            int sum = 0;
            foreach (string line in file)
            {
                string numbers = "";
                foreach (char character in line)
                {
                    if (char.IsDigit(character))
                    {
                        numbers += character;
                    };
                }                

                string number = numbers.First().ToString() + numbers.Last().ToString();
                sum += Convert.ToInt32(number);
            }
            CalibrationSum = sum;
        }

        public static void CalculateModified(string fileName)
        {
            string[] file = BestandHelper.Readfile(string.Format(@"Input\{0}.txt", fileName));
            int sum = 0;

            foreach (string line in file)
            {
                string numbers = "";
                for (int i = 0; i < line.Length; i++)
                {
                    if ((char.IsDigit(line[i])))
                    {
                        numbers += line[i];
                    }
                    else
                    {
                        numbers += foundDigitInText(line.Substring(i, Math.Min(line.Length-i,5)));
                    }
                }
                string number = numbers.First().ToString() + numbers.Last().ToString();
                sum += Convert.ToInt32(number);
            }

            CalibrationSum = sum;
        }

        private static string foundDigitInText(string text)
        {
            if (text.StartsWith("one")) { return "1"; }
            if (text.StartsWith("two")) { return "2"; }
            if (text.StartsWith("three")) { return "3"; }
            if (text.StartsWith("four")) { return "4"; }
            if (text.StartsWith("five")) { return "5"; }
            if (text.StartsWith("six")) { return "6"; }
            if (text.StartsWith("seven")) { return "7"; }
            if (text.StartsWith("eight")) { return "8"; }
            if (text.StartsWith("nine")) { return "9"; }

            return "";
        }

        public static int CalibrationSum { get; private set; }
    }
}