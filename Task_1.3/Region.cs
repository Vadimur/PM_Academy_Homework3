namespace Task_1._3
{
    public class Region : IRegion
    {
        public string Brand { get; }
        public string Country { get; }

        public Region(string brand, string country)
        {
            Brand = brand;
            Country = country;
        }
        
        public override bool Equals(object obj)
        {
            var anotherRegion = obj as Region;
            if (anotherRegion == null)
                return false;
            return anotherRegion.Brand.Equals(this.Brand) && anotherRegion.Country.Equals(this.Country);
        }

        public override int GetHashCode()
        {
            return this.Brand.GetHashCode() ^ this.Country.GetHashCode();
        }

        public override string ToString()
        {
            return $"Brand: {Brand}, Country: {Country}";
        }
    }
}