using LuckyCat.Interface;
using LuckyCat.Models;
using Microsoft.AspNetCore.Mvc;

namespace LuckyCat;

[Route("/api/order")]
public class OrderController(IOrderService orderService) : ControllerBase
{

    [HttpPost]
    public ApiResponse CreateOrder(OrderRequest request)
    {
        orderService.StoreOrder(request.ToDto());
        return new ApiResponse
        {
            IsSuccess = true,
            Message = "Success",
            Data = request.ToDto() 
        };
    }
}