using System;

namespace CleanArchitecture.Domain.Entities
{
    public class Entity<TId>
    {
        private Entity()
        {

        }

        public Entity(TId id) : this()
        { 
            AuditDates = new AuditDates(DateTime.UtcNow, DateTime.UtcNow);
            Id = id;
        }

        /// <summary>
        /// Entity identifier.
        /// </summary>
        public TId Id { get; protected set; }

        public AuditDates AuditDates { get; protected set; }
    }
}