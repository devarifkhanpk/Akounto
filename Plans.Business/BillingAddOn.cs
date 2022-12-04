using Plan.Database;
using Plans.Infrastructure;
using Plans.Payment.Entities.Billing;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Plans.Business
{

    public class BillingAddOn
    {
        //private static string _connectionString = "Server=192.168.100.6;Database=Akounto;User Id=sa;Password=1234;";
        private static string _connectionString = "Server=localhost;Database=Akounto;User Id=sa;Password=1234;";
        public static List<AddOnModel> GetAllAddOns()
        {
            List<AddOnModel> response = null;
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

        public static int? CreateAddOnsSubcription(List<AddOnModel> addOnCollections, int companyID)
        {
            DataTable addonDataTable = null;
            try
            {
                addonDataTable = GetAddOnsDataTable(addOnCollections);
                AddOnProcedure.CreateAddOnsSubcription(_connectionString, addonDataTable, companyID);
            }
            catch (Exception ex)
            {

            }
            return null;
        }
        #region Private Methods
        public static DataTable GetAddOnsDataTable(List<AddOnModel> addOnCollections)
        {
            DataTable tblAddons = new DataTable();
            try
            {
                tblAddons.Columns.Add("PlanCategoryAddonId", typeof(int));
                tblAddons.Columns.Add("Cost", typeof(decimal));
                tblAddons.Columns.Add("ChargeAmount", typeof(decimal));
                tblAddons.Columns.Add("Quantity", typeof(int));


                foreach (AddOnModel item in addOnCollections)
                {
                    DataRow dataRow;
                    dataRow = tblAddons.NewRow();
                    dataRow["PlanCategoryAddonId"] = item.ID;
                    dataRow["Cost"] = item.Cost;
                    dataRow["ChargeAmount"] = item.Cost;
                    dataRow["Quantity"] = item.Quantity;
                    tblAddons.Rows.Add(dataRow);
                }
            }
            catch (Exception ex)
            {

            }
            return tblAddons;
        }
        #endregion 
    }
}
