using System;
using Cloud.Merchant.Persistence.Core;

namespace Cloud.Merchant.Persistence.Orchestration.Extensions
{
    public static class DbProviderExtensions
    {
        public static string GetAutoGeneratedIdSyntax(this DbProvider source) {
            return source switch {
                DbProvider.MySql => "last_inserted_id()",
                DbProvider.SqlServer => "scope_identity()",
                _ => throw new ArgumentOutOfRangeException(nameof(source), source, null)
            };
        }

        public static string GetUtcDateSyntax(this DbProvider source) {
            return source switch {
                DbProvider.MySql => "utc_timestamp()",
                DbProvider.SqlServer => "getutcdate()",
                _ => throw new ArgumentOutOfRangeException(nameof(source), source, null)
            };
        }
    }
}