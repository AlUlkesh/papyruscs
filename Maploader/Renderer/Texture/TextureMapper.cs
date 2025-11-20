using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Maploader.Renderer.Texture
{
    public static class TextureMapper
    {
        private static Dictionary<string, string> _mappings = new Dictionary<string, string>();

        static TextureMapper()
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "texture_mappings.json");
            if (File.Exists(path))
            {
                try
                {
                    var json = File.ReadAllText(path);
                    var loaded = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
                    if (loaded != null)
                    {
                        foreach (var kvp in loaded)
                        {
                            _mappings[kvp.Key] = kvp.Value;
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Could not load texture mappings: {e.Message}");
                }
            }
        }

        public static string Map(string textureName)
        {
            if (_mappings.TryGetValue(textureName, out var mappedName))
            {
                return mappedName;
            }
            return textureName;
        }
    }
}
