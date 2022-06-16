using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace NRLLadderERPSite.Models
{
    // Table MetaData Declarations
    [MetadataType(typeof(TeamMetadata))]
    public partial class Team
    {
    }

    [MetadataType(typeof(SeasonMetaData))]
    public partial class Season
    {
    }

    [MetadataType(typeof(LadderMetaData))]
    public partial class Ladder
    {
    }
}