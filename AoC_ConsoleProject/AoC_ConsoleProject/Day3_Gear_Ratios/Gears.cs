
using System.Text.RegularExpressions;

namespace AoC_ConsoleProject.Day3_Gear_Ratios
{
    internal class Gears
    {
        static string inputPath = "C:\\GitHub\\AoC_DEV\\AoC_ConsoleProject\\AoC_ConsoleProject\\Day3_Gear_Ratios\\Assets\\PuzzleInput.txt";

        List<string> GetLines()
        {
            List<string> lines = new List<string>();
            try
            {
                using (StreamReader sr = new StreamReader(inputPath))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        lines.Add(line);
                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return lines;
        }

        int getLastIndex(int iterator, string line)
        {
            int currentIndex = iterator;
            while (char.IsNumber(line[currentIndex]))
            {
                currentIndex++;
                if (currentIndex + 1 > line.Length) break;

            }
            return currentIndex;
        }

        int getFirstIndex(int iterator, string line)
        {
            int currentIndex = iterator;
            if (currentIndex - 1 < 0) return currentIndex;
            while (char.IsNumber(line[currentIndex]))
            {
                if (currentIndex - 1 < 0) break;
                if (!char.IsNumber(line[currentIndex - 1])) break;
                    currentIndex--;
            }
            return currentIndex;
        }

        public void Main()
        {
            List<string> LinesInInput = GetLines();
            int sumOfPartNums = 0;
            int sumOfGearRatios = 0;
            List<int> gearIndexes = new List<int>();
            List<int> gearIndexLine = new List<int>();
            //Dictionary<int, int> gearIndexes = new Dictionary<int, int>(); // Key is gear index, value is line index

            for (int i = 0; i < LinesInInput.Count; i++)
            {
                int lastPartIndexInLine = 0;
                string currentLine = LinesInInput[i];

                for(int k = 0; k < currentLine.Length; k++)
                {
                    if (currentLine[k] == '*')
                    {
                        gearIndexes.Add(k);
                        gearIndexLine.Add(i);
                    }
                }



                // Get all partNumbers in the current line
                string[] partNumbers = Regex.Split(currentLine, "[^\\d-]+");

                for (int v = 0; v < partNumbers.Length; v++)
                {
                    partNumbers[v] = Regex.Replace(partNumbers[v], "[^.0-9]", string.Empty);
                }

                partNumbers = partNumbers.Where(x => !string.IsNullOrEmpty(x)).ToArray();

                foreach (var part in partNumbers)
                {
                    bool hasBeenFound = false;
                    Console.WriteLine($"Current Part: {part}");

                    int partNumLenght = part.Length;
                    int firstIndex = currentLine.IndexOf(part, lastPartIndexInLine);
                    int lastIndex = firstIndex + partNumLenght - 1;
                    // Previous line
                    for (int k = firstIndex - 1; k <= lastIndex + 1; k++)
                    {
                        if (i - 1 < 0) continue;
                        string previousLine = LinesInInput[i - 1];
                        if (k - 1 < 0) k++;
                        if (k + 1 > previousLine.Length) continue; 

                        if (!char.IsNumber(previousLine[k]) && previousLine[k] != '.')
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;

                            Console.WriteLine($"Part {part} is by a symbol");
                            hasBeenFound = true;
                        }
                    }


                    // Current line
                    int iterator = 1;

                    if (firstIndex - iterator < 0) iterator = 0;
                        if (!char.IsNumber(currentLine[firstIndex - iterator]) && currentLine[firstIndex - iterator] != '.')
                        {

                            Console.ForegroundColor = ConsoleColor.Yellow;

                            Console.WriteLine($"Part {part} is by a symbol");
                            hasBeenFound = true;
                        }

                    if (lastIndex + iterator >= currentLine.Length) iterator = 0;
                        if (!char.IsNumber(currentLine[lastIndex + iterator]) && currentLine[lastIndex + iterator] != '.')
                        {


                            Console.ForegroundColor = ConsoleColor.Yellow;

                            Console.WriteLine($"Part {part} is by a symbol");
                            hasBeenFound = true;
                        }


                    // Next line
                    for (int k = firstIndex - 1; k < lastIndex + 1; k++)
                    {
                        if (i + 1 >= LinesInInput.Count) continue;
                        string nextLine = LinesInInput[i + 1];
                        if (k - 1 < 0) k++;
                        if (k + 1 > nextLine.Length) continue;

                        if (!char.IsNumber(nextLine[k]) && nextLine[k] != '.')
                        {


                            Console.ForegroundColor = ConsoleColor.Yellow;

                            Console.WriteLine($"Part {part} is by a symbol");
                            hasBeenFound = true;
                        }
                    }

                    Console.ForegroundColor = ConsoleColor.Green;

                    if (hasBeenFound) sumOfPartNums += Convert.ToInt32(part);
                    lastPartIndexInLine = lastIndex + 1;

                }

            }

            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine($"Sum of parts: {sumOfPartNums}");

            // PART 2

            for (int i = 0; i < gearIndexes.Count; i++)
            {
                List<string> foundNums = new List<string>();

                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine($"Gear index in line {gearIndexLine[i] + 1}: {gearIndexes[i]}");

                for (int k = gearIndexes[i] - 1; k <= gearIndexes[i] + 1; k++)
                {

                    string tempNum = "";
                    if (gearIndexLine[i] - 1 < 0) continue;
                    string previousLine = LinesInInput[gearIndexLine[i] - 1];
                    string currentLine = LinesInInput[gearIndexLine[i]];
                    string nextLine = "";
                    if (gearIndexLine[i] + 1 < LinesInInput.Count) nextLine = LinesInInput[gearIndexLine[i] + 1];
                    
                    if (k - 1 < 0) k++;
                    if (k + 1 > previousLine.Length) continue;

                    //Previous line

                    if (char.IsNumber(previousLine[k]))
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"Found a part");
                        // Now search left and right
                        // search left for numberzzz
                        int lastIndexOfNum = getLastIndex(k, previousLine);
                        int firstIndexOfNum = getFirstIndex(k, previousLine);
                        int numLength = lastIndexOfNum - firstIndexOfNum;
                        tempNum = "";
                        for (int v = 0; v < numLength; v++)
                        {
                            tempNum += previousLine[firstIndexOfNum + v];
                        }

                        if (!string.IsNullOrEmpty(tempNum))
                        {
                            Console.WriteLine(tempNum);
                            foundNums.Add(tempNum);
                        }
                    }

                    //Next line

                    if(!string.IsNullOrEmpty(nextLine))
                    {
                        if (char.IsNumber(nextLine[k]))
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine($"Found a part");

                            int lastIndexOfNum = getLastIndex(k, nextLine);
                            int firstIndexOfNum = getFirstIndex(k, nextLine);
                            int numLength = lastIndexOfNum - firstIndexOfNum;
                            tempNum = "";

                            for (int v = 0; v < numLength; v++)
                            {
                                tempNum += nextLine[firstIndexOfNum + v];
                            }

                            if(!string.IsNullOrEmpty(tempNum))
                            {
                                Console.WriteLine(tempNum);
                                foundNums.Add(tempNum);
                            }

                        }
                    }
               

                    // Current line
                    if (char.IsNumber(currentLine[k]))
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"Found a part");

                        int lastIndexOfNum = getLastIndex(k, currentLine);
                        int firstIndexOfNum = getFirstIndex(k, currentLine);
                        int numLength = lastIndexOfNum - firstIndexOfNum;
                        tempNum = "";

                        for (int v = 0; v < numLength; v++)
                        {
                            tempNum += currentLine[firstIndexOfNum + v];
                        }

                        if (!string.IsNullOrEmpty(tempNum))
                        {
                            Console.WriteLine(tempNum);
                            foundNums.Add(tempNum);
                        }
                    }
                }

                string[] DistinctNumbers = foundNums.Distinct().ToArray();

                if (DistinctNumbers.Length >= 2)
                {
                    sumOfGearRatios += Convert.ToInt32(DistinctNumbers[0]) * Convert.ToInt32(DistinctNumbers[1]);
                    Console.WriteLine($"First num {DistinctNumbers[0]}");
                    Console.WriteLine($"Second num {DistinctNumbers[1]}");
                }
            }

            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine($"Sum of gear ratios: {sumOfGearRatios}");

        }

    }
}
