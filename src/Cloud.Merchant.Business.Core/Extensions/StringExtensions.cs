using Cloud.Merchant.Business.Core.Helpers;
using static Utf8Json.JsonSerializer;

namespace Cloud.Merchant.Business.Core.Extensions
{
    public static class StringExtensions
    {
        public static bool HasValue(this string source) {
            return !string.IsNullOrWhiteSpace(source);
        }

        public static T FromJsonTo<T>(this string source) {
            var json = source;
            if (json.Contains("\"{") && json.Contains("}\""))
            {
                json = source.Replace("\"{", "{").Replace("}\"", "}");
            }
            
            return Deserialize<T>(json, SerializationHelper.Json.DefaultFormatterResolver);
        }
    }
}