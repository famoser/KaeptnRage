using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Famoser.FrameworkEssentials.Services;
using Famoser.KaeptnRage.Data.Responses;
using Famoser.KaeptnRage.Data.Services.Interfaces;
using Newtonsoft.Json;

namespace Famoser.KaeptnRage.Data.Services
{
    public class DataService : IDataService
    {
        private const string BaseUrl = "https://api.kaeptnrage.famoser.ch";

        private readonly HttpService _httpService = new HttpService();
        public async Task<FilesResponse> GetFilesAsync()
        {
            var res = await _httpService.DownloadAsync(new Uri(BaseUrl + "/index.php"));
            var str = await res.GetResponseAsStringAsync();
            return JsonConvert.DeserializeObject<FilesResponse>(str);
        }

        public async Task<FileEntity> GetFileAsync(string fileName)
        {
            var res = await _httpService.DownloadAsync(new Uri(BaseUrl + "/sounds/" + fileName));
            var str = await res.GetResponseAsByteArrayAsync();
            return new FileEntity()
            {
                FileName = fileName,
                Bytes = str
            };
        }
    }
}
