using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using ModelCompetencyAssessment;
using CompetencyAssessment.Infrastructure.Abstract;

namespace CompetencyAssessment.Infrastructure.Repository
{
    public class UserDetails: IUserDetails
    {

        public List<UserDetail> GetUserDetails(string UID)
        {
            List<UserDetail> lstUD = new List<UserDetail>();
            SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
            SqlCommand cmd = new SqlCommand("UsersGetOnUserID", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserID", UID);
            try
            {
                con.Open();
               SqlDataReader rdr= cmd.ExecuteReader();
                while(rdr.Read())
                {
                    UserDetail UD = new UserDetail();
                    UD.ID = Convert.ToInt32(rdr["ID"]);
                    UD.UserID = rdr["UserID"].ToString();
                    UD.EmployeeID = rdr["EmployeeID"].ToString();
                    UD.EmailID = rdr["EmailID"].ToString();
                    UD.Name = rdr["Name"].ToString();
                    UD.DOB = (DateTime)rdr["DOB"];
                    UD.Address = rdr["Address"].ToString();
                    UD.Password = rdr["Password"].ToString();
                    UD.LastLoggedOnDate = (DateTime)rdr["LastLoggedOnDate"];
                    UD.RoleID = Convert.ToInt32(rdr["RoleID"]);
                    lstUD.Add(UD);
                }
                
            }
            catch(Exception ex)
            {
                string Path = @"F:\Log Files\LogFile.txt";
                StreamWriter sw = new StreamWriter(Path);
                sw.WriteLine(ex.Message);
                sw.Close();
            }
            return lstUD;
        }
    }
}