
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

    public class AddOnController : Controller
    {
        [Route("addon/index")]
        public IActionResult Index()
        {
            
            Response<List<AddOnModel>> response = null;
            try
            {
                response = BillingAddOn.GetAllAddOns();
                //ViewData["resultData"] = response.Data;

                //AddOnModel item = new AddOnModel();
                //item.Cost = 100;
                //item.Description = "Testing";
                //item.DurationDays = 30;
                //item.PlanDurationTypeId = 1;
                //item.PlanID = 1;
                //item.ID = 1;
                //response = new Response<List<AddOnModel>>();
                //response.Data = new List<AddOnModel>();
                //response.Data.Add(item);
               // ViewData["resultData"] = response.Data;
            }
            catch(Exception ex)
            {

            }
            return View(response);

        }
        [Route("addon/summary")]
        [HttpPost]
        public IActionResult Summary()
        {
         
           var req =  HttpContext.Request;
            Response<List<AddOnModel>> response = null;
            try
            {
                response = new Response<List<AddOnModel>>();
                response.Data = new List<AddOnModel>();
                AddOnModel item = null;
                for (int i = 0; i< req.Form.Keys.Count;i++)
                {
                    if (req.Form["qty"][i] != null && req.Form["qty"][i] != "")
                    {
                        item = new AddOnModel();
                        if (req.Form["subtot"][i] != null && req.Form["subtot"][i] != "")
                            item.SubTotalPrice = Convert.ToDecimal(req.Form["subtot"][i]);
                        if (req.Form["qty"][i] != null && req.Form["qty"][i] != "")
                            item.Quantity = Convert.ToInt32(req.Form["qty"][i]);
                        if (req.Form["desc"][i] != null && req.Form["desc"][i] != "")
                            item.Description = Convert.ToString(req.Form["desc"][i]);
                        if (req.Form["item.DurationType"][i] != null && req.Form["item.DurationType"][i] != "")
                            item.DurationType = Convert.ToString(req.Form["item.DurationType"][i]);
                        response.Data.Add(item);
                    }
                }
                

            }
            catch (Exception ex)
            {

            }
            return View(response);

        }
    }
}
