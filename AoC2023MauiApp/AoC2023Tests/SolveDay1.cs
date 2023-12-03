using AoC2023ClassLib;
using Kerstpuzzel;

namespace AoC2023Tests
{
    public class SolveDay1
    {
       [Test]
        public void Day1_Example1()
        {
            CalibrationValueCalculator.Calculate("D1E1");
            Assert.That(CalibrationValueCalculator.CalibrationSum, Is.EqualTo(142));           
        }

        [Test]
        public void Day1_Puzzle1()
        {
            CalibrationValueCalculator.Calculate("D1P1");
            Assert.That(CalibrationValueCalculator.CalibrationSum, Is.EqualTo(55621));
        }

        [Test]
        public void Day1_Example2()
        {
            CalibrationValueCalculator.CalculateModified("D1E2");
            Assert.That(CalibrationValueCalculator.CalibrationSum, Is.EqualTo(281));
        }

        [Test]
        public void Day1_Puzzle2()
        {
            CalibrationValueCalculator.CalculateModified("D1P1");
            Assert.That(CalibrationValueCalculator.CalibrationSum, Is.EqualTo(53592));
        }
    }
}