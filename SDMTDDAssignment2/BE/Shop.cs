namespace SDMTDDAssignment2.BE
{
    public class Shop
    {
        public int Id { get;set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string WebsiteUrl { get; set; }
        public int Latitude { get; set; }
        public int Longtitude { get; set; }

        public string Gps => $"{Longtitude}.{Latitude}";
    }
}