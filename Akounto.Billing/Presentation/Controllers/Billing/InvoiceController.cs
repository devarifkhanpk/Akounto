
using Akounto.Billing.Gateways;
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

    public class InvoiceController : Controller
    {
        [Route("Invoice")]
        public async Task<ActionResult> Index()
        { 
            try
            {
                IGateway _gateway = BaseController.GetGateway(PaymentGatewayType.Stripe);
                InvoiceModel InvoiceInfo =  await _gateway.Invoice.GetById("cus_MvBe9uwf4Bx6Ir");

                //InvoiceModel InvoiceInfo = null;


              
                return View(InvoiceInfo);
            }
            catch (Exception ex)
            {

            }
            return View();

        }
      
    }
}
