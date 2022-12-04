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
        public static List<AddOnModel> GetAllAddOns(string _connection)
        {
            List<AddOnModel> addonItems = null;

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
                        addonItems = BuildModel(dt);
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return addonItems;
        }
        public static List<AddOnModel> CreateAddOnsSubcription(string _connection, DataTable addOnDataTable, int companyID)
        {
            List<AddOnModel> addonItems = null;
            Response<LogTransaction> response = null;
            try
            {

                using (SqlConnection connection = new SqlConnection(_connection))
                {
                    SqlDataAdapter sqlDataAdapter;
                    DataSet ds = new DataSet();

                    using (SqlCommand command = new SqlCommand())
                    {
                        connection.Open();
                        command.Connection = connection;
                        command.CommandText = "[dbo].[PlanSubscriptionsAddonAdd]";
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandTimeout = 3600;
                        command.Parameters.AddWithValue("@CompanyId", companyID);
                        var tvpParam  = command.Parameters.AddWithValue("@tblPlanCategoriesAddon", addOnDataTable);
                        tvpParam.SqlDbType = SqlDbType.Structured;
                        tvpParam.TypeName = "dbo.tblPlanCategoriesAddon";

                        sqlDataAdapter = new SqlDataAdapter(command);
                        sqlDataAdapter.Fill(ds);
                    }

                    if (ds != null && ds.Tables.Count > 0)
                    {
                        response = new Response<LogTransaction>();

                        if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                        {
                            DataRow row = ds.Tables[0].Rows[0];
                            int state = Convert.ToInt32(row["ErrorState"]);

                            if (state == 200)
                            {
                                response = new Response<LogTransaction>()

                                {
                                    Data = new LogTransaction()
                                    {
                                        LogId = Convert.ToInt32(row["Id"]),
                                        LogTransactionId = Convert.ToInt32(row["SubTransactionId"])
                                    },
                                    TransactionStatus = new Transaction() { IsSuccess = true }
                                };
                            }
                            else
                            {
                                response = new Response<LogTransaction>()
                                {
                                    TransactionStatus = new Transaction()
                                    {
                                        IsSuccess = false,
                                        Error = new Error()
                                        {
                                            Code = state,
                                            Description = Convert.ToString(row["ErrorMessage"])
                                        }

                                    }
                                };
                            }
                        }
                    }
                    else if (response == null || (response != null && response.TransactionStatus == null))
                    {
                        response = new Response<LogTransaction>()
                        {
                            TransactionStatus = new Transaction()
                            {
                                IsSuccess = false,
                                Error = new Error()
                                {
                                    Code = 505,
                                    Description = "Something wrong, plase try after some time"
                                }
                            }
                        };
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return addonItems;
        }

        #region Private Method
        public static List<AddOnModel> BuildModel(DataTable dt)
        {
            // List<AddOnModel> datalst = new List<AddOnModel>();
            List<AddOnModel> addons = new List<AddOnModel>();
            
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
                if (dt.Columns.Contains("FirstSubcriptionCost") && !Convert.IsDBNull(dr["FirstSubcriptionCost"]))
                {
                    item.FirstSubcriptionCost = Convert.ToDecimal(dr["FirstSubcriptionCost"]);
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

                addons.Add(item);
               
            }
            
            return addons;
        }
        #endregion 
    }
}
