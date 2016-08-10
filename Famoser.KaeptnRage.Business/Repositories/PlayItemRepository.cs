using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Famoser.FrameworkEssentials.Services.Interfaces;
using Famoser.KaeptnRage.Business.Models;
using Famoser.KaeptnRage.Business.Models.Storage;
using Famoser.KaeptnRage.Business.Repositories.Interfaces;
using Famoser.KaeptnRage.Data.Responses;
using Famoser.KaeptnRage.Data.Services.Interfaces;
using Newtonsoft.Json;
using Nito.AsyncEx;

namespace Famoser.KaeptnRage.Business.Repositories
{
    public class PlayItemRepository : IPlayItemRepository
    {
        private readonly IStorageService _storageService;
        private readonly IDataService _dataService;
        private const string CacheFileName = "playitems.json";

        public PlayItemRepository(IStorageService storageService, IDataService dataService)
        {
            _storageService = storageService;
            _dataService = dataService;
        }

        private readonly ObservableCollection<PlayModel> _playModels = new ObservableCollection<PlayModel>();
        public ObservableCollection<PlayModel> GetPlayModels()
        {
            return _playModels;
        }

        private bool _isInitialized;
        private readonly AsyncLock _asyncLock = new AsyncLock();

        private async Task Initialize()
        {
            using (await _asyncLock.LockAsync())
            {
                if (_isInitialized)
                    return;

                _isInitialized = true;
                var str = await _storageService.GetCachedTextFileAsync(CacheFileName);
                var items = JsonConvert.DeserializeObject<StorageModel>(str);
                foreach (var playModel in items.PlayModels)
                {
                    _playModels.Add(playModel);
                }
            }
        }

        public async Task RefreshAsync()
        {
            await Initialize();

            var files = await _dataService.GetFilesAsync();
            var currents = new List<PlayModel>(_playModels);
            var newOnes = new List<FileEntity>();
            foreach (var fileEntity in files.Files)
            {
                var oldOne = currents.FirstOrDefault(p => p.FileName == fileEntity.FileName);
                if (oldOne != null)
                    currents.Remove(oldOne);
                else
                    newOnes.Add(fileEntity);
            }

            foreach (var playModel in currents)
            {
                _playModels.Remove(playModel);
                await _storageService.DeleteCachedFileAsync(playModel.FileName);
            }

            foreach (var fileEntity in newOnes)
            {
                var entity = await _dataService.GetFileAsync(fileEntity.FileName);
                await _storageService.SetCachedFileAsync(fileEntity.FileName, entity.Bytes);
                var model = new PlayModel()
                {
                    FileName = fileEntity.FileName,
                    ChangeDate = fileEntity.ChangeDate
                };
                _playModels.Add(model);
            }

            var sm = new StorageModel()
            {
                PlayModels = new List<PlayModel>(_playModels)
            };
            await _storageService.SetCachedTextFileAsync(CacheFileName, JsonConvert.SerializeObject(sm));
        }
    }
}
