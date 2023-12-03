using AoC2023ClassLib;
using Kerstpuzzel;

namespace AoC2023Tests
{
    public class SolveDay2
    {
       [Test]
        public void Day2_Example1()
        {
            Bag bag = new Bag("D2E1");
            bag.Reds = 12;
            bag.Greens = 13;
            bag.Blues = 14;

            Assert.That(bag.ValidGameSum, Is.EqualTo(8));           
        }

        [Test]
        public void Day2_Puzzle1()
        {
            Bag bag = new Bag("D2P1");
            bag.Reds = 12;
            bag.Greens = 13;
            bag.Blues = 14;

            Assert.That(bag.ValidGameSum, Is.EqualTo(2076));
        }

    }
}