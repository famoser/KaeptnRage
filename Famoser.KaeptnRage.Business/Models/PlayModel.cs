﻿using System;
using Famoser.KaeptnRage.Business.Models.Base;
using Newtonsoft.Json;

namespace Famoser.KaeptnRage.Business.Models
{
    public class PlayModel : BaseModel
    {
        public string FileName { get; set; }
        public DateTime ChangeDate { get; set; }

        [JsonIgnore]
        public string Name => FileName.Substring(0, FileName.IndexOf("-", StringComparison.Ordinal));

        [JsonIgnore]
        public string Author => FileName.Substring(FileName.IndexOf("-", StringComparison.Ordinal) + 1);

    }
}
