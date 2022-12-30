using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD.Project.Repositories
{
    public interface IOrderRepository
    {
        public Task AddAsync(Order order, CancellationToken cancellationToken);
    }
}
