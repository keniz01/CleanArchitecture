using System;

namespace CleanArchitecture.Domain.Entities
{
    public class AuditDates
    {
        public AuditDates(DateTime createdDate, DateTime modifiedDate)
        {
            ModifiedDate = modifiedDate == DateTime.MinValue ? DateTime.UtcNow : modifiedDate;
            CreatedDate = createdDate == DateTime.MinValue ? DateTime.UtcNow : createdDate;
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