using Akounto.Billing.Entities.Billing;
using Akounto.Billing.Gateways;
using Microsoft.AspNetCore.Mvc;
//testing
namespace Akounto.Billing.Presentation.Controllers.Billing
{
    public class SubscriptionController : BaseController
    {
        [HttpPost(nameof(Add))]
        public ActionResult Add(string plan)
        {
            IGateway _gateway = BaseController.GetGateway(PaymentGatewayType.Stripe); 
            
            var subscription = new SubscriptionCreateModel
            {
                Customer = "cus_MkeDcyfEbP5V4t", //planSubscription.GatewayCustomerID,
                PlanID = "price_1M02S7SEUqurWPXSVu4B8xZS" //planSubscription.GatewayPlanID
            };
            _gateway.Subscription.Add(subscription);

            return View();

        }

        [HttpPost(nameof(Delete))]
        public ActionResult Delete(string _customerID, string _id)
        {
            IGateway _gateway = BaseController.GetGateway(PaymentGatewayType.Stripe);

            var subscription = new SubscriptionCreateModel
            {
                Customer = _customerID,//"cus_MkeDcyfEbP5V4t", //planSubscription.GatewayCustomerID,
                PlanID = _id //planSubscription.GatewayPlanID
            };
            _gateway.Subscription.Delete(subscription.PlanID);


          

            return View();

        }


        [HttpPost(nameof(Update))]
        public ActionResult Update(string _customerID, string _ID,string _updatedPlanID)
        {
            IGateway _gateway = BaseController.GetGateway(PaymentGatewayType.Stripe);

            var subscription = new SubscriptionCreateModel
            {
                Customer = _customerID, //planSubscription.GatewayCustomerID,
                PlanID = _ID,
                UpdatedPlanID = _updatedPlanID
            };
             _gateway.Subscription.Update(subscription);


            return View();

        }


        [HttpGet(nameof(GetInfo))]
        public  ActionResult GetInfo()
        {

            IGateway _gateway = BaseController.GetGateway(PaymentGatewayType.Stripe);
            _gateway.Subscription.GetInfo();

            return View();

   
        }

        //[HttpGet(nameof(GetByID))]
        //public async Task<IActionResult> GetByID(string Id)
        //{
        //    var customer = await _paymentGateway.Subscription.GetById(Id);
        //    return Ok(customer);
        //}
    }
}
