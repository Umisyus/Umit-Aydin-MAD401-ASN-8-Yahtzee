using System;
using System.Collections.Generic;

namespace Umit_Aydin_MAD401_ASN_8_Yahtzee
{
    public class GameUI
    {
        const string selectACategoryPickTheDice = "Select a category, pick the dice to re-roll or \"show\" for score-card \n"
                                                  + "(category / #,#,# / show): ";

        private List<Die> Dice = new List<Die>();
        private List<string> categories = new List<string>();


        public void Start()
        {
            // roll a die
            // roll again or show board
            Console.WriteLine("Rolling Dice...");
            var ans = AskPlayer(selectACategoryPickTheDice);
            // ShowBoard();
        }

        private string AskPlayer(string prompt)
        {
            Console.WriteLine(prompt);

        }

        public static void ShowBoard()
        {
            Console.WriteLine("You rolled the following:");
            Dice.ForEach(Console.WriteLine);

        }
    }

    internal class Die
    {
        public int Num;

        public Die(int num)
        {
            Num = num;
        }

        public override string ToString()
        {
            return Num.ToString();
        }
    }
}