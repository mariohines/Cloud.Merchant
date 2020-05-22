using System.Collections.Generic;

namespace Cloud.Merchant.Domain.Models
{
    public sealed class UrlSettings
    {
        public IDictionary<string, string> Values { get; }

        public UrlSettings(IDictionary<string, string> values) {
            Values = values ?? new Dictionary<string, string>();
        }

        public void AddValue(string key, string value) {
            Values.TryAdd(key, value);
        }

        public void AddValues(IDictionary<string, string> values) {
            foreach (var pair in values) {
                Values.TryAdd(pair.Key, pair.Value);
            }
        }
    }
}