using System;
using System.Collections.Generic;
using System.Linq;

namespace Umit_Aydin_MAD401_ASN_8_Yahtzee
{
    public class Dice
    {
        int NUMBER_OF_DICE = 6;

        private List<Die> DieCollection = new List<Die>();
        private Func<Die, bool> _isDieNumberEqual = die => die.Num.Equals(die.Num);

        public bool ThreeOfAKind() => DieCollection.Count(_isDieNumberEqual) == 3;
        public bool FourOfAKind() => DieCollection.Count(_isDieNumberEqual) == 4;
        public bool ThreeOfAKind(int val) => DieCollection.Count(die => die.Num == val) >= 3;
        public bool FourOfAKind(int val) => DieCollection.Count(die => die.Num == val) >= 4;

        public bool HasThreeTwos() => ThreeOfAKind(2);
    }
}