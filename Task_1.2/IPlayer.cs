namespace Task_1._2
{
    public interface IPlayer
    {
        int Age { get; }
        string FirstName { get; }
        string LastName { get; }
        PlayerRank Rank { get; }
    }
}