using AoC2023ClassLib;
using Kerstpuzzel;

namespace AoC2023Tests
{
    public class Tests
    {
       [Test]
        public void Day1_Example()
        {
            CalibrationValueCalculator.Calculate("D1E");
            Assert.That(CalibrationValueCalculator.CalibrationSum, Is.EqualTo(142));           
        }

        [Test]
        public void Day1_Puzzle1()
        {
            CalibrationValueCalculator.Calculate("D1P1");
            Assert.That(CalibrationValueCalculator.CalibrationSum, Is.EqualTo(55621));
        }
    }
}