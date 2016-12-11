namespace Belot
{
    public class Card
    {
        public CardColor Color { get; private set; }
        public CardNumber Number { get; private set; }

        public Card(CardColor color, CardNumber cardNumber)
        {
            this.Color = color;
            this.Number = cardNumber;
        }

        public override string ToString()
        {
            return string.Format("{0} of {1}", Number, Color);
        }
        public int GetCardScorePoints(Trump trump)
        {
            int score;

            switch (this.Number.Number)
            {
                case 1:     // Ace
                    score = 11;
                    break;
                case 9:
                    if ((trump is ColorTrump && ((ColorTrump)trump).Color ==  this.Color) || trump == Trump.AllTrump)
                    {
                        score = 14;
                    }
                    else
                    {
                        score = 0;
                    }
                    break;
                case 10:
                    score = 10;
                    break;
                case 11:    // Jack
                    if ((trump is ColorTrump && ((ColorTrump)trump).Color == this.Color) || trump == Trump.AllTrump)
                    {
                        score = 20;
                    }
                    else
                    {
                        score = 2;
                    }
                    break;
                case 12:     // Queen
                    score = 3;
                    break;
                case 13:    // King
                    score = 4;
                    break;
                default:    // 7's and 8's
                    score = 0;
                    break;
            }

            if (trump == Trump.NoTrump)
            {
                score *= 2;
            }

            return score;
        }
    }
}