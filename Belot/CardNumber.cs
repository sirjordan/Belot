using System;

namespace Belot
{
    public class CardNumber
    {
        public static readonly byte MaxCardNumber = 13;
        public static readonly byte MinCardNumebr = 1;
        public static readonly byte[] SkippedCardNumbers = new byte[] { 2, 3, 4, 5, 6 };

        public byte Number { get; private set; }

        public static CardNumber Ace { get { return new CardNumber(1); } }
        public static CardNumber Jack { get { return new CardNumber(11); } }
        public static CardNumber Queen { get { return new CardNumber(12); } }
        public static CardNumber King { get { return new CardNumber(13); } }

        public CardNumber(byte number)
        {
            if (number < MinCardNumebr || number > MaxCardNumber)
            {
                throw new ArgumentOutOfRangeException(string.Format("Card number must be between {0} and {1}", MinCardNumebr, MaxCardNumber));
            }

            this.Number = number;
        }

        public override string ToString()
        {
            switch (this.Number)
            {
                case 1:
                    return "Ace";
                case 11:
                    return "Jack";
                case 12:
                    return "Queen";
                case 13:
                    return "King";
                default:
                    return this.Number.ToString();
            }
        }
    }
}