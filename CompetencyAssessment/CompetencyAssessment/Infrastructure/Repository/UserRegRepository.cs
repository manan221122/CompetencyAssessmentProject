using CompetencyAssessment.Infrastructure.Abstract;
using ModelCompetencyAssessment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Web.Mvc;
using CompetencyAssessment.Models;
using System.Text;

namespace CompetencyAssessment.Infrastructure.Repository
{
    public class UserRegRepository: IUserRegisteration
    {
        string connection = ConfigurationManager.AppSettings["ConnectionString"];
        public int UserExistenceCheck(string UserID)
        {
            int count = 0;
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("UserExistence", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserID", UserID);        
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
        public string InsertUserData(UserDetail UD)
        {
            string msg = string.Empty;
            int count = 0;
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("UsersInsert", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserID", UD.UserID);
            cmd.Parameters.AddWithValue("@EmployeeID", UD.EmployeeID);
            cmd.Parameters.AddWithValue("@EmailID", UD.EmailID);
            cmd.Parameters.AddWithValue("@Name", UD.Name);
            cmd.Parameters.AddWithValue("@DOB", UD.DOB);
            cmd.Parameters.AddWithValue("@Address", UD.Address);
            cmd.Parameters.AddWithValue("@Password", UD.Password);
            cmd.Parameters.AddWithValue("@CompId", UD.CompId);
            cmd.Parameters.AddWithValue("@RoleID", UD.RoleID);
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
                if(count>0)
                {
                    msg = "Success";
                }
            }
            catch(Exception ex)
            {
                string Path = @"F:\Log Files\LogFile.txt";
                StreamWriter sw = new StreamWriter(Path);
                sw.WriteLine(ex.Message);
                sw.Close();
            }
            
            return msg;
        }

        public List<UserRoleViewModel> UserRole()
        {
            List<UserRoleViewModel> ls = new List<UserRoleViewModel>();
            using (SqlConnection con = new SqlConnection(connection))
            {
                SqlCommand cmd = new SqlCommand("UserRole", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        ls.Add(new UserRoleViewModel
                        {
                            
                            RoleID = Convert.ToInt32(sdr["RoleID"]),
                            RoleName = sdr["RoleName"].ToString()
                        });
                    }
                    con.Close();
                }
            }
            return ls;
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