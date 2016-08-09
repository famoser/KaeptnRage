using Famoser.KaeptnRage.View.Models;
using Xamarin.Forms;

namespace Famoser.KaeptnRage.View.Pages.PageElements
{
    public class PlayItemCell : TextCell
    {
        private PlayItem _playItem;

        public PlayItemCell(PlayItem item)
        {
            _playItem = item;
        }
    }
}
