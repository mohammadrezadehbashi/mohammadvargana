﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace DataLayer
{
   public class RolesMetaData
    {
        [Key]
        public int RoleID { get; set; }
        [Display(Name ="عنوان نقش")]
        [Required(ErrorMessage ="لطفا {0} را وارد کنید"  )]
        public string RoleTitle { get; set; }
        [Display(Name = "عنوان سیستمی نقش")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string RoleName { get; set; }
    }
}
