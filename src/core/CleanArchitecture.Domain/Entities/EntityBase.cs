using System;

namespace CleanArchitecture.Domain.Entities
{
    public class EntityBase
    {
        private EntityBase()
        {

        }

        public EntityBase(Guid id) : this()
        { 
            AuditDates = new AuditDates(DateTime.UtcNow, DateTime.UtcNow);
            Id = id;
        }

        /// <summary>
        /// EntityBase identifier.
        /// </summary>
        public Guid Id { get; protected set; }

        public AuditDates AuditDates { get; protected set; }
    }
}