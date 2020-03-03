using System;
using Microsoft.Extensions.Configuration.Mustache;

namespace Microsoft.Extensions.Configuration
{
    public static class MustacheConfigurationBuilderExtensions
    {
        public static IConfigurationBuilder AddMustache(this IConfigurationBuilder builder)
            => AddMustache(builder, _ => { });

        public static IConfigurationBuilder AddMustache(this IConfigurationBuilder builder, Action<MustacheConfigurationOptions> configureOptions)
        {
            var options = new MustacheConfigurationOptions();
            configureOptions(options);

            var currentConfig = builder.Build();

            return builder.Add(new MustacheConfigurationSource(currentConfig, options));
        }
    }
}