using System.Collections.Generic;

namespace Task_1._2
{
    public class PlayersEqualityComparer : IEqualityComparer<IPlayer>
    {
        public bool Equals(IPlayer p1, IPlayer p2)
        {
            if (p1 == null && p2 == null)
                return true;
            if (p1== null || p2 == null)
                return false;
            
            return p1.FirstName.Equals(p2.FirstName) && p1.LastName.Equals(p2.LastName)
                                                     && p1.Age.Equals(p2.Age) && p1.Rank.Equals(p2.Rank);
        }

        public int GetHashCode(IPlayer obj)
        {
            int hashCode = obj.FirstName.GetHashCode() ^ obj.LastName.GetHashCode() ^ obj.Age.GetHashCode() ^
                           obj.Rank.GetHashCode();
            return hashCode.GetHashCode();
        }
    }
}