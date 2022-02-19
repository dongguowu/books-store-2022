using Ardalis.Specification;

namespace BooksStore.SharedKernel.Interfaces;

public interface IReadRepository<T> : IReadRepositoryBase<T> where T : BaseEntity, IAggregateRoot
{
}
