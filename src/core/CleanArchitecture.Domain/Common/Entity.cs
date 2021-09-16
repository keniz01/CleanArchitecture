namespace CleanArchitecture.Domain.Common
{
    public class Entity<TId> : IEntity<TId>
    {
        public TId Id { get; }

        public Entity(TId id) => Id = id.Validate();
    }
}
