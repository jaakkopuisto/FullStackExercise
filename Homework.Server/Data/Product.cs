namespace Homework.Server
{
    public class Product
    {
        public int id { get; set; }

        public string? title { get; set; }

        public string? description { get; set; }

        public int price { get; set; }
        public int discountPercentage { get; set; }
        public int rating { get; set; }
        public int stock { get; set; }
        public string? brand { get; set; }

        public string? category { get; set; }

        public string? thumbnail { get; set; }
        public Array? images { get; set; }

    }
}
