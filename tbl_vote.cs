//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OnlineVoting
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_vote
    {
        public int VoteID { get; set; }
        public int EventID { get; set; }
        public int CandidateID { get; set; }
        public int VoterID { get; set; }
        public System.DateTime VoteDateTime { get; set; }
    
        public virtual tbl_candidate tbl_candidate { get; set; }
        public virtual tbl_events tbl_events { get; set; }
        public virtual tbl_voter tbl_voter { get; set; }
    }
}
