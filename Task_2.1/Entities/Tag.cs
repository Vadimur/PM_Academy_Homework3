namespace Task_2._1.Entities
{
    public class Tag
    {
        public string ProdcutId { get; }
        public string Value { get; }

        public Tag(string prodcutId, string value)
        {
            ProdcutId = prodcutId;
            Value = value;
        }
    }
    
}