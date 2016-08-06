using System.Collections.ObjectModel;
using System.Windows.Input;
using Famoser.FrameworkEssentials.View.Commands;
using Famoser.KaeptnRage.View.Models;
using Famoser.KaeptnRage.View.ViewModels.Base;

namespace Famoser.KaeptnRage.View.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public MainViewModel()
        {
            if (IsInDesignMode)
                MainText = "Hallo Welt (design)";
            else
                MainText = "Hallo Welt (not design)";

            PageItems = new ObservableCollection<PlayItem>()
            {
                new PlayItem()
                {
                    Name = "File1",
                    Author = "2:23",
                    FileName = "file1.mp4"
                },
                new PlayItem()
                {
                    Name = "File2",
                    Author = "1:23",
                    FileName = "file2.mp4"
                },
                new PlayItem()
                {
                    Name = "File3",
                    Author = "0:23",
                    FileName = "file3.mp4"
                }
            };
            PlayFileCommand = new LoadingRelayCommand<PlayItem>(PlayFile);
        }
        public string MainText { get; }
        public ObservableCollection<PlayItem> PageItems { get; set; }

        public ICommand PlayFileCommand { get; set; }

        private void PlayFile(PlayItem item)
        {
            
        }
    }
}
