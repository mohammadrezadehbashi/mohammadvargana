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
    public class Product_CommentsMetaData
    {
        public int CommentID { get; set; }
        public int ProductID { get; set; }
        [Display(Name ="نام")]
        [Required(ErrorMessage ="لطفا {0} را وارد نمایید")]
        public string Name { get; set; }
        [Display(Name ="ایمیل")]
        [Required(ErrorMessage ="لطفا {0} را وارد نمایید")]
        public string Email { get; set; }
        [Display(Name ="وب سایت")]
        
        public string Website { get; set; }
        [Display(Name ="دیدگاه")]
        [Required(ErrorMessage ="لطفا {0} را وارد نمایید")]
        public string Comment { get; set; }
        
    }
}