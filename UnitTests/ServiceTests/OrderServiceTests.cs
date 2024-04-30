using LuckyCat.Enums;
using LuckyCat.Models;
using LuckyCat.Repositories;
using LuckyCat.Services;
using NSubstitute;
using NUnit.Framework;

namespace UnitTests.ServiceTests;

[TestFixture]
public class OrderServiceTests
{
    private IOrderRepository _orderRepository;
    private OrderService _orderService;
    
    [SetUp]
    public void SetUp()
    {
        _orderRepository = Substitute.For<IOrderRepository>();
        _orderService = new OrderService(_orderRepository);
    }


    [Test]
    public void should_get_price_of_products()
    {
        _orderService.StoreOrder(new OrderDto
        {
            Products = [Product.SauceDuckRice],
            ExtraAmount = 20
        });
        _orderRepository.Received().GetPrizeBy(Arg.Any<List<Product>>());
    }
}