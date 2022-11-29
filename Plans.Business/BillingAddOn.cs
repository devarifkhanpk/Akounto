using Plan.Database;
using Plans.Infrastructure;
using Plans.Payment.Entities.Billing;
using System;
using System.Collections.Generic;
using System.Text;

namespace Plans.Business
{

    public class BillingAddOn
    {
        private static string _connectionString = "Server=192.168.100.6;Database=Akounto;User Id=sa;Password=1234;";
        public static Response<List<AddOnModel>> GetAllAddOns()
        {
            Response<List<AddOnModel>> response = null;
            try
            {
                response = AddOnProcedure.GetAllAddOns(_connectionString);
                //if (response == null || (response != null && response.TransactionStatus == null) || (response ! = null && response.TransactionStatus != null && !respo
                //Utility.Logger.Error(string.Format("Payment Logging failed in DB 'Subscription: {0} I Status:{1}", lsonConvert.SerializeObject(_log), _successCo

                //Utility.Logger.Info(string.Format("Payment Logging successfully done, Request:fey, lsonConvert.SerializeObject(_log)));


            }
            catch (Exception ex)
            {
                // Utility.Logger.Error("BillingLogger.loglException:" + ex.ToString());
                // Utility.Logger.Error(string.Format("Payment Logging failed in D8 'Subscription:fel I Status:{1}", JsonConvert.SerializeObject(_log), _successCode))            
            }

            return response;
        }
    }
}
