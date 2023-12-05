using System.Text.RegularExpressions;

namespace AoC_ConsoleProject.Day2_Cube_Conundrum
{
    internal class GearRatios
    {
        static string inputPath = "C:\\GitHub\\AoC_DEV\\AoC_ConsoleProject\\AoC_ConsoleProject\\Day2_Cube_Conundrum\\Assets\\PuzzleInput.txt";
        int redCubes = 12;
        int greenCubes = 13;
        int blueCubes = 14;

        int possibleGameIds = 0;
        int sumOfPowers = 0;

        void CountCubes(string line)
        {
            // Cubes
            int currentReds = 0;
            int currentGreens = 0;
            int currentBlues = 0;
            int biggestRed = 0;
            int biggestGreen = 0;
            int biggestBlue = 0;

            bool correctGame = true;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(line);
            Console.ForegroundColor = ConsoleColor.Green;
            string gameId = line.Remove(line.IndexOf(":"));
            gameId = gameId.Substring(5);

            // Remove game id from line
            line = line.Substring(line.IndexOf(":") + 1);

            string[] gameSets = line.Split(";");
            Console.WriteLine($"Game sets: {gameSets.Length}");
            foreach (string gameSet in gameSets)
            {
                string[] gameInput = gameSet.Split(",");

                for (int i = 0; i < gameInput.Length; i++)
                {
                    string colorType = Regex.Replace(gameInput[i], @"[\d-]", string.Empty).Trim().ToLower();
                    int colorCount = Convert.ToInt32(Regex.Replace(gameInput[i], "[^.0-9]", string.Empty));

                    switch (colorType)
                    {
                        case "blue":
                            if (biggestBlue < colorCount) biggestBlue = colorCount;
                            if (colorCount > blueCubes) correctGame = false;
                            break;
                        case "red":
                            if (biggestRed < colorCount) biggestRed = colorCount;
                            if (colorCount > redCubes) correctGame = false;
                            break;
                        case "green":
                            if (biggestGreen < colorCount) biggestGreen = colorCount;
                            if (colorCount > greenCubes) correctGame = false;
                            break;
                    }
                }
            }
            int powerOfSet = biggestRed * biggestGreen * biggestBlue;

            sumOfPowers += powerOfSet;
            if (correctGame) possibleGameIds += Convert.ToInt32(gameId);

        }

        public void Main()
        {
            try
            {
                using (StreamReader sr = new StreamReader(inputPath))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Game input:");
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        CountCubes(line);
                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Possible game ID's: {possibleGameIds}");
                    Console.WriteLine($"Sum of powers: {sumOfPowers}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
