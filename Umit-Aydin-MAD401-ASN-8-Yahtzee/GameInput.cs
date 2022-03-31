using System;
using System.Text.RegularExpressions;

namespace Umit_Aydin_MAD401_ASN_8_Yahtzee
{
    public static class GameInput
    {
        
        public static string GetInput()
        {
            // var matcher = new Regex(pattern: @"\d,?");
            var matcher = new Regex(pattern: @"\d+,\ ?\d+,\d+");

            // Stub
            while (true)
            {
                try
                {
                    var test = Console.ReadLine();
                    if (test != null)
                    {
                        if (test.Length > 0)
                        {
                            if (matcher.IsMatch(test))
                            {
                                return test;
                            }

                            if (test == "show")
                            {
                                GameUi.ShowBoard();
                            }
                            else
                            {
                                return test;
                            }
                        }
                    }

                    Console.WriteLine(
                        "Please enter the number of the die or dice which you would like to re-roll in a comma separated list (ex.: 1,2,5):");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }

        public static string AskPlayer(string prompt)
        {
            Console.WriteLine(prompt);
            return GameInput.GetInput();
        }
    }
}