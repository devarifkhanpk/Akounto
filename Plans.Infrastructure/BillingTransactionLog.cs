using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Plans.Infrastructure
{
    public class BillingTransactionLog
    {
        public enum PlanTransactionStatus : int
        {
            [Description("None")]
            None = 0,
            [Description("Success")]
            Success = 200,
            [Description("In-Progress")]
            Inprogress = 300,
            [Description("Error")]
            Error = 500
        }

        public int TransactionLogTypeId { get; set; }

        public int CompanyId { get; set; }

        public int PlanId { get; set; }

        public int PlanCategoryId { get; set; }

        public int PaymentGatewayTypeId { get; set; }

        public string PaymentGatewayTransactionId { get; set; }

        public string Description { get; set; }

        public decimal Amount { get; set; }

    }

    public class LogTransaction
    {
        public int LogId { get; set; }
        public int LogTransactionId { get; set; }
    }

}
