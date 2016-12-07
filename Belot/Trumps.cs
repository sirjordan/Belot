using System.Collections;
using System.Collections.Generic;

namespace Belot
{
    public class Trumps : IEnumerable<Trump>
    {
        private static readonly List<Trump> _trumps = new List<Trump>
        {
            Trump.Clubs,
            Trump.Diamonds,
            Trump.Hearts,
            Trump.Spades,
            Trump.NoTrump,
            Trump.AllTrump,
        };

        public static Trumps All
        {
            get
            {
                return new Trumps();
            }
        }

        public IEnumerator<Trump> GetEnumerator()
        {
            return _trumps.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
