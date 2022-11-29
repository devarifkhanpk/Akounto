using Microsoft.AspNetCore.Mvc;
using Plan.Database;
using Plans.Business;
using Plans.Infrastructure;
using Plans.Payment.Entities.Billing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Akounto.Billing.Presentation.Controllers.Billing
{

    public class AddOnController : Controller
    {
        [Route("addon/index")]
        public IActionResult Index()
        {
            
            Response<List<AddOnModel>> response = null;
            try
            {
                response = BillingAddOn.GetAllAddOns();
                ViewData["resultData"] = response.Data;
                
            }
            catch(Exception ex)
            {

            }
            return View(response.Data.ToArray());

        }
    }
}
