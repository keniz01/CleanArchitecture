namespace CleanArchitecture.Domain.Entities
{
    public class Entity<TId> : IEntity<TId>
    {
        private Entity()
        {

        }

        public Entity(TId id) : this() => Id = id;

        /// <summary>
        /// Entity identifier.
        /// </summary>
        public TId Id { get; protected set; }

    }
}