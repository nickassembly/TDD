using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDD.Project;
using TDD.Project.Repositories;

namespace TDD.Tests.Fakes
{
    public class FakeOrderRepository : IOrderRepository
    {
        private Dictionary<int, Order> _data = new();

        public Task AddAsync(Order? order, CancellationToken cancellationToken)
        {
            _data.Add(order.BasketId, order);

            return Task.CompletedTask;

        }

        public Order? Get(int basketId)
        {
            _data.TryGetValue(basketId, out var order);
            return order;
        }
    }
}
