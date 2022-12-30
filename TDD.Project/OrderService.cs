using Microsoft.AspNetCore.Mvc;
using TDD.Project.Exceptions;
using TDD.Project.Repositories;

namespace TDD.Project
{
    public class OrderService
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IOrderRepository _orderRepository;

        public OrderService(IBasketRepository basketRepository, IOrderRepository orderRepository)
        {
            _basketRepository = basketRepository;
            _orderRepository = orderRepository;
        }

        public async Task CreateOrderAsync(int basketId, Address address, CancellationToken cancellationToken)
        {
            if (address is null)
                throw new ArgumentNullException();

            var basket = await _basketRepository.GetAsync(basketId, cancellationToken);

            if (basket is null)
                throw new BasketNotFoundException();

            var order = new Order(basketId);

            await _orderRepository.AddAsync(order, cancellationToken);

        }
    }
}
