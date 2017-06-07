using System.ComponentModel.Composition;
using Markdig;
using Pretzel.Logic.Extensibility;

namespace Pretzel.Logic.Extra
{
    [Export(typeof(ILightweightMarkupEngine))]
    public sealed class MarkdigEngine : ILightweightMarkupEngine
    {
        private readonly MarkdownPipeline pipeline;

        public MarkdigEngine()
        {
            pipeline = new MarkdownPipelineBuilder().UseAdvancedExtensions().UseEmojiAndSmiley().Build();
        }

        public string Convert(string markdownContent)
        {
            return Markdown.ToHtml(markdownContent, pipeline);
        }
    }
}
