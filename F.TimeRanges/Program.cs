﻿using System;
using System.Linq;
using System.Runtime;

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
                    timeStrings[j] = Console.ReadLine().Replace(" ", "");
                }
                Console.WriteLine(GetDateTime(timeStrings));
            }
        }

        static string GetDateTime(string[] timeStrings)
        {
            string result = "NO";
            string[] arrayResult = new string[timeStrings.Length];

            DateTime[,] timeArray = new DateTime[timeStrings.Length, 2];
            for (int i = 0; i < timeStrings.Length; i++)
            {
                int hour1 = 0;
                int hour2 = 0;

                int minutes1 = 0;
                int minutes2 = 0;

                int seconds1 = 0;
                int seconds2 = 0;
                for (int j = 0; j < (timeStrings.Length / 3) + 1; j++)
                {
                    hour1 = Convert.ToInt32(timeStrings[i].Substring(0, 2));
                    hour2 = Convert.ToInt32(timeStrings[i].Substring(9, 2));

                    minutes1 = Convert.ToInt32(timeStrings[i].Substring(3, 2));
                    minutes2 = Convert.ToInt32(timeStrings[i].Substring(12, 2));

                    seconds1 = Convert.ToInt32(timeStrings[i].Substring(6, 2));
                    seconds2 = Convert.ToInt32(timeStrings[i].Substring(15, 2));
                }
                if (
                    hour1 < 24 && hour1 > -1 &&
                    hour2 > -1 && hour2 < 24 &&
                    minutes1 > -1 && minutes1 < 60 &&
                    minutes2 > -1 && minutes2 < 60 &&
                    seconds1 > -1 && seconds1 < 60 &&
                    seconds2 > -1 && seconds2 < 60
                    )
                {
                    timeArray[i, 0] = new DateTime(2023, 8, 27, hour1, minutes1, seconds1);
                    timeArray[i, 1] = new DateTime(2023, 8, 27, hour2, minutes2, seconds2);
                    result = "YES";
                }
                if ((timeArray[i, 0] - timeArray[i, 1]).TotalSeconds > 0)
                {
                    result = "NO";
                    break;
                }

                #region СОРТИРОВКА
                for (int v = 0; v < timeStrings.Length; v++)
                {
                    for (int z = v+1; z < timeStrings.Length; z++)
                    {
                        if ((timeArray[v,0] - timeArray[z,0]).TotalSeconds < 0)
                        {
                            DateTime[] tempVariable = new DateTime[2];
                            tempVariable[0] = timeArray[v, 0];
                            tempVariable[1] = timeArray[v, 1];

                            timeArray[v,0] = timeArray[z,0];
                            timeArray[v, 1] = timeArray[z, 1];

                            timeArray[z, 0] = tempVariable[0];
                            timeArray[z, 1] = tempVariable[1];


                        }
                        if ((timeArray[v, 0] - timeArray[z, 1]).TotalSeconds < 0)
                        {
                            result = "NO"; break;
                        }
                    }
                }
                #endregion


                #region икл сравнения наложения отрезков

                //for (int j = 0; j< timeStrings.Length; j++)
                //{


                //    for (int k = j + 1; k < timeStrings.Length; k++)
                //    {

                //        //result += $"\n{(timeArray[j, 0] - timeArray[k, 1]).TotalSeconds}\n{(timeArray[k, 0] - timeArray[j, 1]).TotalSeconds}";
                //        if (
                //                //(
                //                (
                //                (timeArray[j, 0] - timeArray[k, 1]).TotalSeconds < 0) //&&
                //                //((timeArray[j, 0] - timeArray[k, 0]).TotalSeconds > 0)
                //                //||
                //                //(timeArray[k, 0] - timeArray[j, 1]).TotalSeconds > 0
                //            )
                //        {
                //            result = "NO";
                //            break;
                //            //for (int s = 0; s < timeStrings.Length; s++)
                //            //{
                //            //    result += "\n";
                //            //    result += timeArray[s, 0].Hour;
                //            //    result += ":";
                //            //    result += timeArray[s, 0].Minute;
                //            //    result += ":";
                //            //    result += timeArray[s, 0].Second;
                //            //    result += "-";
                //            //    result += timeArray[s, 1].Hour;
                //            //    result += ":";
                //            //    result += timeArray[s, 1].Minute;
                //            //    result += ":";
                //            //    result += timeArray[s, 1].Second;
                //            //    result += "\n";
                //            //}
                //        }
                //        else 
                //        {
                //            //result = $"{(timeArray[j, 0] - timeArray[k, 1]).TotalSeconds}";
                //            //result += $"\n{(timeArray[k, 0] - timeArray[j, 1]).TotalSeconds}";
                //            result = "YES"; 
                //            //break; 
                //        }
                //    }
                //}

                #endregion
            }

            return result;
        }

        static string ConvertToDateTimeMethod(int hour1, int hour2, int minute1, int minute2, int second1, int second2)
        {
            string result = "NO";
            if (
                hour1 < 24 && hour1 > -1 &&
                hour2 > -1 && hour2 < 24 &&
                minute1 > -1 && minute1 < 60 &&
                minute2 > -1 && minute2 < 60 &&
                second1 > -1 && second1 < 60 &&
                second2 > -1 && second2 < 60
                )
            {
                DateTime timeRange1 = new DateTime(2023, 8, 17, hour1, minute1, second1);
                DateTime timeRange2 = new DateTime(2023, 8, 17, hour2, minute2, second2);
                TimeSpan span = new TimeSpan();
                span = timeRange2 - timeRange1;
                if (span.TotalSeconds >= 0) result = "YES";
            }

                

            return result;
        }
    }
}
