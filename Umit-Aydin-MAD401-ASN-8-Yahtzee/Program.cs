using System;
using System.Collections.Generic;

namespace Umit_Aydin_MAD401_ASN_8_Yahtzee
{
    class Program
    {
        private static int _currentRound = 0;
        private static int _numMaxRounds = 13;
        private HashSet<Dictionary<string, int>> scoredCategories = new();
        private static int _rolledTimes;
        private static int maxRolledTimes = 3;


        public static void Main(string[] args)
        {
            Console.WriteLine("Hello and welcome to the Yahtzee game!");
            // new GameUi().Start();

            var gui = new GameUi();
            // gui.Start();


            var gameLogic = new GameLogic();
            GameLogic.RollAllDice();
            gui.ShowBoard(gameLogic.CategoryPoints);

            while (_currentRound < _numMaxRounds) {
                var ans = Console.ReadLine();

                if (ans == "show") {
                    gui.ShowScoreCard(gameLogic.CategoryPoints);
                }

                // Parse 
                else if (int.TryParse(ans, out var num)) {
                    gameLogic.RollADie(num);
                }

                // Entered integers
                var ints = GameInput.ParseListOfNumbersFromInputString(ans);
                if (_rolledTimes < maxRolledTimes) {
                    if (ints.Count != 0) {
                        gameLogic.ReRollManyDie(ints);
                        _rolledTimes++;
                    }
                }
                else {
                    Console.WriteLine("You cannot re-roll anymore dice!");
                }

                // Entered a category name
                if (GameLogic.Categories.Contains(ans)) {
                    // if category valid, re-roll dice of that category
                    gameLogic.RollDiceByCategory(ans);
                }
                else {
                    Console.WriteLine("Invalid input entered!\n" +
                                      "Invalid category or category already taken or Invalid number format (#,#,#)\n" +
                                      "Select a category, pick the dice to re-roll (Ex. 1,2,3) or \"show\" for score-card");
                }

                _currentRound++;
            }
        }
    }
}