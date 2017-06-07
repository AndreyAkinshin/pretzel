using System.Collections.Generic;
using Pretzel.Logic.Extensibility;
using Pretzel.Logic.Extensibility.Extensions;

namespace Pretzel.Logic.Extra
{
    public class UrlAliasFilter : IFilter
    {
        private static readonly Dictionary<string, string> Aliases = new Dictionary<string, string>
        {
            {".net", "dotnet"},
            {"c#", "csharp"}
        };

        public string Name => "UrlAlias";

        public static string UrlAlias(string title)
        {
            title = title.ToLowerInvariant();
            return Aliases.ContainsKey(title) ? Aliases[title] : SlugifyFilter.Slugify(title);
        }
    }
}
