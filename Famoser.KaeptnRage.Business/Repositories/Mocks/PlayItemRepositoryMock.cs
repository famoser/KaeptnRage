using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Famoser.KaeptnRage.Business.Models;
using Famoser.KaeptnRage.Business.Repositories.Interfaces;

#pragma warning disable 1998
namespace Famoser.KaeptnRage.Business.Repositories.Mocks
{
    public class PlayItemRepositoryMock : IPlayItemRepository
    {
        public ObservableCollection<PlayModel> GetPlayModels()
        {
            return new ObservableCollection<PlayModel>()
            {
                new PlayModel()
                {
                    Name = "File1",
                    Author = "2:23",
                    FileName = "file1.mp4"
                },
                new PlayModel()
                {
                    Name = "File2",
                    Author = "1:23",
                    FileName = "file2.mp4"
                },
                new PlayModel()
                {
                    Name = "File3",
                    Author = "0:23",
                    FileName = "file3.mp4"
                }
            };
        }

        public async Task RefreshAsync()
        {
            return;
        }
    }
}
