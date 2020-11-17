using CompetencyAssessment.Infrastructure.Abstract;
using ModelCompetencyAssessment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
using System.IO;
namespace CompetencyAssessment.Infrastructure.Repository
{
    public class UserCompetencyRepository:IUserCompetency
    {
        public int AddCompetency(UserCompetency UC)
        {
            int count = 0;

            SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
            SqlCommand cmd = new SqlCommand("UserCompetency", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CompName", UC.CompName);
            cmd.Parameters.AddWithValue("@Description",UC.Description);
            cmd.Parameters.AddWithValue("@CreatedDate",DateTime.Now);
            SqlParameter outputparam = new SqlParameter() ;
            outputparam.ParameterName = "@count";
            outputparam.SqlDbType=System.Data.SqlDbType.Int;
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