using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NRLLadderERPSite.Models
{
    public class LadderResults
    {
        // Model Class Getters and Setters for Table Lists
        public Team teamlist { get; set; }
        public Season seasonlist { get; set; }
        public Ladder ladderlist { get; set; }
    }
}