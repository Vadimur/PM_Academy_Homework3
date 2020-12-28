namespace Task_1._2
{
    public class Player : IPlayer
    {
        public int Age { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public PlayerRank Rank { get; }
        
        public Player(int age, string firstName, string lastName, PlayerRank rank)
        {
            FirstName = firstName;
            LastName = lastName;
            Rank = rank;
            Age = age;
        }

        public override string ToString()
        {
            return $"{LastName} {FirstName}, age = {Age}, rank = {Rank}";
        }
    }
}