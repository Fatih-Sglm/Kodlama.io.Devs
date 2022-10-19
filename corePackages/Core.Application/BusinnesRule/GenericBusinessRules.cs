using Core.CrossCuttingConcerns.Exceptions;
using Core.Domain.Base;

namespace Core.Application.BusinnesRule
{
    public abstract class GenericBusinessRules<T> where T : class, IEntity, new()
    {
        public virtual Task CannotBeNull(T item)
        {
            if (item is null)
                throw new NotFoundException($"Requested {nameof(T).ToLower()}  does not exist");
            return Task.CompletedTask;
        }
        public abstract Task CanNotDuplicate(string name);

    }
}
