﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System.ComponentModel.DataAnnotations;
namespace DataLayer
{
    internal class FeaturesMetaData
    {
        [Key]
        public int FeatureID { get; set; }
        [Display(Name = "ویژگی")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public string FeatureTitle { get; set; }
    }
}