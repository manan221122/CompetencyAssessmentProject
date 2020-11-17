using ModelCompetencyAssessment;
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
    public class UserRoleRepository: IUserRole
    {
        
        public int AddUser(ModelCompetencyAssessment.UserRole UR)
        {
            int count = 0;
            SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
            
            SqlCommand cmd = new SqlCommand("UserRoleInput",con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@RoleName",UR.RoleName);
            cmd.Parameters.AddWithValue("@Description", UR.Description);
            cmd.Parameters.AddWithValue("@IsActive", UR.IsActive);
            SqlParameter outputparam = new SqlParameter();
            outputparam.SqlDbType = System.Data.SqlDbType.Bit;
            outputparam.ParameterName = "@count";
            outputparam.Direction = System.Data.ParameterDirection.Output;
            cmd.Parameters.Add(outputparam);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                count = Convert.ToInt32(outputparam.Value);
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