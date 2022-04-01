using System;
using System.Collections.Generic;

namespace Umit_Aydin_MAD401_ASN_8_Yahtzee
{
    public class GameLogic
    {
        public static List<Die> Dice = new List<Die>(6);
        public List<string> Categories = new(GameRules.GameCategoryRules.Keys);
        public List<int> Points = new List<int>();

        public GameLogic()
        {
            GenerateDice();
            RollAllDice();
        }

        public void GenerateDice()
        {
            // Dice
            for (int i = 0; i < Dice.Capacity; i++) {
                Dice.Add(new Die($"D{i}", i));
            }
        }

        // Dice.Capacity + 1 because random max value is exclusive
        public int GetRandomInt = new Random().Next(1, Dice.Capacity + 1);

        public void RollADie(Die die)
        {
            if (die == null) return;
            try {

                Dice.Find(die1 => die1.DieFace.Equals(die.DieFace)).Num = GetRandomInt;

            } catch (Exception) {
                Console.WriteLine("Invalid die number!");
            }
        }

        public void RollADie(int dieFaceNumber)
        {
            try {

                Dice.Find(die1 => die1.DieFace.Equals("D" + dieFaceNumber)).Num = GetRandomInt;

            } catch (Exception) {
                Console.WriteLine("Invalid die number!");
            }
        }

        public void RollAllDice()
        {
            Dice.ForEach(die => die.Num = GetRandomInt);
        }
    }
}