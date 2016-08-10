using System;
using Famoser.KaeptnRage.Business.Models.Base;
using Newtonsoft.Json;

namespace Famoser.KaeptnRage.Business.Models
{
    public class PlayModel : BaseModel
    {
        public string FileName { get; set; }
        public DateTime ChangeDate { get; set; }

        [JsonIgnore]
        public string Author => FileName.Substring(0, FileName.IndexOf("-", StringComparison.Ordinal)).Trim();

        [JsonIgnore]
        public string Name
        {
            get
            {
                //split name
                var temp = FileName.Substring(FileName.IndexOf("-", StringComparison.Ordinal) + 1).Trim();
                //split file extension
                return temp.Substring(0, temp.LastIndexOf(".", StringComparison.Ordinal));
            }
        }

    }
}
