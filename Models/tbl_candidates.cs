using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineVoting.Models
{
    public class tbl_candidates
    {
        public int CandidateID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public System.DateTime BirthDate { get; set; }
        public string Nationality { get; set; }
        public byte[] Photo { get; set; }
        public string Description { get; set; }
    }
}