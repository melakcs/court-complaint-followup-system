
namespace CourtCaseApi.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Anouncement
    {
        public int AnouncementID { get; set; }
        public string AnouncementType { get; set; }
        public string Date { get; set; }
        public string Description { get; set; }
    }
}
