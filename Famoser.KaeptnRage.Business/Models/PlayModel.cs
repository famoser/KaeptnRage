using Famoser.KaeptnRage.Business.Models.Base;

namespace Famoser.KaeptnRage.Business.Models
{
    public class PlayModel : BaseModel
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public string FileName { get; set; }
    }
}
