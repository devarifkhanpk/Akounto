using Plans.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Plan.Database
{
    public class BillingLogProcedure
    {
        public static Response<LogTransaction> Log(BillingTransactionLog _log, string _connection)
        {
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
                        command.CommandText = "[dbo].[AddTransactionLog]";
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandTimeout = 3600;
                        command.Parameters.AddWithValue("@TransactionLogTypeId", _log.TransactionLogTypeId);
                        command.Parameters.AddWithValue("@CompanyId", _log.CompanyId);
                        command.Parameters.AddWithValue("@PlanId", _log.PlanId);
                        command.Parameters.AddWithValue("@PlanCategoryId", _log.PlanCategoryId);
                        command.Parameters.AddWithValue("@PaymentGatewayTypeId", _log.PaymentGatewayTypeId);
                        command.Parameters.AddWithValue("@PaymentGatewayTransactionId", _log.PaymentGatewayTransactionId);
                        command.Parameters.AddWithValue("@Description", _log.Description);
                        command.Parameters.AddWithValue("@Amount", _log.Amount);

                        sqlDataAdapter = new SqlDataAdapter(command);
                        sqlDataAdapter.Fill(ds);

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
                        else if (response == null || (response!=null && response.TransactionStatus==null))
                        {
                            response = new Response<LogTransaction>()
                            {
                                TransactionStatus = new Transaction()
                                {
                                    IsSuccess = false,
                                    Error = new Error()
                                    {
                                        Code=505,
                                        Description="Something wrong, plase try after some time"
                                    }
                                }
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return response;
        }
    }
}
