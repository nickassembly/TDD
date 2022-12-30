namespace TDD.Project.Repositories
{
    public interface IBasketRepository
    {
        public Task<Basket?> GetAsync(int basketId, CancellationToken cancellationToken);
    }
}