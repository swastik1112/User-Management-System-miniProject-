using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace miniProject.Models
{
    public class City
    {

        public int CityNo { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please enter city")]
        [StringLength(30, ErrorMessage = "The {0} value cannot exceed {1} characters. ")]
        public string CityName { get; set; }



        public static String GetCityName(int CityNo)
        {
            City obj = new City();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = jkJan24; Integrated Security = True";
            try
            {
                cn.Open();
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                cmdInsert.CommandType = System.Data.CommandType.Text;
                cmdInsert.CommandText = "select CityName from City where CityNo=@CityNo";
                cmdInsert.Parameters.AddWithValue("@CityNo", CityNo);
                SqlDataReader dr = cmdInsert.ExecuteReader();
                if (dr.Read())
                {


                    // obj.CityNo = dr.GetInt32("CityNo");
                    obj.CityName = dr.GetString("CityName");
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
            return obj.CityName;
        }

        public static List<SelectListItem> GetAllCity()
        {
            List<SelectListItem> objCity = new List<SelectListItem>();
            
            
            
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = jkJan24; Integrated Security = True";
            try
            {
                cn.Open();
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                cmdInsert.CommandType = System.Data.CommandType.Text;
                cmdInsert.CommandText = "select * from City ";
                SqlDataReader dr = cmdInsert.ExecuteReader();
                while (dr.Read())
                    objCity.Add(new SelectListItem(dr.GetString("CityName"), ""+dr.GetInt32("CityNo")));
                    //lstcity.Add(new City { CityNo = dr.GetInt32("CityNo"), CityName = dr.GetString("CityName") });
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
            return objCity;
        }
        public static void InsertCity(City obj)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = jkJan24; Integrated Security = True";
            try
            {
                cn.Open();
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                cmdInsert.CommandType = System.Data.CommandType.Text;
                cmdInsert.CommandText = "insert into City values(@CityNo,@CityName)";

                cmdInsert.Parameters.AddWithValue("@UserNo", obj.CityNo);
                cmdInsert.Parameters.AddWithValue("@LoginName", obj.CityName);
           
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

        public static void UpdateCity(City obj)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = jkJan24; Integrated Security = True";
            try
            {
                cn.Open();
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                cmdInsert.CommandType = System.Data.CommandType.Text;
                cmdInsert.CommandText = "update City set CityNo=@CityNo,CityName=@CityName";

                cmdInsert.Parameters.AddWithValue("@CityNo", obj.CityNo);
                cmdInsert.Parameters.AddWithValue("@CityName", obj.CityName);
               
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

        public static void DeleteCity(int CityNo)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = jkJan24; Integrated Security = True";
            try
            {
                cn.Open();
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                cmdInsert.CommandType = System.Data.CommandType.Text;
                cmdInsert.CommandText = "delete from Register where CityNo =@CityNo";

                cmdInsert.Parameters.AddWithValue("@CityNo", CityNo);
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
    }

}
