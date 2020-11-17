using CompetencyAssessment.Infrastructure.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace CompetencyAssessment.Infrastructure.Repository
{
    public class UserDetailsForgotPasswordRepo: IUserDetailsForgotPassword
    {
        public string RetrievePassword(string UID)
        {
            string pwd = string.Empty;
            SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
            SqlCommand cmd = new SqlCommand("UsersForgotPassword",con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserID",UID);
            SqlParameter outputparam = new SqlParameter();
            outputparam.ParameterName = "@pwd";
            outputparam.SqlDbType = System.Data.SqlDbType.VarChar;
            outputparam.Size = 30;
            outputparam.Direction = System.Data.ParameterDirection.Output;
            cmd.Parameters.Add(outputparam);
            try
            {
                con.Open();
                cmd.ExecuteReader();
                pwd = (outputparam.Value).ToString();
                con.Close();
            }
            catch(Exception ex)
            {
                string Path = @"F:\Log Files\LogFile.txt";
                StreamWriter sw = new StreamWriter(Path);
                sw.WriteLine(ex.Message);
                sw.Close();
            }
            return pwd;
        }
    }
}