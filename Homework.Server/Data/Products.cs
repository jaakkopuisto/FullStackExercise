using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

public class Product
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("title")]
    public string? Title { get; set; }
    [JsonPropertyName("description")]
    public string? Description { get; set; }
    [JsonPropertyName("price")]
    public int? Price { get; set; }
    [JsonPropertyName("discountPercentage")]
    public double? DiscountPercentage { get; set; }
    [JsonPropertyName("rating")]
    public double? Rating { get; set; }
    [JsonPropertyName("stock")]
    public int? Stock { get; set; }
    [JsonPropertyName("brand")]
    public string? Brand { get; set; }
    [JsonPropertyName("category")]
    public string? Category { get; set; }
    [JsonPropertyName("thumbnail")]
    public string? Thumbnail { get; set; }
    [JsonPropertyName("images")]
    public List<string>? Images { get; set; }

    public Product()
   {
    }
    public Product(int id)
    {
        Id = id;
    }
    public Product(int id, string? title, string? description, int? price, double? discountPercentage, double? rating, int? stock, string? brand, string? category, string? thumbnail, List<string>? images)
    {
        Id = id;
        Title = title;
        Description = description;
        Price = price;
        DiscountPercentage = discountPercentage;
        Rating = rating;
        Stock = stock;
        Brand = brand;
        Category = category;
        Thumbnail = thumbnail;
        Images = images;
    }

    public Product(int id, string title, string desc, int price)
    {
        Id = id;
        Title = title;
        Description = desc;
        Price = price;
    }
}

public class RootProducts
{
    [JsonPropertyName("products")]
    public List<Product> Products { get; set; }
    [JsonPropertyName("total")]
    public int? Total { get; set; }
    [JsonPropertyName("skip")]
    public int? Skip { get; set; }
    [JsonPropertyName("limit")]
    public int? Limit { get; set; }

    public RootProducts()
    {

    }
    public RootProducts(List<Product> products)
    {
        Products = products;
    }
}