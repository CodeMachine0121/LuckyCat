using LuckyCat.Models;
using Microsoft.AspNetCore.Mvc;

namespace LuckyCat;

[Route("/api/order")]
public class OrderController : ControllerBase
{
    [HttpPost]
    public ApiResponse CreateOrder()
    {
        return new ApiResponse
        {
            IsSuccess = true,
            Message = "Success",
            Data = null
        };
    }
}