using System;
using System.Collections.Generic;
using System.Linq;
using static Umit_Aydin_MAD401_ASN_8_Yahtzee.GameLogic;

namespace Umit_Aydin_MAD401_ASN_8_Yahtzee
{
    public class GameUi
    {
        const string SelectACategoryPickTheDice =
            "Select a category, pick the dice to re-roll or \"show\" for score-card \n"
            + "(category / #,#,# / show): ";

        private static GameLogic gl = new();

        public void Start()
        {
            // roll a die
            // roll again or show board
            SetupGame();
            Console.WriteLine("Rolling Dice...");
            ShowBoard();
            var ans = GameInput.AskPlayer(SelectACategoryPickTheDice);
        }

        private void SetupGame()
        {
            // Roll all dice
            new GameRules().SetupRules();

            // Categories
            gl.Categories = GameRules.GameCategoryRules.Keys.ToList();
        }

        public void ShowBoard()
        {
            Console.WriteLine("You rolled the following:");
            var diceStr = string.Join(", ", Dice);
            Console.WriteLine(diceStr);

            var cats = string.Join("\n", gl.Categories);

            // Show categories and dice values
            var points =  string.Join("\n", gl.Points);
            Console.WriteLine($@"
    categories:                  Points (Number of dice in hand):
    {cats}                  {points}
");
        }
    }
}