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

            Assert.That(lotteryCards.Sum(x => x.Points), Is.EqualTo(18653d));
        }

        [Test]
        public void Day4_Example2()
        {
            BestandHelper.ApplicationPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var file = BestandHelper.Readfile(string.Format(@"Input\{0}.txt", "D4E1"));

            List<LotteryCard> lotteryCards = new List<LotteryCard>();
            List<int> extras = new List<int>();
            extras.Add(1);
            foreach (var line in file)
            {
                LotteryCard card = new LotteryCard(line);
                
                if (extras.Count != 0)
                {
                    card.Instances = extras[0];
                    extras.RemoveAt(0);
                }

                for (int i = 0; i < card.Winners; i++)
                {
                    if (extras.Count - 1 < i)
                    {
                        extras.Add(1);
                    }
                    extras[i] += card.Instances;
                }

                lotteryCards.Add(card);
            }

            Assert.That(lotteryCards.Sum(x => x.Instances), Is.EqualTo(30));
        }

        [Test]
        public void Day4_Puzzle2()
        {
            BestandHelper.ApplicationPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var file = BestandHelper.Readfile(string.Format(@"Input\{0}.txt", "D4P1"));

            List<LotteryCard> lotteryCards = new List<LotteryCard>();
            List<int> extras = new List<int>();
            extras.Add(1);
            foreach (var line in file)
            {
                LotteryCard card = new LotteryCard(line);

                if (extras.Count != 0)
                {
                    card.Instances = extras[0];
                    extras.RemoveAt(0);
                }

                for (int i = 0; i < card.Winners; i++)
                {
                    if (extras.Count - 1 < i)
                    {
                        extras.Add(1);
                    }
                    extras[i] += card.Instances;
                }

                lotteryCards.Add(card);
            }

            Assert.That(lotteryCards.Sum(x => x.Instances), Is.EqualTo(30));
        }
    }
}