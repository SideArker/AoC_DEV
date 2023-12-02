using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AoC_ConsoleProject
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
                using (StreamReader sr = new StreamReader("C:\\GitHub\\AoC_DEV\\AoC_ConsoleProject\\AoC_ConsoleProject\\Assets\\AoCinput1.txt"))
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

                        tempList.ForEach(item => lineArray[line.IndexOf(item.Key)] = item.Value.ToString());

                        line.Where(x => char.IsNumber(x)).ToList().ForEach(item => lineArray[line.IndexOf(item)] = item.ToString());

                        List<string> finalArray = new List<string>();

                        for(int i = 0; i < lineArray.Length; i++)
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
