using System;
using System.Collections.Generic;
using LibraryManagement;

namespace LibraryManagement
{

    #region Admin Class
    public class Admin
    {
        public int AdminId { get; set; }
        public string AdminName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Admin()
        {
            AdminId = 0;
            AdminName = string.Empty;
            Username = string.Empty;
            Password = string.Empty;
        }
    }
    #endregion


    #region Admin Data
    public class AdminDAL
    {

        //LIST USED TO STORE ADMINS DETAILS
        private static List<Admin> admins = new List<Admin>()
        {
            new Admin()
            {
                AdminId=1,AdminName="Librarian",Username="",Password=""
            },
        };
        //RETURNING ADMIN FROM ADMIN TABLE =>DAL
        public List<Admin> GetAllAdminsDAL()
        {
            return admins;
        }
    }
    #endregion


    #region Admin Validation
    public class AdminBLL
    {
        //CHECKING ADMIN LOGIN CREDENTIALS  =>BLL
        public bool AdminLogin(string adminUsername, string adminPass)
        {
            AdminDAL adminDAL = new AdminDAL();
            List<Admin> admins = adminDAL.GetAllAdminsDAL();
            bool isDone = admins.Exists(a => a.Username == adminUsername && a.Password == adminPass);
            if (isDone)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Logged in successfully...");
                Console.ForegroundColor = ConsoleColor.White;
                return true;
            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid Username or Password...");
                Console.ForegroundColor = ConsoleColor.White;
                return false;
            }
        }
    }
    #endregion
}
