using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Famoser.FrameworkEssentials.View.Commands;
using Famoser.KaeptnRage.Business.Models;
using Famoser.KaeptnRage.Business.Repositories.Interfaces;
using Famoser.KaeptnRage.View.ViewModels.Base;

namespace Famoser.KaeptnRage.View.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly IPlayItemRepository _playItemRepository;
        public MainViewModel(IPlayItemRepository playItemRepository)
        {
            _playItemRepository = playItemRepository;
            if (IsInDesignMode)
                MainText = "Hallo Welt (design)";
            else
                MainText = "Hallo Welt (not design)";

            PlayModels = _playItemRepository.GetPlayModels();
            PlayFileCommand = new LoadingRelayCommand<PlayModel>(PlayFile);
            RefreshCommand = new LoadingRelayCommand(Refresh);
        }
        public string MainText { get; }
        public ObservableCollection<PlayModel> PlayModels { get; set; }

        public ICommand PlayFileCommand { get; }

        private void PlayFile(PlayModel item)
        {

        }

        public ICommand RefreshCommand { get; }

        private async Task Refresh()
        {
            await _playItemRepository.RefreshAsync();
        }
    }
}
