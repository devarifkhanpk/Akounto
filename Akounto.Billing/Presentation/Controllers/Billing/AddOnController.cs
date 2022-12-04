
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

            
            Response<AddOnViewModel> response = null;
            try
            {
                //response = BillingAddOn.GetAllAddOns();
                //ViewData["resultData"] = response.Data;

                //AddOnModel item = new AddOnModel();
                //item.Cost = 100;
                //item.Description = "Testing";
                //item.DurationDays = 30;
                //item.PlanDurationTypeId = 1;
                //item.PlanID = 1;
                //item.ID = 1;
                response = new Response<AddOnViewModel>();
                response.Data = new AddOnViewModel();
                response.Data.AddOnItems = BillingAddOn.GetAllAddOns();
                //response.Data.AddOnItems = new List<AddOnModel>();
                //response.Data.AddOnItems.Add(item);
                // ViewData["resultData"] = response.Data;
                //============Set the value of Payment Plan===============
                // decimal? PlanCateryGetway=500.69;
                // response.Data = new AddOnViewModel();
                response.Data.PlanCategory = new PlanCategoryModel();
                response.Data.PlanCategory.Cost = Convert.ToDecimal(6.00);
                response.Data.PlanCategory.PlanName = "Startup";
                response.Data.PlanCategory.ID = 1;
                response.Data.PlanCategory.PlanDurationName = "Monthly";
                



            }
            catch (Exception ex)
            {

            }
            return View(response);

        }
        [Route("addon/summary")]
        [HttpPost]
        public IActionResult Summary()
        {

            var req = HttpContext.Request;
            Response<List<AddOnModel>> response = null;
            try
            {
                response = new Response<List<AddOnModel>>();
                response.Data = new List<AddOnModel>();
                AddOnModel item = null;
                for (int i = 0; i < req.Form["qty"].Count; i++)
                {
                    if (req.Form["qty"][i] != null && req.Form["qty"][i] != "")
                    {
                        item = new AddOnModel();
                        if (req.Form["hdPlanAddonCategoryID"][i] != null && req.Form["hdPlanAddonCategoryID"][i] != "")
                            item.ID = Convert.ToInt32(req.Form["hdPlanAddonCategoryID"][i]);
                        if (req.Form["hdPrice"][i] != null && req.Form["hdPrice"][i] != "")
                            item.Cost = Convert.ToDecimal(req.Form["hdPrice"][i]);
                        //if (req.Form["subtot"][i] != null && req.Form["subtot"][i] != "")
                        //    item.SubTotalPrice = Convert.ToDecimal(req.Form["subtot"][i]);
                        if (req.Form["qty"][i] != null && req.Form["qty"][i] != "")
                            item.Quantity = Convert.ToInt32(req.Form["qty"][i]);
                        if (req.Form["desc"][i] != null && req.Form["desc"][i] != "")
                            item.Description = Convert.ToString(req.Form["desc"][i]);
                        if (req.Form["element.DurationType"][i] != null && req.Form["element.DurationType"][i] != "")
                            item.DurationType = Convert.ToString(req.Form["element.DurationType"][i]);
                        if (req.Form["hdFirstSubcriptionCost"][i] != null && req.Form["hdFirstSubcriptionCost"][i] != "")
                            item.FirstSubcriptionCost = Convert.ToDecimal(req.Form["hdFirstSubcriptionCost"][i]);
                        if (req.Form["hdDurationDays"][i] != null && req.Form["hdDurationDays"][i] != "")
                            item.DurationDays = Convert.ToInt32(req.Form["hdDurationDays"][i]);

                        response.Data.Add(item);
                    }
                }
                //if (req.Form["hdPlanCategoryID"] != null && req.Form["hdPlanCategoryID"] != "")

                int? planCategoryID = Convert.ToInt32(req.Form["hdPlanCategoryID"]);
                decimal addonTotal = Convert.ToDecimal(req.Form["addonTotal"]);
                decimal grdTotal = Convert.ToDecimal(req.Form["grdtot"]);


              int? result =  BillingAddOn.CreateAddOnsSubcription(response.Data,1);



            }
            catch (Exception ex)
            {

            }
            return View(response);

        }
        [Route("addon/ExpansionPlan")]
        [HttpPost]
        public IActionResult ExpansionPlan()
        {
            var req = HttpContext.Request;
            Response<List<AddOnModel>> response = null;
            response = new Response<List<AddOnModel>>();
            response.TransactionStatus = new Transaction();
            response.TransactionStatus.IsSuccess = true;

         
            

            return View(response);
        }
    }
}
