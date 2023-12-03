using AoC2023ClassLib;
using Kerstpuzzel;

namespace AoC2023Tests
{
    public class SolveDay3
    {
       [Test]
        public void Day3_Example1()
        {
            EngineScematic ES = new EngineScematic("D3E1", true);
            
            Assert.That(ES.SumOfPartNumbers, Is.EqualTo(4361));           
        }

        [Test]
        public void Day3_Puzzle1()
        {
            EngineScematic ES = new EngineScematic("D3P1", true);

            Assert.That(ES.SumOfPartNumbers, Is.EqualTo(525181));
        }

        [Test]
        public void Day3_Example2()
        {
            EngineScematic ES = new EngineScematic("D3E1", false);

            Assert.That(ES.SumOfGearRatios, Is.EqualTo(467835));
        }

        [Test]
        public void Day3_Puzzle2()
        {
            EngineScematic ES = new EngineScematic("D3P1", false);

            Assert.That(ES.SumOfGearRatios, Is.EqualTo(84289137));
        }
    }
}