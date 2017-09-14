using System;

namespace SDMTDDAssignment2.BE
{
    public class Shop
    {
        public int Id { get;set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string WebsiteUrl { get; set; }
        public double Latitude { get; set; }
        public double Longtitude { get; set; }

        public string Gps => $"{Latitude}.{Longtitude}";
    }
}