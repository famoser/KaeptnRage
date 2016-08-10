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
                    FileName = "Hey nääi - Mario.mp4"
                },
                new PlayModel()
                {
                    FileName = "Was geht! - Renato.mp4"
                },
                new PlayModel()
                {
                    FileName = "Hallo Welt - langer muss.mp4"
                }
            };
        }

        public async Task RefreshAsync()
        {
            return;
        }
    }
}
