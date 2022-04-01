namespace Umit_Aydin_MAD401_ASN_8_Yahtzee
{
    public class Die
    {
        public string DieFace { get; }
        public int Num;

        public Die(string dieFace, int num)
        {
            DieFace = dieFace;
            Num = num;
        }

        public override string ToString()
        {
            return $"{DieFace}: {Num}";
        }
    }
}