using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace NRLLadderERPSite.Models
{
    // Format output for all Numbers in each Table as Non-decimal
    public class TeamMetadata
    {
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public string Played;
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public string Points;
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public string Wins;
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public string Draw;
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public string Lost;
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public string Byes;
    }

    public class SeasonMetaData
    {
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public string Season_For;
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public string Season_Against;
    }

    public class LadderMetaData
    {
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public string Position;
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public string Ladder_Dif;
    }
}