using System;
using System.Collections.Generic;
using System.Linq;
using DotLiquid;

namespace Pretzel.Logic.Templating.Context
{
    public class Paginator : Drop
    {
        private readonly SiteContext site;
        private readonly string lang;

        public int TotalPages { get; set; }
        public int TotalPosts { get; set; }
        public int PerPage { get; set; }
        public int PreviousPage { get { return Page - 1; } }
        public int NextPage { get { return Page + 1; } }
        public string PreviousPageUrl { get; set; }
        public string NextPageUrl { get; set; }
        public int Page { get; set; }

        private IList<Page> posts;
        public IList<Page> Posts
        {
            get { return posts ?? (posts = site.Posts.Where(p => p.Lang == lang).Skip((Page-1) * PerPage).Take(PerPage).ToList()); }
        }

        public Paginator(SiteContext site, int totalPages, int perPage, int page, string lang)
        {
            this.site = site;
            this.lang = lang;
            TotalPosts = site.Posts.Count(p => p.Lang == lang);
            TotalPages = totalPages;
            PerPage = perPage;
            Page = page;
        }
    }
}
