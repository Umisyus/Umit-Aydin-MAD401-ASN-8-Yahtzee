#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;

namespace Umit_Aydin_MAD401_ASN_8_Yahtzee
{
    public class GameLogic
    {
        public static List<Die> Dice = new List<Die>(6);
        private static readonly Dictionary<string, Func<IList<Die>, int>> GameCategoryRules = GameRules.GameCategoryRules;

        public static List<string> Categories;
        public List<int> Points;
        public Dictionary<string, int> CategoryPoints = new();

        public GameLogic()
        {
               GameRules.SetupRules();
            Categories = new(GameCategoryRules.Keys);
            Points = new List<int>(new int[Categories.Count]);
         
            Categories.ForEach(c => Points.Add(0));

            GenerateDice();
            RollAllDice();
            foreach (var category in Categories) {
                CategoryPoints.Add(category, 0);
            }
        }

        public void GenerateDice()
        {
            // Dice start being generated from one
            for (int i = 1; i < Dice.Capacity; i++) {
                Dice.Add(new Die($"D{i}", i));
            }
        }

        // Dice.Capacity + 1 because random max value is exclusive
        public static int GetRandomInt = new Random().Next(1, Dice.Capacity + 1);

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

                var die = Dice.Find(die1 => die1.DieFace.Equals("D" + dieFaceNumber));

                if (die != null) die.Num = GetRandomInt;

            } catch (Exception) {
                Console.WriteLine("Invalid die number!");
            }
        }

        public void RollDiceByCategory(string? category)
        {
            if (category == null) return;

            try {
                GameCategoryRules.ToList().Find(pair => pair.Key.Equals(category))
                    .Value.Invoke(Dice);
            } catch (Exception) {
                Console.WriteLine("Invalid die number!");
            }
        }

        public static void RollAllDice()
        {
            Dice.ForEach(die => die.Num = GetRandomInt);
        }

        public void ReRollManyDie(List<int> ints)
        {
            if (ints.Count > 0) {
                // Re-roll dice
                ints.ForEach(RollADie);
            }
        }
    }
}