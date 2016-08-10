using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Famoser.FrameworkEssentials.View.Commands;
using Famoser.KaeptnRage.Business.Models;
using Famoser.KaeptnRage.Business.Repositories.Interfaces;
using Famoser.KaeptnRage.View.Services.Interfaces;
using Famoser.KaeptnRage.View.ViewModels.Base;

namespace Famoser.KaeptnRage.View.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly IPlayItemRepository _playItemRepository;
        private readonly IPlayService _playService;
        public MainViewModel(IPlayItemRepository playItemRepository, IPlayService playService)
        {
            _playItemRepository = playItemRepository;
            _playService = playService;
            if (IsInDesignMode)
                MainText = "Hallo Welt (design)";
            else
                MainText = "Kaeptn Rage";

            PlayModels = _playItemRepository.GetPlayModels();
            PlayFileCommand = new LoadingRelayCommand<PlayModel>(t => PlayFile(t));
            RefreshCommand = new LoadingRelayCommand(Refresh, null, true);
        }

        public string MainText { get; }
        public ObservableCollection<PlayModel> PlayModels { get; set; }

        public ICommand PlayFileCommand { get; }

        private void PlayFile(PlayModel item)
        {
            _playService.StartFilePlay(item.FileName);
        }

        public ICommand RefreshCommand { get; }

        private async Task Refresh()
        {
            await _playItemRepository.RefreshAsync();
        }
    }
}
