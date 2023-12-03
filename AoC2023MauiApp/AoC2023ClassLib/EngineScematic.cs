using Kerstpuzzel;
using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AoC2023ClassLib
{
    public class EngineScematic
    {
        public EngineScematic(string fileName, bool parts)
        {
            BestandHelper.ApplicationPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var file = BestandHelper.Readfile(string.Format(@"Input\{0}.txt", fileName));

            if (parts)
            {
                parseParts(file);
            }
            else
            {
                parseGears(file);
            }
        }

        private void parseParts(string[] parts)
        {
            List<int> partList = new List<int>();

            for (int iRow = 0; iRow < parts.Length; iRow++)
            {
                string partNum = "";
                bool symbolFound = false;

                for (int jCol = 0; jCol < parts[iRow].Length; jCol++)
                {
                    //Bij geen getal, naar het volgende plekje
                    if (!char.IsDigit(parts[iRow][jCol]))
                    {
                        continue;
                    }

                    //Als dit wel een getal is gaan we controleren
                    partNum += parts[iRow][jCol].ToString();

                    //Zit er een symbool omheen (niet zijnde . of nummeriek? Zo ja: dan is het een partnumber
                    symbolFound = symbolFound || findSymbol(parts, iRow, jCol);

                    //Is het getal af? voeg het toe aan de lijst
                    if (parts[iRow].Length == jCol + 1 || !char.IsDigit(parts[iRow][jCol + 1]))
                    {
                        if (symbolFound)
                        {
                            partList.Add(Convert.ToInt32(partNum));
                        }

                        partNum = "";
                        symbolFound = false;
                    }

                }
            }

            SumOfPartNumbers = partList.Sum();

        }

        private bool findSymbol(string[] parts, int initRow, int initCol)
        {
            bool symbolFound = false;

            for (int iRow = initRow - 1; iRow <= initRow + 1; iRow++)
            {
                for (int iCol = initCol - 1; iCol <= initCol + 1; iCol++)
                {
                    try
                    {
                        symbolFound = parts[iRow][iCol] != '.' && !char.IsDigit(parts[iRow][iCol]);
                        if (symbolFound) { return symbolFound; }
                    }
                    catch (Exception ex) { continue; }
                }

            }
            return symbolFound;
        }

        private void parseGears(string[] parts)
        {

            List<Gear> gearlist = new List<Gear>();

            for (int iRow = 0; iRow < parts.Length; iRow++)
            {
                for (int jCol = 0; jCol < parts[iRow].Length; jCol++)
                {

                    //Alleen bij * gaan we zoeken
                    if (parts[iRow][jCol] != '*')
                    {
                        continue;
                    }

                    List<Part> partList = new List<Part>();

                    //Wat zijn mijn partnummers?
                    partList.AddRange(findParts(parts, iRow, jCol));

                    if (partList.Count == 2)
                    {
                        //Gear maken
                        gearlist.Add(new Gear() { Partlist = partList });
                    }

                }
            }
            SumOfGearRatios = gearlist.Sum(x => x.GearRatio);

        }

        private List<Part> findParts(string[] parts, int initRow, int initCol)
        {
            List<Part> partList = new List<Part>();

            for (int iRow = initRow - 1; iRow <= initRow + 1; iRow++)
            {
                for (int iCol = initCol - 1; iCol <= initCol + 1; iCol++)
                {
                    try
                    {
                        if (char.IsDigit(parts[iRow][iCol]))
                        {
                            partList.Add(getPart(parts, iRow, iCol));
                        };

                    }
                    catch (Exception ex) { continue; }
                }

            }
            return partList.Distinct().ToList();
        }

        private Part getPart(string[] parts, int row, int iCol)
        {
            int minCol = iCol;
            int maxCol = iCol;

            while (true)
            {
                try
                {
                    if (char.IsDigit(parts[row][minCol - 1]))
                        minCol -= 1;
                    else
                    {
                        break;
                    }
                }
                catch (Exception ex) { break; }

            }

            while (true)
            {
                try
                {
                    if (char.IsDigit(parts[row][maxCol + 1]))
                        maxCol += 1;
                    else
                    {
                        break;
                    }
                }
                catch (Exception ex) { break; }

            }
            string gearValue = "";
            for (int i = minCol; i <= maxCol; i++)
            {
                gearValue += parts[row][i].ToString();
            }

            return new Part() { Value = Convert.ToInt32(gearValue), Row = row, minCol = minCol, maxCol = maxCol };
        }

        public int SumOfGearRatios { get; private set; }
        public int SumOfPartNumbers { get; private set; }
    }

    class Part
    {
        public int Value { get; set; }
        public int Row { get; set; }

        public int minCol { get; set; }
        public int maxCol { get; set; }

        public override bool Equals(object obj)
        {
            var item = obj as Part;

            if (item == null)
            {
                return false;
            }

            return this.Value.Equals(item.Value) && this.Row.Equals(item.Row) && this.minCol.Equals(item.minCol);
        }
        public override int GetHashCode()
        {
            return this.Value.GetHashCode() + this.Row.GetHashCode() + this.minCol.GetHashCode();
        }
    }

    class Gear
    {
        public List<Part> Partlist { get; set; }
        public int GearRatio
        {
            get
            {
                return Partlist[0].Value * Partlist[1].Value;
            }
        }
    }
}
