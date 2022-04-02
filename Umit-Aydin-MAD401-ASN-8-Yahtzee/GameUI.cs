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

        public void ShowBoard(Dictionary<string, int> pair, int currentRound)
        {
            var catScore = pair.Select(valuePair => $"{valuePair.Key}\t\t\t{valuePair.Value}").ToList();

            Console.WriteLine(RoundTextStringValue(currentRound));

            catScore.ForEach(str =>
                Console.Write($@"{str}" + "\n"));

            Console.WriteLine("-------------------");
        }

        private static string RoundTextStringValue(int currentRound)
        {
            return $@"
----------------------
|     Round {currentRound}     |
----------------------
Category:        Points:
";
        }

        public void PrintScoreCard(int round)
        {
            Console.WriteLine(RoundTextStringValue(round));
            var values = GameRules.GetRules().Select(pair => new {Category = pair.Key, Point = pair.Value.Invoke(GameLogic.Dice)}).ToList();

            values.ForEach(val => { Console.WriteLine($"{val.Category}\t\t\t{val.Point}"); });
            
        }
    }
}