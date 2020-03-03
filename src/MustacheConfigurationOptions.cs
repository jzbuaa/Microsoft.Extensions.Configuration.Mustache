namespace Microsoft.Extensions.Configuration.Mustache
{
    public class MustacheConfigurationOptions
    {
        public string Open { get; set; } = "{{";
        public string Close { get; set; } = "}}";
    }
}