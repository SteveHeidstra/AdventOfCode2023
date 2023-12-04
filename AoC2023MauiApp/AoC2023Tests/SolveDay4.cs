using AoC2023ClassLib;
using Kerstpuzzel;
using System.Reflection;

namespace AoC2023Tests
{
    public class SolveDay4
    {
       [Test]
        public void Day4_Example1()
        {
            BestandHelper.ApplicationPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var file = BestandHelper.Readfile(string.Format(@"Input\{0}.txt", "D4E1"));

            List<LotteryCard> lotteryCards = new List<LotteryCard>();
            foreach (var line in file)
            {
                lotteryCards.Add(new LotteryCard(line));
            }

            Assert.That(lotteryCards.Sum(x => x.Points), Is.EqualTo(13));
        }

        [Test]
        public void Day4_Puzzle1()
        {
            BestandHelper.ApplicationPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var file = BestandHelper.Readfile(string.Format(@"Input\{0}.txt", "D4P1"));

            List<LotteryCard> lotteryCards = new List<LotteryCard>();
            foreach (var line in file)
            {
                lotteryCards.Add(new LotteryCard(line));
            }

            Assert.That(lotteryCards.Sum(x => x.Points), Is.EqualTo(13));
        }
    }
}