using AutoMapper;
using NUnit.Framework;

namespace CleanArchitecture.WebApi.Tests
{
    [TestFixture]
    public class AutoMapperTests
    {
        [Test]
        public void WebApi_AutoMapper_Should_Confirm_mappings_are_valid()
        {
            var mappingConfig = new MapperConfiguration(mc => { mc.AddProfile(new MappingProfile()); });
            mappingConfig.AssertConfigurationIsValid();
        }
    }
}