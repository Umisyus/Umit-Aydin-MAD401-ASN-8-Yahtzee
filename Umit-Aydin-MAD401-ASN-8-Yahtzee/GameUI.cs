using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Umit_Aydin_MAD401_ASN_8_Yahtzee
{
    public class GameUi
    {
        const string SelectACategoryPickTheDice =
            "Select a category, pick the dice to re-roll or \"show\" for score-card \n"
            + "(category / #,#,# / show): ";

        public static List<Die> Dice = new List<Die>(6);

        private void setupGame()
        {
            // Dice
            for (int i = 0; i < Dice.Count; i++)
            {
                Dice[i] = new Die($"D{i}", i);
            }

            GameRules.setupRules();
            // Categories
            categories = GameRules.gameRules.Keys.ToList();
        }

        private static List<string> categories = new List<string>();
        private static List<int> points = new List<int>();


        public void Start()
        {
            // roll a die
            // roll again or show board
            Console.WriteLine("Rolling Dice...");
            ShowBoard();
            var ans = GameInput.AskPlayer(SelectACategoryPickTheDice);
        }

        public static void ShowBoard()
        {
            Console.WriteLine("You rolled the following:");
            var diceStr = string.Join(",", Dice);
            var cats = string.Join("\n", categories);

            // Show categories and dice values
            var catsPoints = cats + string.Join("\n", points);
            Console.WriteLine($@"
categories:        Dice:                  Points:
{cats}        {diceStr}              {catsPoints}
");
        }

        public static IList getDice()
        {
            return Dice.ToList();
        }
    }

    public class Die
    {
        public string Face { get; }
        public int Num;

        public Die(string face, int num)
        {
            Face = face;
            Num = num;
        }

        public override string ToString()
        {
            return Num.ToString();
        }
    }
}