namespace CleanArchitecture.Domain.Entities
{
    public interface IEntity<out TId>
    {
        TId Id { get; }
    }
}