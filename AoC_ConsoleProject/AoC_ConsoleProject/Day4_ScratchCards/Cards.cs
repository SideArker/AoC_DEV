using System.Security.AccessControl;
using System.Text.RegularExpressions;

namespace AoC_ConsoleProject.Day4_ScratchCards
{
    internal class Cards
    {
        static string inputPath = "C:\\GitHub\\AoC_DEV\\AoC_ConsoleProject\\AoC_ConsoleProject\\Day4_ScratchCards\\Assets\\PuzzleInput.txt";
        int totalPoints = 0;

        void CountCards(string line)
        {
            line = line.Remove(0, 7);
            int matching = 0;

            string[] dividedCard = line.Split('|');
            string[] winningNumbers = dividedCard[0].Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] chosenNumbers = dividedCard[1].Split(" ", StringSplitOptions.RemoveEmptyEntries);

            for(int i = 0; i < winningNumbers.Length; i++)
            {
                
                for(int k = 0; k < chosenNumbers.Length; k++) 
                {
                    if (winningNumbers[i] == chosenNumbers[k])
                    {
                        matching++;
                    }
                }

            }




            Console.WriteLine(matching);
            totalPoints += matching;
        }

        public void Main()
        {
                using (StreamReader sr = new StreamReader(inputPath))
                {
                    
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        CountCards(line);
                    }

                    Console.WriteLine($"total points: {totalPoints}");
                    Console.ForegroundColor = ConsoleColor.Green;
                }
        }
    }
}
