namespace AoC_ConsoleProject.Day4_ScratchCards
{
    internal class Cards
    {
        static string inputPath = "C:\\GitHub\\AoC_DEV\\AoC_ConsoleProject\\AoC_ConsoleProject\\Day4_ScratchCards\\Assets\\PuzzleInput.txt";
        int totalCards = 0;
        List<string> clonedCards = new List<string>();
        List<string> lines = new List<string>();

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



        void CountCards(int lineIndex)
        {
            string line = lines[lineIndex].Remove(0, 7);
            int matching = 0;

            string[] dividedCard = line.Split('|');
            string[] winningNumbers = dividedCard[0].Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] chosenNumbers = dividedCard[1].Split(" ", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < winningNumbers.Length; i++)
            {

                for (int k = 0; k < chosenNumbers.Length; k++)
                {
                    if (winningNumbers[i] == chosenNumbers[k])
                    {
                        matching++;
                    }
                }

            }
            totalCards++;
            if (matching == 0)
            {
                return;
            }
            else
            {
                for (int i = 1; i <= matching; i++)
                {
                    CountCards(lineIndex + i);
                }
            }

        }

        public void Main()
        {
            lines = GetLines();

            for (int i = 0; i < lines.Count; i++)
            {
                CountCards(i);
            }

            Console.WriteLine($"Total cards: {totalCards}");

        }
    }
}
