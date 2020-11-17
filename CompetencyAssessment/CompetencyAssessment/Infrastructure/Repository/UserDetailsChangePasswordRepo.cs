using CompetencyAssessment.Infrastructure.Abstract;
using CompetencyAssessment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace CompetencyAssessment.Infrastructure.Repository
{
    public class UserDetailsChangePasswordRepo: IUserDetailChangePass
    {
        public int UpdatePassword(UserDetailViewModelChangePwd UDVMCP)
        {
            int count = 0;
            SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
            SqlCommand cmd = new SqlCommand("UsersChangePassword",con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserID", UDVMCP.UserID);
            cmd.Parameters.AddWithValue("@Password", UDVMCP.Password);
            cmd.Parameters.AddWithValue("@ChangePassword",UDVMCP.ChangePassword);
            cmd.Parameters.AddWithValue("@ConfirmChangePassword", UDVMCP.ConfirmChangePassword);
            SqlParameter outputPara = new SqlParameter();
            outputPara.ParameterName = "@count";
            outputPara.Direction = System.Data.ParameterDirection.Output;
            outputPara.SqlDbType = System.Data.SqlDbType.Int;
            cmd.Parameters.Add(outputPara);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                count = Convert.ToInt32(outputPara.Value);
                con.Close();
            }
            catch(Exception ex)
            {
                string Path = @"F:\Log Files\LogFile.txt";
                StreamWriter sw = new StreamWriter(Path);
                sw.WriteLine(ex.Message);
                sw.Close();
            }
            return count;
        }
    }
}