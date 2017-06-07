using DotLiquid;
using System.Collections.Generic;
using System.Linq;

namespace Pretzel.Logic.Templating.Context
{
    public class Tag : Drop
    {
        public IEnumerable<Page> Posts { get; set; }
        public IList<Page> RuPosts => Posts.Where(p => p.Lang == "ru").ToList();
        public IList<Page> EnPosts => Posts.Where(p => p.Lang == "en").ToList();

        public string Name { get; set; }

        public Tag()
        {
            Posts = new List<Page>();
        }
    }
}
