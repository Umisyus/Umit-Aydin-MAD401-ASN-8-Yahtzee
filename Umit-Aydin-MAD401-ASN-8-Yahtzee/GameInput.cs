using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Umit_Aydin_MAD401_ASN_8_Yahtzee
{
    public static class GameInput
    {
        private static Regex _matcher = new Regex(pattern: @"\d+,\ ?\d+,\d+");


        public static string GetInputString()
        {
            while (true) {
                var str = Console.ReadLine();
                if (str != null) {
                    return str;
                }
            }
        }

        public static string GetInput()
        {
            // var matcher = new Regex(pattern: @"\d,?");

            // Stub
            while (true) {
                try {
                    var test = Console.ReadLine();
                    if (test != null) {
                        if (test.Length > 0) {
                            if (_matcher.IsMatch(test)) {
                                return test;
                            }

                            if (test == "show") {
                                return "show";
                            }

                            return test;
                        }
                    }

                    Console.WriteLine(
                        "Please enter the number of the die or dice which you would like to re-roll in a comma separated list (ex.: 1,2,5):");
                } catch (Exception e) {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }

        public static string AskPlayer(string prompt)
        {
            Console.WriteLine(prompt);
            return GetInputString();
        }

        public static int ParseNumber(string input)
        {
            int o = 0;

            var i = _matcher.Matches(input)
                .Select(match => int.TryParse(match.Value, out o));
            return o;
        }

        public static List<int> ParseListOfNumbersFromInputString(string input)
        {
            // Expected input: #,#,#, expected output: List<int>{ #1 => 2, #2 => 3, #3 => 4 }

            return input.Split(',')
                .Where(s => int.TryParse(s, out _))
                .Select(s => int.Parse(s)).ToList();
        }

        public static List<int> ParseListOfIntsRegex(string input)
        {
            return _matcher.Matches(input).Select(match => match.Value)
                .Where(c => int.TryParse(c, out _)).Select(s => int.Parse(s))
                .ToList();
        }
    }
}