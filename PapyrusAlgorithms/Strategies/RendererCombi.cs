using System.Collections.Generic;
using Maploader.Renderer;
using Maploader.Renderer.Imaging;
using Maploader.Renderer.Texture;
using Maploader.Core;

namespace PapyrusAlgorithms.Strategies
{
    class RendererCombi<TImage> : IResettable where TImage : class
    {
        public TextureFinder<TImage> Finder { get; }
        public ChunkRenderer<TImage> ChunkRenderer { get; }

        public RendererCombi(Dictionary<string, Texture> textureDictionary, string texturePath, RenderSettings renderSettings, IGraphicsApi<TImage> graphics)
        {
            Finder = new TextureFinder<TImage>(textureDictionary, texturePath, graphics);
            ChunkRenderer = new ChunkRenderer<TImage>(Finder, graphics, renderSettings);
        }

        public void Reset()
        {
            ChunkRenderer.Reset();
        }
    }
}