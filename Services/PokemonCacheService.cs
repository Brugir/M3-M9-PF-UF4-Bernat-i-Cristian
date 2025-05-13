using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using PokeDexWeb.Models;

namespace PokeDexWeb.Services
{
    public class PokemonCacheService
    {
        private readonly string _cacheDir;
        public PokemonCacheService(string cacheDir = "Cache")
        {
            _cacheDir = cacheDir;
            if (!Directory.Exists(_cacheDir))
                Directory.CreateDirectory(_cacheDir);
        }

        private string GetPath(string key) => Path.Combine(_cacheDir, key + ".json");

        public async Task<T?> GetFromCacheAsync<T>(string key) where T : class
        {
            string path = GetPath(key);
            if (!File.Exists(path)) return null;
            try
            {
                using var stream = File.OpenRead(path);
                return await JsonSerializer.DeserializeAsync<T>(stream);
            }
            catch { return null; }
        }

        public async Task SaveToCacheAsync<T>(string key, T data) where T : class
        {
            string path = GetPath(key);
            using var stream = File.Create(path);
            await JsonSerializer.SerializeAsync(stream, data, new JsonSerializerOptions { WriteIndented = false });
        }
    }
}
