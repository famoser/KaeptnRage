using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Famoser.KaeptnRage.Business.Models;
using Famoser.KaeptnRage.Business.Repositories.Interfaces;

namespace Famoser.KaeptnRage.Business.Repositories
{
    public class PlayItemRepository : IPlayItemRepository
    {
        public ObservableCollection<PlayModel> GetPlayModels()
        {
            throw new NotImplementedException();
        }
    }
}
