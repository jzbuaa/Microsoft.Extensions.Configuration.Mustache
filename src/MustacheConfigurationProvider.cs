using System;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.Configuration.Mustache
{
    internal class MustacheConfigurationProvider : ConfigurationProvider, IConfigurationProvider
    {
        private readonly IConfiguration _innerConfiguration;
        private readonly string _open;
        private readonly string _close;
        internal MustacheConfigurationProvider(IConfiguration configuration, string open, string close)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }
            if (string.IsNullOrEmpty(open))
            {
                throw new ArgumentNullException(nameof(open));
            }
            if (string.IsNullOrEmpty(close))
            {
                throw new ArgumentNullException(nameof(close));
            }

            this._innerConfiguration = configuration;
            this._open = open;
            this._close = close;
        }

        public override bool TryGet(string key, out string value)
        {
            value = null;

            var innerValue = _innerConfiguration[key];
            if (innerValue == null)
            {
                return false;
            }

            if (innerValue.StartsWith(this._open, StringComparison.Ordinal) && innerValue.EndsWith(this._close, StringComparison.Ordinal))
            {
                var templateKey = innerValue.Substring(this._open.Length, innerValue.Length - this._close.Length - this._open.Length); // remove open & close.
                value = this._innerConfiguration[templateKey];
            }

            if (value == null)
            {
                value = innerValue;
            }
            
            return true;
        }
    }
}