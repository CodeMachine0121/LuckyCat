using LuckyCat.Enums;
using LuckyCat.Interface;
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
    private IPriceRepository _prizeRepository;

    [SetUp]
    public void SetUp()
    {
        _orderRepository = Substitute.For<IOrderRepository>();
        _prizeRepository = Substitute.For<IPriceRepository>();

        _orderService = new OrderService(_orderRepository, _prizeRepository);
    }


    [Test]
    public void should_get_price_of_products()
    {
        GivenProductPrice(new PriceDomain
        {
            Product = Product.SauceDuckRice,
            PriceAmount = 20
        });

        WhenOrder(new OrderDto
        {
            OrderedProductsAndAmount = new Dictionary<Product, int>
            {
                {
                    Product.SauceDuckRice, 1
                }
            },
            ExtraAmount = 20
        });

        _prizeRepository.Received().GetPrizeBy(Arg.Any<List<Product>>());
    }

    [Test]
    public void should_insert_order_with_total_amount()
    {
        GivenProductPrice(new PriceDomain
        {
            Product = Product.SauceDuckRice,
            PriceAmount = 20
        });

        WhenOrder(new OrderDto
        {
            OrderedProductsAndAmount = new Dictionary<Product, int>
            {
                {
                    Product.SauceDuckRice, 2
                }
            },
            ExtraAmount = 20
        });

        _orderRepository.Received().SaveOrder(Arg.Is<OrderDomain>(o => o.TotalAmount == 60));
    }


    private void WhenOrder(OrderDto orderDto)
    {
        _ = _orderService.StoreOrder(orderDto);
    }

    private void GivenProductPrice( PriceDomain priceDomain)
    {
        _prizeRepository.GetPrizeBy(Arg.Any<List<Product>>()).Returns(new List<PriceDomain>()
        {
            priceDomain,
        });
    }
}