namespace AoC_ConsoleProject.Day6_WaitForIt
{
    internal class Boat
    {
        static string inputPath = "C:\\GitHub\\AoC_DEV\\AoC_ConsoleProject\\AoC_ConsoleProject\\Day6_WaitForIt\\Assets\\PuzzleInput.txt";
        int marginOfError;
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


        string DivideInputIntoArrays(string line)
        {
            line = line.Substring(9);

            string dividedInput = String.Join("", line.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries));

            return dividedInput;
        }

        int CalculateRecords(long time, long distanceToBeat, long charge)
        {
            long leastTime = 0;
            long mostTime = 0;

            int winningWays = 0;

            for (int i = 0; i < time; i++)
            {
                long leftoverTime = time - charge;
                long result = leftoverTime * charge;



                if (result > distanceToBeat)
                {
                    winningWays++;

                    if (result < leastTime) leastTime = result;
                    if (result > mostTime) mostTime = result;
                }

                if (charge < distanceToBeat)
                {
                    charge++;
                }

                //Console.WriteLine($"Distance: {distanceToBeat}");
                //Console.WriteLine($"Leftover time: {leftoverTime}");
                //Console.WriteLine($"result: {result}");
            }



            Console.WriteLine($"Least time: {leastTime}");
            Console.WriteLine($"most time: {mostTime}");
            return winningWays;
        }

        public void Main()
        {
            lines = GetLines();
            long WinningWays = 0;

            string time = DivideInputIntoArrays(lines[0]);
            string distance = DivideInputIntoArrays(lines[1]);

            Console.WriteLine(time);
            Console.WriteLine(distance);

                WinningWays = CalculateRecords(Convert.ToInt64(time), Convert.ToInt64(distance), 1);


            Console.WriteLine($"Winnig ways {WinningWays}");

        }

    }
}