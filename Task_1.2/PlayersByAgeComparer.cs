using System.Collections.Generic;

namespace Task_1._2
{
    public class PlayersByAgeComparer : IComparer<IPlayer>
    {
        public int Compare(IPlayer p1, IPlayer p2)
        {
            if (p1 == null && p2 == null)
                return 0;
            if (p1 == null)
                return -1;
            if (p2 == null)
                return 1;

            return p1.Age.CompareTo(p2.Age);
        }
    }
}