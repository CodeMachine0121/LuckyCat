using LuckyCat.Interface;
using LuckyCat.Models;
using Microsoft.AspNetCore.Mvc;

namespace LuckyCat;

[Route("/api/order")]
public class OrderController : ControllerBase
{
    private IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpPost]
    public ApiResponse CreateOrder(OrderRequest request)
    {
        _orderService.StoreOrder(request.ToDto());
        return new ApiResponse
        {
            IsSuccess = true,
            Message = "Success",
            Data = request.ToDto() 
        };
    }
}