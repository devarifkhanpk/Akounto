using Plans.Infrastructure;
using Plans.Payment.Entities.Billing;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Plan.Database
{
    public class AddOnProcedure
    {
        public static Response<List<AddOnModel>> GetAllAddOns(string _connection)
        {
            Response<List<AddOnModel>> response = null;

            try
            {

                using (SqlConnection connection = new SqlConnection(_connection))
                {
                    SqlDataAdapter sqlDataAdapter;
                    DataTable dt = new DataTable();

                    using (SqlCommand command = new SqlCommand())
                    {
                        connection.Open();
                        command.Connection = connection;
                        command.CommandText = "[dbo].[GetAllPaymentGetwayAddOns]";
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandTimeout = 3600;


                        sqlDataAdapter = new SqlDataAdapter(command);
                        sqlDataAdapter.Fill(dt);
                    }

                    if(dt!=null && dt.Rows.Count>0)
                    {
                        response = BuildModel(dt);
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return response;
        }

        #region Private Method
        public static Response<List<AddOnModel>> BuildModel(DataTable dt)
        {
            // List<AddOnModel> datalst = new List<AddOnModel>();
            Response<List<AddOnModel>> response = new Response<List<AddOnModel>>();
            response.Data = new List<AddOnModel>();
            foreach (DataRow  dr in dt.Rows)
            {
                AddOnModel item = new AddOnModel();
                if (dt.Columns.Contains("Id") && !Convert.IsDBNull(dr["Id"]))
                {
                    item.ID = Convert.ToInt32(dr["Id"]);                    
                }
                if (dt.Columns.Contains("PlanId") && !Convert.IsDBNull(dr["PlanId"]))
                {
                    item.PlanID = Convert.ToInt32(dr["PlanId"]);
                }
                if (dt.Columns.Contains("PlanDurationTypeId") && !Convert.IsDBNull(dr["PlanDurationTypeId"]))
                {
                    item.PlanDurationTypeId = Convert.ToInt32(dr["PlanDurationTypeId"]);
                }
                if (dt.Columns.Contains("Description") && !Convert.IsDBNull(dr["Description"]))
                {
                    item.Description = Convert.ToString(dr["Description"]);
                }
                if (dt.Columns.Contains("DurationDays") && !Convert.IsDBNull(dr["DurationDays"]))
                {
                    item.DurationDays = Convert.ToInt32(dr["DurationDays"]);
                }
                if (dt.Columns.Contains("FirstSubscriptionCost") && !Convert.IsDBNull(dr["FirstSubscriptionCost"]))
                {
                    item.FirstSubcriptionCode = Convert.ToDecimal(dr["FirstSubscriptionCost"]);
                }
                if (dt.Columns.Contains("Cost") && !Convert.IsDBNull(dr["Cost"]))
                {
                    item.Cost = Convert.ToDecimal(dr["Cost"]);
                }
                if (dt.Columns.Contains("Created") && !Convert.IsDBNull(dr["Created"]))
                {
                    item.Created = Convert.ToDateTime(dr["Created"]);
                }

                if (dt.Columns.Contains("DurationType") && !Convert.IsDBNull(dr["DurationType"]))
                {
                    item.DurationType = Convert.ToString(dr["DurationType"]);
                }

                response.Data.Add(item);
               
            }
            
            return response;
        }
        #endregion 
    }
}
