//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CourtCaseApi.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CaseJudge
    {
        public int CaseJudgeID { get; set; }
        public string JudgmentDate { get; set; }
        public string CaseStatus { get; set; }
        public string JudgeDescription { get; set; }
        public int CaseID { get; set; }
    
        public virtual Case Case { get; set; }
    }
}
