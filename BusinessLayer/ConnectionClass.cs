using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OnlineShoppingWebApp.BusinessLayer
{
    public static class ConnectionClass
    {
        private static SqlConnection conn;
        private static SqlCommand command;

        static ConnectionClass()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyConn"].ToString();
            conn = new SqlConnection(connectionString);
            command = new SqlCommand("", conn);
        }

        public static User UserLogin(string Username, string Password)
        {
            //Check if user exist
            string query = string.Format("select count(*) from Registration where Username='{0}' and Password='{1}'", Username, Password);

            command.CommandText = query;

            try
            {
                conn.Open();

                int amountOfUsers = (int)command.ExecuteScalar();

                if(amountOfUsers > 0)
                {
                    //as User Exists, check if Password match
                    query = string.Format("select Password from Registration where Username='{0}'", Username);
                    command.CommandText = query;
                    string dbPassword = command.ExecuteScalar().ToString();

                    if (Password.Equals(Password))
                    {
                        //As Password match. Password and Login are known to us
                        //Retrive rest of the user data from database
                        query = string.Format("select Email, FirstName, LastName, ConfirmPassword, Address, City, Country from Registration where Username='{0}'", Username);
                        command.CommandText = query;

                        SqlDataReader sdr = command.ExecuteReader();

                        User user = null;

                        while (sdr.Read())
                        {
                            string Email = sdr.GetString(0);
                            string FirstName = sdr.GetString(1);
                            string LastName = sdr.GetString(2);
                            string ConfirmPassword = sdr.GetString(3);
                            string Address = sdr.GetString(4);
                            string City = sdr.GetString(5);
                            string Country = sdr.GetString(6);

                            user = new User(FirstName, LastName, Username, Password, ConfirmPassword, Address, City, Country, Email);

                        }//closing of while

                        return user;
                    }//closing inner if
                    else
                    {
                        //Password does not match
                        return null;
                    }
                }//closing of outer if
                else
                {
                    //user does not exist
                    return null;
                }
            }//try close
            finally
            {
                conn.Close();//closing connectionstring
            }
        }

        //Method which register a user
        public static string RegisterUser(User user)
        {
            //Check if User exits
            string query = string.Format("select count(*) from Registration where Username='{0}'", user.Username);
            command.CommandText = query;

            try
            {
                conn.Open();//opening connectionstring
                int amountOfUsers = (int)command.ExecuteScalar();

                if(amountOfUsers < 1)
                {
                    //User does not exit, create a new User
                    query = string.Format("insert into Registration values ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}')", user.FirstName, user.LastName,
                        user.Username, user.Password, user.ConfirmPassword, user.Email, user.Address, user.City, user.Country);

                    command.CommandText = query;
                    command.ExecuteNonQuery();

                    return "User has been registered Successfully!";
                }
                else
                {
                    return "User already exists!";
                }
            }
            finally
            {
                //closing connection
                conn.Close();
                command.Parameters.Clear();

            }
        }

        //Method to update OrderDetails 
        public static void UpdateOrderDetails(int OrderId, string PaymentTransactionId)
        {
            //query to update OrderDetails table
            string query = "Update OrderDetails set PaymentTransactionId=@PaymentTransactionId where OrderId=@OrderId";

            conn.Open();
            command.CommandText = query;

            command.Parameters.Add(new SqlParameter("@OrderId", OrderId));
            command.Parameters.Add(new SqlParameter("@PaymentTransactionId", PaymentTransactionId));

            command.ExecuteNonQuery();
            conn.Close();
        }

        //Method to get Max OrderId from OrderDetails table

        public static string GetMaxOrderId()
        {
            string query = "select Max(OrderId) from OrderDetails";
            
            conn.Open();
            command.CommandText = query;

            //  command.Parameters.Add(new SqlParameter("@OrderId", OrderId));

           string maxOrderId = command.ExecuteScalar().ToString();

            conn.Close();
            return maxOrderId;
        }
    }
}