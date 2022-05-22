using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class BusinessController : ApiController
    {
        public string GetLogin(string business_name, string password)
        {
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["webapi"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    con.Open();
                    {
                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("select * from business where " +
                            "(business_name='" + business_name + "') and " +
                            "(password='" + password + "')", con);
                        DataTable dataTable = new DataTable();
                        sqlDataAdapter.Fill(dataTable);
                        if (dataTable.Rows.Count > 0)
                        {
                            return "Giriş Başarılı";
                        }
                        else
                        {
                            return "Giriş Başarısız";
                        }
                    }
                }
            }
            catch (Exception)
            {
                return "Giriş Yapılamadı";
            }

        }
    
        public string GetRegister(string id, string business_name, string password, string status, string phone_number, string email, string city, string district, string neighbourhood, string situation, string starting_date, string ending_date, string image_name, string location, string business_type_id)
            
        {
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["webapi"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    con.Open();
                    {
                        try
                        {
                            SqlConnection FDataConnect = new SqlConnection(ConfigurationManager.ConnectionStrings["webapi"].ToString());
                            FDataConnect.Open();
                            SqlDataAdapter FDataAdapter = new SqlDataAdapter(string.Format("select business_name from business where rtrim(business_name) = '" + business_name.Trim() + "'"), FDataConnect);
                            DataTable dataTable = new DataTable();
                            FDataAdapter.Fill(dataTable);
                            if (dataTable.Rows.Count > 0)
                            {
                                return dataTable.Rows[0].ItemArray[0].ToString().Trim() + " kullanıcı adı alındı...";
                            }
                            else
                            {
                                if (id == "0")
                                {
                                    try
                                    {
                                        using (SqlCommand cmd = new SqlCommand("insert into business (business_name,password,status,phone_number,email,city,district,neighbourhood,situation,starting_date,ending_date,image_name,location,business_type_id) values (@business_name,@password,@status,@phone_number,@email,@city,@district,@neighbourhood,@situation,@starting_date,@ending_date,@image_name,@location,@business_type_id)", con))
                                        {
                                            cmd.Parameters.AddWithValue("@business_name", business_name);
                                            cmd.Parameters.AddWithValue("@password", password);
                                            cmd.Parameters.AddWithValue("@status", status);
                                            cmd.Parameters.AddWithValue("@phone_number", phone_number);
                                            cmd.Parameters.AddWithValue("@email", email);
                                            cmd.Parameters.AddWithValue("@city", city);
                                            cmd.Parameters.AddWithValue("@district", district);
                                            cmd.Parameters.AddWithValue("@neighbourhood", neighbourhood);
                                            cmd.Parameters.AddWithValue("@situation", situation);
                                            cmd.Parameters.AddWithValue("@starting_date", starting_date);
                                            cmd.Parameters.AddWithValue("@ending_date", ending_date);
                                            cmd.Parameters.AddWithValue("@image_name", image_name);
                                            cmd.Parameters.AddWithValue("@location", location);
                                            cmd.Parameters.AddWithValue("@business_type_id", business_type_id);
                                            int i = cmd.ExecuteNonQuery();
                                            con.Close();
                                            if (i == 1)
                                                return "Kayıt eklendi";
                                            else
                                                return "Kayıt eklenemedi";
                                        }
                                    }
                                    catch (Exception)
                                    {
                                        return "Kayıt eklenemedi";
                                    }

                                }
                                else
                                {
                                    try
                                    {
                                        using (SqlCommand cmd = new SqlCommand("update business set username=@username, password=@password, status=@status, phone_number=@phone_number, email=@email, city=@city, district=@district, neighbourhood=@neighbourhood, situation=@situation, starting_date=@starting_date, ending_date=@ending_date, image_name=@image_name, location=@location, business_type_id=@business_type_id  where id=@id", con))
                                        {
                                            cmd.Parameters.AddWithValue("@id", id);
                                            cmd.Parameters.AddWithValue("@business_name", business_name);
                                            cmd.Parameters.AddWithValue("@password", password);
                                            cmd.Parameters.AddWithValue("@status", status);
                                            cmd.Parameters.AddWithValue("@phone_number", phone_number);
                                            cmd.Parameters.AddWithValue("@email", email);
                                            cmd.Parameters.AddWithValue("@city", city);
                                            cmd.Parameters.AddWithValue("@district", district);
                                            cmd.Parameters.AddWithValue("@neighbourhood", neighbourhood);
                                            cmd.Parameters.AddWithValue("@situation", situation);
                                            cmd.Parameters.AddWithValue("@starting_date", starting_date);
                                            cmd.Parameters.AddWithValue("@ending_date", ending_date);
                                            cmd.Parameters.AddWithValue("@image_name", image_name);
                                            cmd.Parameters.AddWithValue("@location", location);
                                            cmd.Parameters.AddWithValue("@business_type_id", business_type_id);
                                            int i = cmd.ExecuteNonQuery();
                                            con.Close();
                                            if (i == 1)
                                                return "Güncellendi";
                                            else
                                                return "Güncellenemedi";
                                        }
                                    }
                                    catch (Exception)
                                    {
                                        return "Güncellenemedi";
                                    }
                                }
                            }
                        }
                        catch (Exception)
                        {
                            return "Hatalı kullanıcı adı girdiniz";
                        }
                    }
                }
            }
            catch (Exception)
            {
                return "İşlem başarısız";
            }

        }
        
        public string GetPasswordReset(string id, string oldpassword, string newpassword)
        {
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["webapi"].ConnectionString;
                using (
                    SqlConnection con = new SqlConnection(constr))
                {
                    con.Open();
                    {
                        try
                        {
                            SqlConnection FDataConnect = new SqlConnection(ConfigurationManager.ConnectionStrings["webapi"].ToString());
                            FDataConnect.Open();
                            SqlDataAdapter FDataAdapter = new SqlDataAdapter(string.Format("select password from business where id=" + id), FDataConnect);
                            DataTable dataTable = new DataTable();
                            FDataAdapter.Fill(dataTable);
                            if (dataTable.Rows.Count > 0)
                            {
                                if (dataTable.Rows[0].ItemArray[0].ToString() == oldpassword) //eski şifreyle veri tabanındaki şifre aynı ise
                                {
                                    using (SqlCommand cmd = new SqlCommand("update business set password=@password where id=@id", con))
                                    {
                                        cmd.Parameters.AddWithValue("@id", id);
                                        cmd.Parameters.AddWithValue("@password", newpassword);
                                        int i = cmd.ExecuteNonQuery();
                                        con.Close();
                                        if (i == 1)
                                            return "Şifre güncellendi";
                                        else
                                            return "Şifre güncellenemedi";
                                    }
                                }
                                else
                                {
                                    return "Eski şifrenizi yanlış girdiniz";
                                }
                            }
                            else
                            {
                                return "Bu kullanıcı bulunamadı";
                            }
                        }
                        catch (Exception)
                        {
                            return "Şifre yenilenemedi";
                        }
                    }
                }
            }
            catch (Exception)
            {
                return "İşlem başarısız";
            }

        }
        
    }
}
