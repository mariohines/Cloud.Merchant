using Utf8Json;
using Utf8Json.Resolvers;

namespace Cloud.Merchant.Business.Core.Helpers
{
    public static class SerializationHelper
    {
        public static class Json
        {
            public static readonly IJsonFormatterResolver DefaultFormatterResolver =
                CompositeResolver.Create(EnumResolver.UnderlyingValue, StandardResolver.AllowPrivateExcludeNullCamelCase);
        }
    }
}