using System;

namespace CleanArchitecture.Domain.Entities
{
    public class AuditDates
    {
        public AuditDates(DateTime createdDate, DateTime modifiedDate)
        {
            ModifiedDate = modifiedDate == DateTime.MinValue ? modifiedDate : DateTime.UtcNow;
            CreatedDate = createdDate == DateTime.MinValue ? createdDate : DateTime.UtcNow;
        }

        public DateTime CreatedDate { get; protected set; }

        public DateTime ModifiedDate { get; protected set; }

        public AuditDates UpdateModifiedDate(DateTime modifiedDate)
        {
            ModifiedDate = modifiedDate;
            return this;
        }
    }
}