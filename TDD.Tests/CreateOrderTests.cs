
using FluentAssertions;
using TDD.Project;
using TDD.Project.Exceptions;
using TDD.Project.Repositories;
using TDD.Tests.Fakes;

namespace TDD.Tests
{
    public class CreateOrderTests
    {
        [Fact]
        public async Task GivenAnInvalidBasketId_ThenThrowBasketNotFoundException()
        {
            IBasketRepository basketRepository = new FakeBasketRepository();

            var service = new OrderService(basketRepository, new FakeOrderRepository());

            var action = () => service.CreateOrderAsync(10, ShippingAddress(), default(CancellationToken));

            await action.Should().ThrowAsync<BasketNotFoundException>();
        }

        [Fact]
        public async Task GivenNullShippingAddress_ThenThrowArgumentNullException()
        {
            IBasketRepository basketRepository = new FakeBasketRepository();

            var service = new OrderService(basketRepository, new FakeOrderRepository());

            var action = () => service.CreateOrderAsync(10, null, default(CancellationToken));

            await action.Should().ThrowAsync<ArgumentNullException>();

        }

        [Fact]
        public async Task GivenValidBasket_ThenAddOrderToRepository()
        {
            const int basketId = 1;
            var basketRepository = new FakeBasketRepository();
            basketRepository.Add(basketId, new Basket());
            

            var orderRepository = new FakeOrderRepository();

            var service = new OrderService(basketRepository, orderRepository);

            await service.CreateOrderAsync(basketId, ShippingAddress(), default(CancellationToken));

            orderRepository.Get(basketId).Should().NotBeNull();


        }

        private static Address ShippingAddress()
            => new Address("912 Lebeau St", "Arabi", "LA", "70032");

    }

    
}
