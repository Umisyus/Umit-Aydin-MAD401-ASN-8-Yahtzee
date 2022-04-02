﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Umit_Aydin_MAD401_ASN_8_Yahtzee
{
    class Program
    {
        private static int _currentRound = 0 + 1;
        private static int _numMaxRounds = 13 + 1;
        private static HashSet<KeyValuePair<string, int>> scoredCategories = new();
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
            gui.ShowBoard(gameLogic.CategoryPoints, _currentRound);

            while (_currentRound < _numMaxRounds) {
                while (true) {
                    Console.WriteLine(gui.SelectACategoryPickTheDice);
                    var ans = Console.ReadLine();

                    if (ans == "show") {
                        gui.ShowScoreCard(gameLogic.CategoryPoints);
                        break;
                    }

                    // Entered a category name
                    // Re-roll dice for an entire category
                    if (GameLogic.Categories.Contains(ans)) {
                        gui.ShowBoard(gameLogic.CategoryPoints, _currentRound);
                        SelectCategory();

                        if (CategoryDoesNotExistInCategoryPoints(ans, gameLogic)
                            && CategoryNotAlreadyScored(ans)) {
                            // if category valid, re-roll the dice by category
                            gameLogic.RollDiceByCategory(ans);
                        }
                        else {
                            InvalidEntry();
                        }
                    }

                    // Entered integers (#,#,#)
                    // Re-roll the dice entered
                    var ints = GameInput.ParseListOfNumbersFromInputString(ans);
                    if (_rolledTimes < maxRolledTimes) {
                        if (ints.Count != 0 && ints.Count <= GameLogic.Dice.Count) {
                            gameLogic.ReRollManyDie(ints);
                            _rolledTimes++;
                            break;
                        }

                        Console.WriteLine("You cannot re-roll anymore dice!");

                        // Score a category
                        // Entered a category name
                        // Score points for a category
                        if (GameLogic.Categories.Contains(ans)
                            && CategoryDoesNotExistInCategoryPoints(ans, gameLogic)
                            && CategoryNotAlreadyScored(ans)) {
                            // if category is valid, score that category and mark it scored
                            ScoreCategory(ans, gameLogic);
                        }
                        else InvalidEntry();
                    }

                    // gui.ShowBoard(gameLogic.CategoryPoints, _currentRound);
                }

                _currentRound++;
            }

            // Game end, show final score board
            Console.WriteLine("Your Final score:");
            gui.ShowScoreCard(scoredCategories.ToDictionary(
                p => p.Key,
                h => h.Value
            ));
        }

        private static void InvalidEntry()
        {
            Console.WriteLine("Invalid input entered!\n" +
                              "Invalid category or category already taken or Invalid number format (#,#,#)\n" +
                              "Select a category, pick the dice to re-roll (Ex. 1,2,3) or \"show\" for score-card");
        }

        private static bool CategoryNotAlreadyScored(string ans)
        {
            // Determine whether the category already exists in the scored categories hash-set by looking at the output value of this method
            return scoredCategories.Where(pair => pair.Key == ans).Select(pair => pair).Any() == false;
        }

        private static bool CategoryDoesNotExistInCategoryPoints(string ans, GameLogic gameLogic)
        {
            return gameLogic.CategoryPoints.ContainsKey(ans);
        }

        private static void ScoreCategory(string ans, GameLogic gameLogic)
        {
            if (ans != null) {
                var foundCategory = gameLogic.CategoryPoints.ToList()
                    .Find(s => ans == s.Key);

                scoredCategories.Add(
                    // gameLogic.CategoryPoints.ToList().Find(pair => pair.Key == ans
                    foundCategory
                    // )
                );

            }
        }

        private static void SelectCategory()
        {
            Console.WriteLine("Please enter a category to score:");


        }
    }
}