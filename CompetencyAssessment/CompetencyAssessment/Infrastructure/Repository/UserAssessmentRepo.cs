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
    public class UserAssessmentRepo : IUserAssessment
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        public int insertAssessment(UserAssessment UA)
        {
            int count = 0;
            SqlCommand cmd = new SqlCommand("InsertUserAssessment",con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AssessName",UA.AssessName);
            cmd.Parameters.AddWithValue("@AssessDt", UA.AssessDt);
            cmd.Parameters.AddWithValue("@AssessHr", UA.AssessHr);
            cmd.Parameters.AddWithValue("@AssessMin",UA.AssessMin);
            cmd.Parameters.AddWithValue("@Duration", UA.Duration);
            SqlParameter outputparam = new SqlParameter();
            outputparam.ParameterName = "@count";
            outputparam.SqlDbType = System.Data.SqlDbType.Int;
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