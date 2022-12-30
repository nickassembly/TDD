using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDD.Project.Repositories;
using TDD.Project;

namespace TDD.Tests.Fakes
{
    // use Mock as alternative to this, but may not always be needed
    public class FakeBasketRepository : IBasketRepository
    {
        private Dictionary<int, Basket> _data = new();

        public Task<Basket?> GetAsync(int basketId, CancellationToken cancellationToken)
        {
            _data.TryGetValue(basketId, out var basket);

            return Task.FromResult(basket);
        }

        public void Add(int id, Basket data) => _data.Add(id, data);
    }
}
