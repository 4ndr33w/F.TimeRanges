using System;
using System.Linq;

namespace F.TimeRanges
{
    internal class Program
    {
        static void Main(string[] args)
        {
            byte numberOfDatas = Convert.ToByte(Console.ReadLine());

            for (int i = 0; i < numberOfDatas; i++)
            {
                var amountOfInputRanges = Convert.ToUInt16(Console.ReadLine());
                string[] timeStrings = new string[amountOfInputRanges];
                
                for(int j = 0; j < amountOfInputRanges; j++)
                {
                    timeStrings[j] = Console.ReadLine();
                }

                Console.WriteLine(GetResult(timeStrings));
            }
        }

        static string GetResult(string[] timeStrings)
        {
            string result = "";
            string[] arrayResult = new string[timeStrings.Length];
            for (int i = 0; i < timeStrings.Length; i++)
            {
                byte hour1 = 0;
                byte hour2 = 0;

                byte minutes1 = 0;
                byte minutes2 = 0;

                byte seconds1 = 0;
                byte seconds2 = 0;
                for (int j = 0; j < (timeStrings.Length / 3) + 1; j++)
                {
                    hour1 = Convert.ToByte(timeStrings[i].Substring(0, 2)) ;
                    hour2 = Convert.ToByte(timeStrings[i].Substring(9, 2));

                    minutes1 = Convert.ToByte(timeStrings[i].Substring(3, 2));
                    minutes2 = Convert.ToByte(timeStrings[i].Substring(12, 2));

                    seconds1 = Convert.ToByte(timeStrings[i].Substring(6, 2));
                    seconds2 = Convert.ToByte(timeStrings[i].Substring(15, 2));

                    //result += $"{hour1}" + "\n" + $"{hour2}" + "\n" + $"{minutes1}" + "\n" + $"{minutes2}" + "\n" + $"{seconds1}" + "\n" + $"{seconds2}";

                    //Console.WriteLine($"{hour1}");
                    //Console.WriteLine($"{hour2}");
                    //Console.WriteLine($"{minutes1}");
                    //Console.WriteLine($"{minutes2}");
                    //Console.WriteLine($"{seconds1}");
                    //Console.WriteLine($"{seconds2}");
                }
                result = GetBoolResult(hour1, hour2, minutes1, minutes2, seconds1, seconds2);
                //result += timeStrings[i];
                //var testArray = Convert.ToByte(timeStrings[i].Split(':').ToArray());
                //arrayResult[i] = timeStrings[i];
            }




            return result;
        }

        static string GetBoolResult(byte hour1, byte hour2, byte minute1, byte minute2, byte second1, byte second2)
        {
            string result = "NO";
            if (
                hour1 < 24 && hour1 > -1 && 
                hour2 > -1 && hour2 < 24 &&
                minute1 > -1 && minute1 < 60 &&
                minute2 > -1 && minute2 < 60 &&
                second1 > -1 && second1 < 60 &&
                second2 > -1 && second2 < 60)

                result = "YES";

            return result;
        }
    }
}
