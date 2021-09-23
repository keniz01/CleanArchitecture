using CleanArchitecture.Domain.Exceptions;

namespace CleanArchitecture.Domain.Entities
{
    public class Entity<TId> : IEntity<TId>
    {
        private Entity()
        {
                
        }

        public Entity(TId id) : this() => Id = id.Validate();

        /// <summary>
        /// Entity identifier.
        /// </summary>
        public TId Id { get; protected set; }

    }
}