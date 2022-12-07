
using Microsoft.AspNetCore.Http;
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

    public class SubscriptionCancelController : Controller
    {
    
        [Route("SubscriptionCancel")]
        public IActionResult Index()
        {
            return View();

        }

        [Route("SubscriptionCancel/Cancelation")]
        [HttpPost]
        public IActionResult Cancelation()
        {
            var req = HttpContext.Request;
            SubscriptionCancelModel response = null;
            try
            {
                response = new SubscriptionCancelModel();
                response.Description = req.Form["Description"].ToString();

            }
            catch (Exception ex)
            {

            }
            return View(response);

        }

    }
}
