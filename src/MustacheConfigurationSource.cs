using System;
using Microsoft.Extensions.Configuration;
namespace Microsoft.Extensions.Configuration.Mustache
{
    public class MustacheConfigurationSource : IConfigurationSource
    {
        private readonly IConfiguration _innerConfiguration;
        private readonly MustacheConfigurationOptions _options;

        public MustacheConfigurationSource(IConfiguration configuration, MustacheConfigurationOptions options)
        {
            this._innerConfiguration = configuration;
            this._options = options;
        }
        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return new MustacheConfigurationProvider(this._innerConfiguration, _options.Open, _options.Close);
        }
    }
}
