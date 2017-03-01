using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShoppingWebApp.BusinessLayer
{
    //User details
    public class User
    {
        public int ID { get; set; }
        public string Login { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        //Constructor for User

        public User(int id, string firstname, string lastname, string username, string password, string confirmPassword, string email, string address, string city, string country)
        {
            ID = id;
            FirstName = firstname;
            LastName = lastname;
            Username = username;
            Password = password;
            ConfirmPassword = confirmPassword;
            Email = email;
            Address = address;
            City = city;
            Country = country;
        }

        //Constructor without ID
        public User( string firstname, string lastname, string username, string password, string confirmPassword, string email, string address, string city, string country)
        {
            FirstName = firstname;
            LastName = lastname;
            Username = username;
            Password = password;
            ConfirmPassword = confirmPassword;
            Email = email;
            Address = address;
            City = city;
            Country = country;
        }

    }
}