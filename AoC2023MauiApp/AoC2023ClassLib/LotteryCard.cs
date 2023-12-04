using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2023ClassLib
{
    public class LotteryCard
    {
        public LotteryCard(string line)
        {
            string[] splitter = line.Split(':');
            ID = Convert.ToInt32(splitter[0].Replace("Card ", "").Trim());

            WinningNumbers = parseTheString(splitter[1].Split('|')[0]);
            CompetingNumbers = parseTheString(splitter[1].Split('|')[1]);
        }

        private int[] parseTheString(string line)
        {
            return line.Split(" ")
                .Select(possibleIntegerAsString =>
                {
                    int parsedInteger = 0;
                    bool isInteger = int.TryParse(possibleIntegerAsString, out parsedInteger);
                    return new { isInteger, parsedInteger };
                })
                .Where(tryParseResult => tryParseResult.isInteger)
                .Select(tryParseResult => tryParseResult.parsedInteger)
                .ToArray();
        }

        public int ID { get; private set; }
        public int[] CompetingNumbers { get; set; }
        public int[] WinningNumbers { get; set; }

        public double Points
        {
            get
            {
                double winners = 0;
                foreach (int i in CompetingNumbers)
                {
                    if (WinningNumbers.Contains(i))
                    {
                        winners++;
                    }
                }
                
                return winners==0?0: Math.Pow(2.00,winners -1);
            }
        }
    }
}
