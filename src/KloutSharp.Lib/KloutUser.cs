using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KloutSharp.Lib
{
    public class KloutUser
    {
        public string KloutId { get; set; }
        public string Nick { get; set; }
        [JsonProperty(PropertyName = "score")]
        public KloutScoreBase Score { get; set; }
        public KloutScoreDeltas ScoreDeltas { get; set; }
    }
    
    
 }
