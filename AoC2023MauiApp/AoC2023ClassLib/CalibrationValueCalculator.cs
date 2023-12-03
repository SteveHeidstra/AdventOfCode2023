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
                //string numbers = new string(line
                //         //.SkipWhile(c => !char.IsDigit(c))
                //         .TakeWhile(c => char.IsDigit(c))
                //         .ToArray());
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

        public static int CalibrationSum { get; private set; }
    }
}