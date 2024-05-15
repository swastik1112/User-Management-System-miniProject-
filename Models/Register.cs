using Microsoft.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace miniProject.Models
{
    public class Register
    {
        [Key]
        [Display(Name = "User Id")]
        public int UserNo { get; set; }

        [Display(Name = "User Name")]
        public string LoginName { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please enter name")]
        [StringLength(30, ErrorMessage = "The {0} value cannot exceed {1} characters. ")]
        public string FullName { get; set; }

        public string Gender { get; set; }

        [EmailAddress]
        public string EmailId { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Mobile { get; set; }

        [Required(ErrorMessage = "Please enter password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please enter confirm password")]
        [Compare("Password", ErrorMessage = "Password and confirm password should be the same")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        
        public int CityNo { get; set; }

        public static List<Register> GetAllRegUser()
        {
            List<Register> lstuser = new List<Register>();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = dbCon; Integrated Security = True";
            try
            {
                cn.Open();
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                cmdInsert.CommandType = System.Data.CommandType.Text;
                cmdInsert.CommandType = System.Data.CommandType.StoredProcedure;
                //cmdInsert.CommandText = "select * from Register";
                cmdInsert.CommandText = "GetAllRegUser";
                SqlDataReader dr = cmdInsert.ExecuteReader();
                while (dr.Read())
                    lstuser.Add(new Register { UserNo = dr.GetInt32("UserNo"), LoginName = dr.GetString("LoginName"), FullName = dr.GetString("FullName"), Gender = dr.GetString("Gender"), EmailId = dr.GetString("EmailId"), Mobile = dr.GetString("Mobile"), Password = dr.GetString("Password"), CityNo = dr.GetInt32("CityNo") });
                dr.Close();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }
            return lstuser;
        }
        public static Register GetSingleUser(int UserNo)
        {
            Register obj = new Register();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = dbCon; Integrated Security = True";
            try
            {
                cn.Open();
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                cmdInsert.CommandType = System.Data.CommandType.Text;
                cmdInsert.CommandType = System.Data.CommandType.StoredProcedure;
                //cmdInsert.CommandText = "select * from Register where UserNo =@UserNo";
                cmdInsert.CommandText = "GetSingleUser";
                cmdInsert.Parameters.AddWithValue("@UserNo", UserNo);
                SqlDataReader dr = cmdInsert.ExecuteReader();
                if (dr.Read())
                {
                    obj.UserNo = dr.GetInt32("UserNo");
                    obj.LoginName = dr.GetString("LoginName");
                    obj.FullName = dr.GetString("FullName");
                    obj.Gender = dr.GetString("Gender");
                    obj.EmailId = dr.GetString("EmailId");
                    obj.Mobile = dr.GetString("Mobile");
                    obj.Password = dr.GetString("Password");

                    obj.CityNo = dr.GetInt32("CityNo");
                }
                else
                {
                    obj = null;
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }
            return obj;
        }
        public static void InsertUser(Register obj)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = dbCon; Integrated Security = True";
            try
            {
                cn.Open();
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                //cmdInsert.CommandType = System.Data.CommandType.Text;
                cmdInsert.CommandType = System.Data.CommandType.StoredProcedure;
                //c1mdInsert.CommandText = "insert into Register (LoginName, FullName, Gender, EmailId, Mobile, Password, CityNo) values (@LoginName, @FullName, @Gender, @EmailId, @Mobile, @Password, @CityNo)";
                cmdInsert.CommandText = "InsertUser";

                cmdInsert.Parameters.AddWithValue("@LoginName", obj.LoginName);
                cmdInsert.Parameters.AddWithValue("@FullName", obj.FullName);
                cmdInsert.Parameters.AddWithValue("@Gender", obj.Gender);
                cmdInsert.Parameters.AddWithValue("@EmailId", obj.EmailId);
                cmdInsert.Parameters.AddWithValue("@Mobile", obj.Mobile);
                cmdInsert.Parameters.AddWithValue("@Password", obj.Password);
                cmdInsert.Parameters.AddWithValue("@CityNo", obj.CityNo);
                cmdInsert.ExecuteNonQuery();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }




        }
        public static void UpdateUser(Register obj)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = dbCon; Integrated Security = True";
            try
            {
                cn.Open();
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                cmdInsert.CommandType = System.Data.CommandType.Text;
                cmdInsert.CommandText = "update Register set LoginName=@LoginName,FullName=@FullName,Gender=@Gender,EmailId=@EmailId,Mobile=@Mobile,Password=@Password,CityNo=@CityNo where UserNo =@UserNo";

                cmdInsert.Parameters.AddWithValue("@LoginName", obj.LoginName);
                cmdInsert.Parameters.AddWithValue("@FullName", obj.FullName);
                cmdInsert.Parameters.AddWithValue("@Gender", obj.Gender);
                cmdInsert.Parameters.AddWithValue("@EmailId", obj.EmailId);
                cmdInsert.Parameters.AddWithValue("@Mobile", obj.Mobile);
                cmdInsert.Parameters.AddWithValue("@Password", obj.Password);
                cmdInsert.Parameters.AddWithValue("@CityNo", obj.CityNo);
                cmdInsert.Parameters.AddWithValue("@UserNo", obj.UserNo);
                cmdInsert.ExecuteNonQuery();



            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }

        }
        public static void DeleteUser(int UserNo)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = dbCon; Integrated Security = True";
            try
            {
                cn.Open();
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                cmdInsert.CommandType = System.Data.CommandType.Text;
                cmdInsert.CommandText = "delete from Register where UserNo =@UserNo";

                cmdInsert.Parameters.AddWithValue("@UserNo", UserNo);
                cmdInsert.ExecuteNonQuery();



            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }




        }

        public static bool GetLoginUser(string LoginName , string Password)
        {
            bool flag = false;
            Register obj = new Register();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = dbCon; Integrated Security = True";
            try
            {
                cn.Open();
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                cmdInsert.CommandType = System.Data.CommandType.Text;
                cmdInsert.CommandText = "select * from Register where LoginName=@LoginName and Password =@Password";
                cmdInsert.Parameters.AddWithValue("@LoginName", LoginName);
                cmdInsert.Parameters.AddWithValue("@Password", Password);
                
                SqlDataReader dr = cmdInsert.ExecuteReader();
                if (dr.Read())
                {
                    flag = true;
                }
               
                dr.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }
            return flag;
        }

        public static List<Register> GetAllRegUserSorted()
        {
            List<Register> lstuser = new List<Register>();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = jkJan24; Integrated Security = True";
            try
            {
                cn.Open();
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                cmdInsert.CommandType = System.Data.CommandType.Text;
                cmdInsert.CommandText = "select * from Register Order By CityNo ";
                SqlDataReader dr = cmdInsert.ExecuteReader();
                while (dr.Read())
                    lstuser.Add(new Register { UserNo = dr.GetInt32("UserNo"), LoginName = dr.GetString("LoginName"), FullName = dr.GetString("FullName"), Gender = dr.GetString("Gender"), EmailId = dr.GetString("EmailId"), Mobile = dr.GetString("Mobile"), Password = dr.GetString("Password"), CityNo = dr.GetInt32("CityNo") });
                dr.Close();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }
            return lstuser;
        }
    }
}
