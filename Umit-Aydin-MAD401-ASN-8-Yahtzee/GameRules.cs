using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Umit_Aydin_MAD401_ASN_8_Yahtzee
{
    public class GameRules
    {
        public static List<string> rules = new List<string>();

        public static Dictionary<string, Func<IList<Die>, object>> gameRules = new();

        Dictionary<string, Func<IList<Die>, object>> getRules() => gameRules;

        public static void setupRules()
        {
            var isEqual = new Func<Die, int, bool>((Die i, int i2) => i.Num == i2);

            gameRules.Add("1s",
                x => (from i in x
                    where isEqual(i, 1)
                    select i.Num).Count()
            );

            gameRules.Add("2s", x => (from i in x
                    where isEqual(i, 2)
                    select i.Num).Count()
            );
            gameRules.Add("3s", x => (from i in x
                    where isEqual(i, 3)
                    select i.Num).Count()
            );
            gameRules.Add("4s",
                x => (from i in x
                    where isEqual(i, 4)
                    select i.Num).Count()
            );
            gameRules.Add("5s",
                x => (from i in x
                    where isEqual(i, 5)
                    select i.Num).Count()
            );
            gameRules.Add("6s",
                x => (from i in x
                    where isEqual(i, 6)
                    select i.Num).Count()
            );

            gameRules.Add("3 of a kind",
                x => from i in x
                    group i by i.Num
                    into g
                    select g.Count() > 3);

            gameRules.Add("4 of a kind",
                x => from i in x
                    group i by i.Num
                    into g
                    select g.Count() > 4);

            gameRules.Add("full house",
                x => from i in x
                    group i by i.Num
                    into g
                    select g.Count());

            gameRules.Add("sm straight",
                x => from i in x
                    group i by i.Num
                    into g
                    select g.Count());

            gameRules.Add("lg straight",
                x => from i in x
                    group i by i.Num
                    into g
                    select g.Count());

            gameRules.Add("yahtzee", x =>
                x.All(die => die.Num.Equals(die.Num)));
            
        }
    }
}