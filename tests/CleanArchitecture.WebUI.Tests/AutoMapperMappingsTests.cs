using AutoMapper;
using NUnit.Framework;

namespace CleanArchitecture.WebUI.Tests
{
    [TestFixture]
    public class AutoMapperMappingsTests
    {
        [Test]
        public void WebUi_AutoMapper_Should_Confirm_mappings_are_valid()
        {
            var mappingConfig = new MapperConfiguration(mc => { mc.AddProfile(new MappingProfile()); });
            mappingConfig.AssertConfigurationIsValid();
        }
    }
}