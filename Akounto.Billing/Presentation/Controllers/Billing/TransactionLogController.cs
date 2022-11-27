using Microsoft.AspNetCore.Mvc;
using Plans.Business;
using Plans.Infrastructure;
using static Plans.Infrastructure.BillingTransactionLog;

namespace Akounto.Billing.Presentation.Controllers.Billing
{
    public class TransactionLogController : Controller
    {
        [HttpGet(nameof(LogData))]
        public IActionResult LogData()
        {
            Response<LogTransaction> logResponse = BillingLogger.Log(new BillingTransactionLog()
            {
                TransactionLogTypeId = 17,
                CompanyId = 2564,
                PlanCategoryId = 10,
                PlanId = 1,
                PaymentGatewayTypeId = 1,
                PaymentGatewayTransactionId = "test",
                Description = "test log trnasation",
                Amount = 12
            }, PlanTransactionStatus.Success);

            return View();
        }
    }
}
