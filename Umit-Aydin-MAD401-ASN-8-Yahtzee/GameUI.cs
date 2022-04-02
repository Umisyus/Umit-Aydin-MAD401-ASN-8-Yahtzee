using System;
using System.Collections.Generic;
using System.Linq;
using static Umit_Aydin_MAD401_ASN_8_Yahtzee.GameLogic;

namespace Umit_Aydin_MAD401_ASN_8_Yahtzee
{
    public class GameUi
    {
        public string SelectACategoryPickTheDice =
            "Select a category, pick the dice to re-roll or \"show\" for score-card \n"
            + "(category / #,#,# / show): ";

        private static GameLogic gl = new GameLogic();

        public void Start()
        {
            // roll a die
            // roll again or show board
            SetupGame();
            Console.WriteLine("Rolling Dice...");
            ShowBoard();

        }

        private void SetupGame()
        {
            // Roll all dice
            GameRules.SetupRules();

            // Categories
            GameLogic.Categories = GameRules.GameCategoryRules.Keys.ToList();
        }

        public void ShowScoreCard(Dictionary<string, int> pair)
        {
            var catScore = pair.Select(valuePair => $"{valuePair.Key}\t\t\t{valuePair.Value}").ToList();

            Console.WriteLine(@"
----------------------
|     Score Card     |
----------------------
Category:        Points:
");

            catScore.ForEach(str =>
                Console.Write($@"{str}" + "\n"));
            Console.WriteLine("-------------------");
        }

        public void ShowBoard()
        {
            Console.WriteLine("You rolled the following:");
            var diceStr = string.Join(", ", GameLogic.Dice);
            Console.WriteLine(diceStr);

        }

        public void ShowBoard(Dictionary<string, int> pair)
        {
            var catScore = pair.Select(valuePair => $"{valuePair.Key}\t\t\t{valuePair.Value}").ToList();

            Console.WriteLine(@"
----------------------
|     Score Board     |
----------------------
Category:        Points:
");

            catScore.ForEach(str =>
                Console.Write($@"{str}" + "\n"));

            Console.WriteLine("-------------------");
        }
    }
}