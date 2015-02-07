// Coded by Alex Danvy
// http://danvy.tv
// http://twitter.com/danvy
// http://github.com/danvy
// Licence Apache 2.0
// Use at your own risk, have fun

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
