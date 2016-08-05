using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Famoser.KaeptnRage.Models;
using Famoser.KaeptnRage.ViewModels.Base;

namespace Famoser.KaeptnRage.ViewModels
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
                    FileName = "file1.mp4"
                },
                new PlayItem()
                {
                    Name = "File2",
                    FileName = "file2.mp4"
                },
                new PlayItem()
                {
                    Name = "File3",
                    FileName = "file3.mp4"
                }
            };
        }
        public string MainText { get; }
        public ObservableCollection<PlayItem> PageItems { get; set; }

        public ICommand Command { get; set; }
    }
}
