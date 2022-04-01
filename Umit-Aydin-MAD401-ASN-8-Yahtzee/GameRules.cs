using System;
using System.Collections.Generic;
using System.Linq;

namespace Umit_Aydin_MAD401_ASN_8_Yahtzee
{
    public class GameRules
    {
        public static Dictionary<string, Func<IList<Die>, int>> GameCategoryRules = new();

        static Dictionary<string, Func<IList<Die>, int>> GetRules() => GameCategoryRules;

        public GameRules()
        {
            SetupRules();
        }

        public KeyValuePair<string, Func<IList<Die>, int>> FindMatchingRule(List<Die> die)
        {
            return GameCategoryRules.Where(pair => pair.Value.Invoke(die) != -1).Select(pair => pair).FirstOrDefault();
        }

        public void SetupRules()
        {
            var isEqual = new Func<Die, int, bool>((Die i, int i2) => i.Num == i2);

            GameCategoryRules.Add("1s",
                x => (from die in x
                    where isEqual(die, 1)
                    select die.Num).Sum()
            );

            GameCategoryRules.Add("2s", x => (from die in x
                    where isEqual(die, 2)
                    select die.Num).Sum()
            );
            GameCategoryRules.Add("3s", x => (from die in x
                    where isEqual(die, 3)
                    select die.Num).Sum()
            );
            GameCategoryRules.Add("4s",
                x => (from die in x
                    where isEqual(die, 4)
                    select die.Num).Sum()
            );
            GameCategoryRules.Add("5s",
                x => (from die in x
                    where isEqual(die, 5)
                    select die.Num).Sum()
            );
            GameCategoryRules.Add("6s",
                x => (from die in x
                    where isEqual(die, 6)
                    select die.Num).Sum()
            );

            GameCategoryRules.Add("3 of a kind",
                x => (from die in x
                    group die by die.Num
                    into g
                    where g.Key.Equals(3)
                    select g).Count());

            GameCategoryRules.Add("4 of a kind",
                x => (from die in x
                    group die by die.Num
                    into g
                    where g.Key.Equals(4)
                    select g).Count());

            GameCategoryRules.Add("full house",
                x => (from die in x
                    group die by die.Num
                    into g
                    select g.Count()).Sum());

            GameCategoryRules.Add("sm straight",
                x => (from i in x
                    group i by i.Num
                    into g
                    select g.Key).Sum());

            GameCategoryRules.Add("lg straight",
                x => (from i in x
                    group i by i.Num
                    into g
                    select g.Key).Sum());

            GameCategoryRules.Add("yahtzee", x =>
                x.All(die => die.Num.Equals(die.Num)) ? 1 : 0);

            GameCategoryRules.Add("chance", x => (from die in x select die.Num).Sum());

        }
    }
}