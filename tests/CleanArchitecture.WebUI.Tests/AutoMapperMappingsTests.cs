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
            var mapperConfiguration = new MapperConfiguration(config => { config.AddProfile(new MappingProfile()); });
            mapperConfiguration.AssertConfigurationIsValid();
        }
    }
}