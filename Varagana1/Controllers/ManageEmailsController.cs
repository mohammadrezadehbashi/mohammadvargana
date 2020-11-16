using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Varagana1.Controllers
{
    public class ManageEmailsController : Controller
    {
        
        public ActionResult ActivationEmails()
        {
            return PartialView();
        }
        public ActionResult RecoveryPassword()
        {
            return PartialView();
        }
           
       
    }
}