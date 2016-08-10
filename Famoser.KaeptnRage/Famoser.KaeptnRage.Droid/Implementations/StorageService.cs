using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Android.Content;
using Famoser.FrameworkEssentials.Services.Interfaces;
using Famoser.KaeptnRage.View.Services.Interfaces;
using Java.IO;

namespace Famoser.KaeptnRage.Droid.Implementations
{
    public class StorageService : IStorageService
    {
        public static Context Context;

        public async Task<string> GetCachedTextFileAsync(string filePath)
        {
            UTF8Encoding enc = new UTF8Encoding();
            var bytes = await GetCachedFileAsync(filePath);
            return enc.GetString(bytes, 0, bytes.Length);
        }

        public Task<bool> SetCachedTextFileAsync(string filePath, string content)
        {
            UTF8Encoding enc = new UTF8Encoding();
            var bytes = enc.GetBytes(content);
            return SetCachedFileAsync(filePath, bytes);
        }

        public async Task<byte[]> GetCachedFileAsync(string filePath)
        {
            var inp = Context.OpenFileInput(filePath);
            
            using (var streamReader = new MemoryStream())
            {
                await inp.CopyToAsync(streamReader);
                return streamReader.ToArray();
            }
        }

        public async Task<bool> SetCachedFileAsync(string filePath, byte[] content)
        {
            using (var stream = Context.OpenFileOutput(filePath, FileCreationMode.WorldWriteable))
            {
                await stream.WriteAsync(content, 0, content.Length);
            }
            return true;
        }

        public async Task<bool> DeleteCachedFileAsync(string filePath)
        {
            Context.DeleteFile(filePath);
            return true;
        }

        public Task<string> GetRoamingTextFileAsync(string filePath)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SetRoamingTextFileAsync(string filePath, string content)
        {
            throw new NotImplementedException();
        }

        public Task<byte[]> GetRoamingFileAsync(string filePath)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SetRoamingFileAsync(string filePath, byte[] content)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteRoamingFileAsync(string filePath)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetAssetTextFileAsync(string filePath)
        {
            throw new NotImplementedException();
        }

        public Task<byte[]> GetAssetFileAsync(string filePath)
        {
            throw new NotImplementedException();
        }
    }
}