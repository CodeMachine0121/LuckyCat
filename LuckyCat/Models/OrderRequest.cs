using LuckyCat.Enums;
using Newtonsoft.Json;

namespace LuckyCat.Models;

public class OrderRequest
{
    [JsonProperty("orderedProduct")]
    public List<OrderedProductRequest> OrderedProducts { get; set; }

    [JsonProperty("extraAmount")]
    public decimal ExtraAmount { get; set; }

    public OrderDto ToDto()
    {
        return new OrderDto
        {
            OrderedProductsAndAmount = GetVolumeMapping(),
            ExtraAmount = ExtraAmount
        };
    }

    private Dictionary<Product, int> GetVolumeMapping()
    {
        // 餐點與數量 mapping
        return OrderedProducts.ToDictionary(
            request => Enum.TryParse<Product>(
                request.Product, out var product)
                ? product
                : Product.Unknown
            , productRequest => productRequest.Volume
            );
    }
}

public class OrderedProductRequest
{
    [JsonProperty("product")]
    public string Product { get; set; }

    [JsonProperty("volume")]
    public int Volume { get; set; }
}