using LuckyCat.Interface;
using LuckyCat.Models;
using Microsoft.AspNetCore.Mvc;

namespace LuckyCat;

[Route("/api/order")]
public class OrderController(IOrderService orderService) : ControllerBase
{

    [HttpPost]
    public async Task<ApiResponse> CreateOrder([FromBody] OrderRequest request)
    {
        await orderService.StoreOrder(request.ToDto());
        return new ApiResponse
        {
            IsSuccess = true,
            Message = "Success",
            Data = request.ToDto() 
        };
    }
}