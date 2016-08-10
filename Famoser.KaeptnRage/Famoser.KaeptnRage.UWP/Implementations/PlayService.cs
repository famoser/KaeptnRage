using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Xaml.Controls;
using Famoser.FrameworkEssentials.UniversalWindows.Enums;
using Famoser.FrameworkEssentials.UniversalWindows.Platform;
using Famoser.KaeptnRage.View.Services.Interfaces;

namespace Famoser.KaeptnRage.UWP.Implementations
{
    public class PlayService : StorageService, IPlayService
    {
        private readonly MediaElement _mediaElement = new MediaElement { AudioCategory = Windows.UI.Xaml.Media.AudioCategory.Media };
        
        public async void StartFilePlay(string fileName)
        {
            var folder = GetFolder(FolderType.CacheFolder);
            StorageFile sf = await folder.GetFileAsync(fileName);
            _mediaElement.SetSource(await sf.OpenAsync(FileAccessMode.Read), sf.ContentType);
            _mediaElement.Play();
        }
    }
}
