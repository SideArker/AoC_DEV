namespace AoC_ConsoleProject.Day1
{
    internal class CalibrationDoc
    {
        public void Main()
        {
            Dictionary<string, int> numbersInString = new Dictionary<string, int>()
            {
                {"one", 1 },
                {"two", 2 },
                {"three", 3 },
                {"four", 4 },
                {"five", 5 },
                {"six", 6 },
                {"seven", 7 },
                {"eight", 8 },
                {"nine", 9 },
            };

            try
            {
                using (StreamReader sr = new StreamReader("C:\\GitHub\\AoC_DEV\\AoC_ConsoleProject\\AoC_ConsoleProject\\Day1\\Assets\\AoCinput1.txt"))
                {
                    string line;
                    int sum = 0;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Entire File:");
                    Console.ForegroundColor = ConsoleColor.Yellow;

                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);

                        line = line.ToLower().Trim();

                        // Get all the appearences of word numbers in the string
                        List<KeyValuePair<string, int>> tempList = numbersInString.Where(item => line.Contains(item.Key)).ToList();

                        string[] lineArray = new string[line.Length];

                        foreach (var item in tempList)
                        {
                            int count = numbersInString.Where(item => line.Contains(item.Key)).ToList().Count + 2;
                            int lastIndex = 0;
                            for (int i = 0; i < count; i++)
                            {
                                if (line.IndexOf(item.Key, lastIndex) > -1)
                              {
                                lineArray[line.IndexOf(item.Key, lastIndex)] = item.Value.ToString();
                                lastIndex = line.IndexOf(item.Key, lastIndex) + item.Key.Length;

                            }

                        }
                    }

                        int prevIndex = 0;
                    foreach(var item in line.Where(x => char.IsNumber(x)).ToList())
                        {
                            lineArray[line.IndexOf(item, prevIndex)] = item.ToString();
                            prevIndex = line.IndexOf(item, prevIndex) + 1;
                        }    

                    List<string> finalArray = new List<string>();

                    for (int i = 0; i < lineArray.Length; i++)
                    {
                        if (!string.IsNullOrWhiteSpace(lineArray[i])) finalArray.Add(lineArray[i]);
                    }

                    string newLine = "";
                    finalArray.ForEach(x => newLine = string.Concat(newLine, x));
                    Console.WriteLine(newLine);
                    int calibrationValue = 0;
                    if (newLine.Length == 1) calibrationValue += Convert.ToInt32(string.Concat(newLine[0], newLine[0]));
                    else calibrationValue += Convert.ToInt32(string.Concat(newLine[0], newLine[newLine.Length - 1]));

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Calibration Value: ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(calibrationValue);
                    sum += calibrationValue;

                }



                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Sum: {sum}");
            }
                Console.ForegroundColor = ConsoleColor.Yellow;
        }
            catch (Exception ex)
            {
                Console.Write($"Error while reading file: {ex}");
            }
}
    }
}
