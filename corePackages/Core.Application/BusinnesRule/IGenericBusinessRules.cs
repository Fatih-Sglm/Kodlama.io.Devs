namespace Core.Application.BusinnesRule
{
    public interface IGenericBusinessRules<T>
    {
        Task CanNotDuplicate(string name);
        Task CannotBeNull(T item);
    }
}
