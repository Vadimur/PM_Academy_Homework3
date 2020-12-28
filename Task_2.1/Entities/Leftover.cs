namespace Task_2._1.Entities
{
    public class Leftover
    {
        public string ProductId { get; }
        public string Location { get; }
        public int Amount { get; }

        public Leftover(string prodcutId, string location, int amount)
        {
            ProductId = prodcutId;
            Location = location;
            Amount = amount;
        }

        public override string ToString()
        {
            return $"There are {Amount} units of product with id {ProductId} at {Location}";
        }
    }
}