using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Famoser.KaeptnRage.Data.Responses;

namespace Famoser.KaeptnRage.Data.Services.Interfaces
{
    public interface IDataService
    {
        Task<FilesResponse> GetFilesAsync();

        Task<FileEntity> GetFileAsync(string fileName);
    }
}
