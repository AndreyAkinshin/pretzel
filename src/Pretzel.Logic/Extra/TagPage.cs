using System.IO;
using System.Linq;
using Pretzel.Logic.Extensibility;
using Pretzel.Logic.Extensions;
using Pretzel.Logic.Templating.Context;

namespace Pretzel.Logic.Extra
{
    public class TagPage : IBeforeProcessingTransform
    {
        private readonly string BaseUrl = Path.Combine("blog", "tag");

        public void Transform(SiteContext siteContext)
        {
            foreach (var lang in new[] {"en", "ru"})
            foreach (var tag in siteContext.Tags.Where(t => t.Posts.Any(p => p.Lang == lang)))
            {
                var layout = lang == "en" ? "blog-tag" : "ru-blog-tag";
                var tagUrl = UrlAliasFilter.UrlAlias(tag.Name);
                var langPrefix = lang == "en" ? "" : "/ru";
                var p = new Page
                {
                    Content = $"---\r\n layout: {layout} \r\n---\r\n",
                    File = Path.Combine(siteContext.SourceFolder, langPrefix, BaseUrl, tagUrl, "index.html"),
                    Filepath = Path.Combine(siteContext.OutputFolder, langPrefix, BaseUrl, tagUrl, "index.html"),
                    OutputFile = Path.Combine(siteContext.OutputFolder, langPrefix, BaseUrl, tagUrl, "index.html"),
                    Bag = $"---\r\n layout: {layout} \r\n---\r\n".YamlHeader()
                };

                p.Url = new LinkHelper().EvaluateLink(siteContext, p);
                p.Bag["target-tag"] = tag.Name;
                p.Bag["target-tag-url"] = tagUrl;
                p.Bag["target-tag-lang"] = lang;
                Tracing.Debug("TAGPAGE: " + p.Url);

                siteContext.Pages.Add(p);
            }
        }
    }
}
