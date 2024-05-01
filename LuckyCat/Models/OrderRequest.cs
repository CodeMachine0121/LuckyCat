using System.Text.Json.Serialization;
using LuckyCat.Enums;
using Newtonsoft.Json;

namespace LuckyCat.Models;

public class OrderRequest
{
    [JsonProperty("orderedProduct")]
    public List<OrderedProductRequest> OrderedProductRequest { get; set; }
    
    [JsonProperty("extraAmount")]
    public decimal ExtraAmount { get; set; }

    public OrderDto ToDto()
    {
        var orderedProducts = OrderedProductRequest.ToDictionary(productRequest => (Product)productRequest.ProductId, productRequest => productRequest.Amount);

        return new OrderDto
        {
            OrderedProducts = orderedProducts,
            ExtraAmount = ExtraAmount
        };
    }
}

public class OrderedProductRequest
{
    [JsonProperty("product-id")]
    public int ProductId  { get; set; }
    
    [JsonProperty("amount")]
    public int Amount { get; set; }
}