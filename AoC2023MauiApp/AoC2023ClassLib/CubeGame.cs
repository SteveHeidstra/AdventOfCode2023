using Kerstpuzzel;
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
    public class Bag
    {
        public readonly List<CubeGame> games;
        public Bag(string fileName)
        {
            BestandHelper.ApplicationPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            games = new List<CubeGame>();
            loadGames(BestandHelper.Readfile(string.Format(@"Input\{0}.txt", fileName)));
        }

        private void loadGames(string[] file)
        {
            foreach (var line in file)
            {
                CubeGame newGame = new CubeGame(line);
                MinimumRed = Math.Max(MinimumRed, newGame.MinimumRed);
                MinimumGreen = Math.Max(MinimumGreen, newGame.MinimumGreen);
                MinimumBlue = Math.Max(MinimumBlue, newGame.MinimumBlue);

                games.Add(newGame);
            }
        }

        public int Reds { get; set; }
        public int Greens { get; set; }
        public int Blues { get; set; }
        public int ValidGameSum
        {
            get
            {
                int validGameSum = 0;
                foreach (CubeGame game in from game in games
                                          where game.Valid(Reds, Greens, Blues)
                                          select game)
                {
                    validGameSum += game.ID;
                }

                return validGameSum;
            }
        }
        public int PowerOfMinimumSets
        {
            get
            {
                int powerOfMinimumSet = 0;
                foreach (CubeGame game in games)
                {
                    powerOfMinimumSet += game.PowerOfMinimumSet;
                }

                return powerOfMinimumSet;
            }
        }

        public int MinimumRed { get; private set; }
        public int MinimumGreen { get; private set; }
        public int MinimumBlue { get; private set; }

    }
    public class CubeGame
    {
        public int ID { get; private set; }
        public int MinimumRed { get; internal set; }
        public int MinimumGreen { get; internal set; }
        public int MinimumBlue { get; internal set; }
        public int PowerOfMinimumSet
        {
            get
            {
                return MinimumRed * MinimumGreen * MinimumBlue;

            }
        }

        public readonly List<Grab> Grabs;

        public CubeGame(string line)
        {
            Grabs = new List<Grab>();

            string[] game = line.Split(":");
            ID = Convert.ToInt32(game[0].Replace("Game", "").Trim());

            string[] grabs = game[1].Split(";");
            for (int i = 0; i < grabs.Length; i++)
            {
                Grab newGrab = new Grab(grabs[i]);
                MinimumRed = Math.Max(newGrab.Reds, MinimumRed);
                MinimumGreen = Math.Max(newGrab.Greens, MinimumGreen);
                MinimumBlue = Math.Max(newGrab.Blues, MinimumBlue);

                Grabs.Add(newGrab);
            }
        }

        public bool Valid(int reds, int greens, int blues)
        {
            return Grabs.Max(x => x.Reds) <= reds &&
                Grabs.Max(x => x.Greens) <= greens &&
                Grabs.Max(x => x.Blues) <= blues;
        }
    }

    public class Grab
    {
        public Grab(string cubeGrabs)
        {
            //   1 red, 2 green, 6 blue
            string[] colors = new string[3] { "red", "green", "blue" };
            string[] colorvalues = cubeGrabs.Split(",");
            for (int i = 0; i < colorvalues.Length; i++)
            {
                foreach (string colorName in colors)
                {
                    if (colorvalues[i].Contains(colorName))
                    {
                        int number = Convert.ToInt32(colorvalues[i].Replace(colorName, string.Empty).Trim());
                        if (colorName == "red")
                        {
                            Reds += number;
                        }
                        if (colorName == "green")
                        {
                            Greens += number;
                        }
                        if (colorName == "blue")
                        {
                            Blues += number;
                        }
                        break;
                    }
                }
            }


        }

        //public int ID { get; set; }
        public int Greens { get; set; }
        public int Reds { get; set; }
        public int Blues { get; set; }
    }



}
