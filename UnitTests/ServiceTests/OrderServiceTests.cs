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
        GivenProductPrice(new Dictionary<Product, decimal>
        {
            { Product.SauceDuckRice, 20 }
        });

        WhenOrder(new OrderDto
        {
            Products = [Product.SauceDuckRice],
            ExtraAmount = 20
        });

        _orderRepository.Received().GetPrizeBy(Arg.Any<List<Product>>());
    }

    [Test]
    public void should_insert_order_with_total_amount()
    {
        GivenProductPrice(new Dictionary<Product, decimal>
        {
            { Product.SauceDuckRice, 20 }
        });

        WhenOrder(new OrderDto
        {
            Products = [Product.SauceDuckRice],
            ExtraAmount = 20
        });

        _orderRepository.Received().SaveOrder(Arg.Is<OrderDomain>(o => o.TotalAmount == 40));
    }

    private void WhenOrder(OrderDto orderDto)
    {
        _orderService.StoreOrder(orderDto);
    }

    private void GivenProductPrice(Dictionary<Product, decimal> expected)
    {
        _orderRepository.GetPrizeBy(Arg.Any<List<Product>>()).Returns(expected);
    }
}