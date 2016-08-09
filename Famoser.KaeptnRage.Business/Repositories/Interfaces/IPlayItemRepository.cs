using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Famoser.KaeptnRage.Business.Models;

namespace Famoser.KaeptnRage.Business.Repositories.Interfaces
{
    public interface IPlayItemRepository
    {
        ObservableCollection<PlayModel> GetPlayModels();
        Task RefreshAsync();
    }
}
