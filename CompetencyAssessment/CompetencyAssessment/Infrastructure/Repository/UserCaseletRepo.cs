using CompetencyAssessment.Infrastructure.Abstract;
using ModelCompetencyAssessment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Text;
using CompetencyAssessment.Models;

namespace CompetencyAssessment.Infrastructure.Repository
{
    public class UserCaseletRepo : IUserCaselet
    {
        string connection = ConfigurationManager.AppSettings["ConnectionString"];
        public int insertcaselet(UserCaseLet ucl)
        {
            int count = 0;
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("InsertUserCaselet", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Caselet",ucl.Caselet);
            cmd.Parameters.AddWithValue("@Answer1",ucl.Answer1);
            cmd.Parameters.AddWithValue("@Answer2", ucl.Answer2);
            cmd.Parameters.AddWithValue("@Answer3", ucl.Answer3);
            cmd.Parameters.AddWithValue("@Answer4", ucl.Answer4);
            cmd.Parameters.AddWithValue("@CompID1",ucl.CompID1);
            cmd.Parameters.AddWithValue("@CompID2", ucl.CompID2);
            cmd.Parameters.AddWithValue("@CompID3", ucl.CompID3);
            cmd.Parameters.AddWithValue("@CompID4", ucl.CompID4);
            cmd.Parameters.AddWithValue("@IsActive",ucl.IsActive);
            SqlParameter outputpar = new SqlParameter();
            outputpar.ParameterName = "@count";
            outputpar.SqlDbType = System.Data.SqlDbType.Int;
            outputpar.Direction = System.Data.ParameterDirection.Output;
            cmd.Parameters.Add(outputpar);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                count = Convert.ToInt32(outputpar.Value);
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
        public List<UserDetailViewModelCompetency> UserCompetency()
        {
            List<UserDetailViewModelCompetency> ls = new List<UserDetailViewModelCompetency>();
            using (SqlConnection con = new SqlConnection(connection))
            {
                SqlCommand cmd = new SqlCommand("UserCompetencyDrp", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        ls.Add(new UserDetailViewModelCompetency
                        {

                            CompId = Convert.ToInt32(sdr["CompId"]),
                            CompName = sdr["CompName"].ToString()
                        });
                    }
                    con.Close();
                }
            }
            return ls;
        }
    }
}