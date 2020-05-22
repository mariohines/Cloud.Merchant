namespace Cloud.Merchant.Business.Core.Extensions
{
    public static class StringExtensions
    {
        public static bool HasValue(this string source) {
            return !string.IsNullOrWhiteSpace(source);
        }
    }
}