using System;
using CleanArchitecture.Domain.Entities;
using NUnit.Framework;

namespace CleanArchitecture.Domain.Tests
{
    [TestFixture]
    public class AuditDatesTests
    {
        [Test]
        public void AuditDates_Should_return_the_same_dates_as_set_at_initialization()
        {
            var currentDateTime = DateTime.UtcNow;
            var createdDate = currentDateTime;
            var modifiedDate = currentDateTime;

            var auditDates = new AuditDates(createdDate, modifiedDate);
            Assert.IsTrue(DateTime.Compare(createdDate, auditDates.CreatedDate) == 0 
                          && DateTime.Compare(modifiedDate, auditDates.ModifiedDate) == 0);
        }
    }
}