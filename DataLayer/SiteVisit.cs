//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataLayer
{
    using System.ComponentModel.DataAnnotations;
    using System;
    using System.Collections.Generic;
    
    [MetadataType(typeof(SiteVisitMetaData))]
    public partial class SiteVisit
    {
        public int VisitID { get; set; }
        public string IP { get; set; }
        public System.DateTime Date { get; set; }
    }
}
