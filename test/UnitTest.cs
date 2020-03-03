using System;
using Xunit;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.Configuration.Mustache.UnitTest
{
    public class UnitTest
    {
        [Fact]
        public void Test()
        {
            var config1 = new Dictionary<string,string>()
            {
                {"key", "{{guesswhat}}"}
            }.ToList();

            var config2 = new Dictionary<string,string>()
            {
                {"guesswhat", "aha"}
            }.ToList();
            
            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(config1)
                .AddInMemoryCollection(config2)
                .AddMustache()
                .Build();

            Assert.Equal("aha", configuration["key"]);
        }
    }
}
