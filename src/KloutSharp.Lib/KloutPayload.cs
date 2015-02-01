using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KloutSharp.Lib
{
    public class KloutPayload
    {
        public string KloutId { get; set; }
        public string Nick { get; set; }
        public KloutScoreBase score { get; set; }
        public KloutScoreDeltas ScoreDeltas { get; set; }
    }
}
