//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NRLLadderERPSite.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Ladder
    {
        public int PKFK_TeamID { get; set; }
        public Nullable<int> Position { get; set; }
        public Nullable<int> Ladder_Dif { get; set; }
    
        public virtual Team Team { get; set; }
    }
}
