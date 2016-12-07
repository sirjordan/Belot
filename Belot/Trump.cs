using System;

namespace Belot
{
    public abstract class Trump
    {
        public abstract int MaxScore { get; }
        public abstract string Name { get; }
        public abstract int Power { get; }

        public static bool operator ==(Trump t1, Trump t2)
        {
            if (object.ReferenceEquals(t1, null) || object.ReferenceEquals(t2, null))
            {
                return false;
            }

            return t1.Power == t2.Power;
        }
        public static bool operator !=(Trump t1, Trump t2)
        {
            if (object.ReferenceEquals(t1, null) || object.ReferenceEquals(t2, null))
            {
                return true;
            }

            return t1.Power != t2.Power;
        }
        public static bool operator >(Trump t1, Trump t2)
        {
            if (object.ReferenceEquals(t1, null) || object.ReferenceEquals(t2, null))
            {
                return false;
            }

            return t1.Power > t2.Power;
        }
        public static bool operator <(Trump t1, Trump t2)
        {
            if (object.ReferenceEquals(t1, null) || object.ReferenceEquals(t2, null))
            {
                return false;
            }

            return t1.Power < t2.Power;
        }

        public static Trump Clubs { get { return new Clubs(); } }
        public static Trump Diamonds { get { return new Diamonds(); } }
        public static Trump Hearts { get { return new Hearts(); } }
        public static Trump Spades { get { return new Spades(); } }
        public static Trump NoTrump { get { return new NoTrump(); } }
        public static Trump AllTrump { get { return new AllTrump(); } }

        public override bool Equals(object obj)
        {
            var other = (Trump)obj;
            if (other != null)
            {
                return this.Power == other.Power;
            }
            else
            {
                return false;
            }
        }
        public override int GetHashCode()
        {
            return this.Power;
        }
    }

    public abstract class ColorTrump : Trump
    {
        public abstract CardColor Color { get; }
        public override int MaxScore { get { return 160; } }
    }

    public sealed class Clubs : ColorTrump
    {
        public override CardColor Color { get { return CardColor.Clubs; } }
        public override string Name { get { return "Clubs"; } }
        public override int Power { get { return 1; } }
    }
    public sealed class Diamonds : ColorTrump
    {
        public override CardColor Color { get { return CardColor.Diamonds; } }
        public override string Name { get { return "Diamonds"; } }
        public override int Power { get { return 2; } }
    }
    public sealed class Hearts : ColorTrump
    {
        public override CardColor Color { get { return CardColor.Hearts; } }
        public override string Name { get { return "Hearts"; } }
        public override int Power { get { return 3; } }
    }
    public sealed class Spades : ColorTrump
    {
        public override CardColor Color { get { return CardColor.Spades; } }
        public override string Name { get { return "Spades"; } }
        public override int Power { get { return 4; } }
    }
    public sealed class NoTrump : Trump
    {
        public override int MaxScore { get { return 260; } }
        public override string Name { get { return "No Trump"; } }
        public override int Power { get { return 5; } }
    }
    public sealed class AllTrump : Trump
    {
        public override int MaxScore { get { return 260; } }
        public override string Name { get { return "All Trump"; } }
        public override int Power { get { return 6; } }
    }
}
