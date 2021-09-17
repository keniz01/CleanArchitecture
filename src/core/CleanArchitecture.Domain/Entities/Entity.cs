using CleanArchitecture.Domain.Exceptions;

namespace CleanArchitecture.Domain.Entities
{
    public class Entity<TId> : IEntity<TId>
    {
        /// <summary>
        /// Entity identifier.
        /// </summary>
        public TId Id { get; }

        public Entity(TId id) => Id = id.Validate();
    }
}