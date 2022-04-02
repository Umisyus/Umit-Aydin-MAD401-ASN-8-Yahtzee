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

            Console.WriteLine($@"
----------------------
|     Round {currentRound}     |
----------------------
Category:        Points:
");

            catScore.ForEach(str =>
                Console.Write($@"{str}" + "\n"));

            Console.WriteLine("-------------------");
        }
    }
}