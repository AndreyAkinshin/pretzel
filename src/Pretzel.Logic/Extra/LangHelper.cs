namespace Pretzel.Logic.Extra
{
    public static class LangHelper
    {
        private static string WithoutIndex(string url) => url.EndsWith("index.html") ? url.Substring(0, url.Length - "index.html".Length) : url;

        public static string ToRu(string url) => WithoutIndex(!url.StartsWith("/ru") ? "/ru" + url : url);

        public static string ToEn(string url) => WithoutIndex(url.StartsWith("/ru") ? url.Substring(3) : url);
    }
}
