using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using LibraryManagement;

namespace LibraryManagementApp
{

    #region Main Panel
    class Program
    {
        
        static void Main(string[] args)
        {
            bool logLoop = true;
            while (logLoop == true)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(36, 4);
                    Console.WriteLine("Wellcome to Library Management System");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(45, 10);
                    Console.WriteLine("1) Press 1 to login");
                    
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(45, 12);
                    Console.WriteLine("2) Press 2 to exit");
                   

                    int logCase = int.Parse(Console.ReadLine());
                    switch (logCase)
                    {
                        case 1:
                            AdminPL adminPL = new AdminPL();
                            adminPL.AdminLogin();
                            break;

                        case 2:
                            Console.Clear();
                            logLoop = false;
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Enter a valid input...");
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                    }
                }
                catch (FormatException)
                {
                    logLoop = true;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Try again...");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                catch (LibraryMSException)
                {
                    throw new LibraryMSException("Some unknown exception is occured..");
                }
            }
        }

    }
    #endregion


    #region Admin Panel
    public class AdminPL
    {
        //INDIVIDUAL ADMIN LOGIN CREDENTIAL CHECKING
        public void AdminLogin()
        {
            try
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(50, 4);
                Console.WriteLine("Admin Login");
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(45, 10);
                Console.Write("Username: ");
                string adminUsername = Console.ReadLine();
                Console.SetCursorPosition(45, 12);
                Console.Write("Password: ");
                string adminPass = Console.ReadLine();
                AdminBLL adminBLL = new AdminBLL();
                bool isDone = adminBLL.AdminLogin(adminUsername, adminPass);
                if (isDone)
                {
                    AdminSection();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Try again...");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            catch (LibraryMSException)
            {
                throw new LibraryMSException("Some unknown exception is occured..");
            }

        }
        //ADMIN MENU
        private void GetAdminMenu()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(44, 4);
            Console.WriteLine("Library Management System");
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(45, 10);
            Console.WriteLine("1) Press 1 to show book section");
            Console.SetCursorPosition(45, 12);
            Console.WriteLine("2) Press 2 to ");




            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(59, 12);
            Console.Write("logout");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;

        }
        
        private void AdminSection()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(44, 4);
            Console.WriteLine("Library Management System");
            Console.ForegroundColor = ConsoleColor.White;
            bool adminLoop = true;
            while (adminLoop == true)
            {
                try
                {
                    GetAdminMenu();
                    int adminCase = int.Parse(Console.ReadLine());
                    switch (adminCase)
                    {
                        case 1:
                            BookPL bookSection = new BookPL();
                            bookSection.BookSection();
                            break;

                        case 2:
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Logged out successfully..\nTada have a nice day...");
                            Console.ForegroundColor = ConsoleColor.White;
                            adminLoop = false;
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid input!!!");
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Sorry try agian once!!!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                catch (LibraryMSException)
                {
                    throw new LibraryMSException("Some unknown exception is occured..");
                }
            }
        }
    }
    #endregion


    #region Book Panel
    class BookPL
    {
        private Book book = new Book();
        //BOOK MENU
        private void GetBookMenu()
        {

            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(44, 4);
            Console.WriteLine("Library Management System");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(50, 7);
            Console.WriteLine("# Menu Books #");
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(45, 10);
            Console.WriteLine("1. Add Books");
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(45, 12);
            Console.WriteLine("2. Update Books");
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(45, 14);
            Console.WriteLine("3. Delete Books");
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(45, 16);
            Console.WriteLine("4. View All Books");
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(45, 18);
            Console.WriteLine("5. Search Book");
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(45, 22);
            Console.WriteLine("6. Press 6 to exit");

        }
        //ADD BOOK INTO BOOK TABLE
        private void AddBook()
        {
            Console.Clear();
            try
            {

                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(45, 4);
                Console.WriteLine("Enter book details..");
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(45, 10);
                Console.Write("Book ID: ");
                book.BookId = int.Parse(Console.ReadLine());
                Console.SetCursorPosition(45, 12);
                Console.Write("Book Name: ");
                book.BookName = Console.ReadLine();
                Console.SetCursorPosition(45, 14);
                Console.Write("Book Author: ");
                book.BookAuthor = Console.ReadLine();
                Console.SetCursorPosition(45, 16);
                Console.Write("Book Copies: ");
                book.BookCopies = int.Parse(Console.ReadLine());
                Console.SetCursorPosition(45, 18);
                Console.WriteLine("Book Year: ");
                book.BookYear = int.Parse(Console.ReadLine());
                Console.SetCursorPosition(45, 20);
                Console.WriteLine("Book Pages: ");
                book.BookPages= int.Parse(Console.ReadLine());
                BookBLL addBook = new BookBLL();
                addBook.AddBookBLL(book.BookId, book.BookName, book.BookAuthor, book.BookCopies, book.BookYear, book.BookPages);
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(1, 1);
                Console.WriteLine("Enter a valid input");
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (LibraryMSException)
            {
                throw new LibraryMSException("Some unknown exception is occured..");
            }
        }
        //UPDATE BOOK FROM BOOK TABLE
        private void UpdateBook()
        {
            Console.Clear();
            try
            {

                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(45, 4);
                Console.WriteLine("Enter book details..");
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(45, 10);
                Console.Write("Book ID: ");
                book.BookId = int.Parse(Console.ReadLine());
                Console.SetCursorPosition(45, 12);
                Console.Write("Book Name: ");
                book.BookName = Console.ReadLine();
                Console.SetCursorPosition(45, 14);
                Console.Write("Book Author: ");
                book.BookAuthor = Console.ReadLine();
                Console.SetCursorPosition(45, 16);
                Console.Write("Book Copies: ");
                book.BookCopies = int.Parse(Console.ReadLine());
                Console.SetCursorPosition(45, 18);
                Console.WriteLine("Book Year: ");
                book.BookYear = int.Parse(Console.ReadLine());
                Console.SetCursorPosition(45, 20);
                Console.WriteLine("Book Pages: ");
                book.BookPages= int.Parse(Console.ReadLine());
                BookBLL updateBook = new BookBLL();
                updateBook.UpdateBookBLL(book.BookId, book.BookName, book.BookAuthor, book.BookCopies, book.BookYear, book.BookPages);
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(1, 1);
                Console.WriteLine("Enter a valid input");
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (LibraryMSException)
            {
                throw new LibraryMSException("Some unknown exception is occured..");
            }
        }
        //REMOVE BOOK FROM BOOK TABLE
        private void RemoveBook()
        {
            Console.Clear();
            try
            {

                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(45, 4);
                Console.WriteLine("Enter book details..");
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(45, 10);
                Console.Write("Book ID: ");
                book.BookId = int.Parse(Console.ReadLine());
                BookBLL removeBook = new BookBLL();
                removeBook.RemoveBookBLL(book.BookId);
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(1, 1);
                Console.WriteLine("Enter a valid input");
                Console.ForegroundColor = ConsoleColor.White;
            }
            /*catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Enter a valid input");
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (Exception)
            {
                throw new LibraryMSException("Some unknown exception is occured..");
            }*/
        }
        //RETRIEVE BOOKS FROM BOOK TABLE
        public void GetAllBook()
        {

            List<Book> books = new List<Book>();
            BookBLL bookTemp = new BookBLL();
            books = bookTemp.GetAllBookBLL();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("ID" + "\t" + "Name" + "\t" + "Author" + "\t" + "Copies" + "\t" + "Year" + "\t" + "Pages");
            Console.ForegroundColor = ConsoleColor.White;
            foreach (Book book in books)
            {
                Console.WriteLine(book.BookId + "\t" + book.BookName + "\t" + book.BookAuthor + "\t" + book.BookCopies + "\t" + book.BookYear + "\t" + book.BookPages);
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("----------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" Press Enter To Go Back Menu ");
            Console.ReadKey();
            Console.Clear();
        }

        internal void SearchBook()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(45, 4);
            Console.WriteLine("Enter book details..");
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(45, 10);
                Console.Write("Enter name of the book: ");
                string search = Console.ReadLine();
                
                //var bTitle = Console.ReadLine();
                foreach (var book in BookDAL.books)
                {
                    if (search == book.BookName )
                    {
                        Console.Clear();
                        
                        Console.ForegroundColor = ConsoleColor.Green;
                        //Console.SetCursorPosition(1, 1);
                        Console.WriteLine("Search Results");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine($"{"ID",-15}{"Name",-15}{"Author",-15}{"Copies",-15}{"Year",-15}{"Pages",-15}");
                        Console.WriteLine("".PadRight(100, '-'));
                        book.DisplayDetails();
                        Console.SetCursorPosition(1, 10);
                        Console.WriteLine(" Press Enter To Go Back Menu ");
                        Console.ReadKey();
                        Console.Clear();
                        return;
                    }
                }
                
                //Beautify.Error("Book doesn't exist");
            }
            
            //Beautify.ClearScreen("continue");
        }


            //COMPLETE BOOK SECTION
            public void BookSection()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            bool bookLoop = true;
            while (bookLoop == true)
            {
                try
                {
                    GetBookMenu();
                    int bookCase = int.Parse(Console.ReadLine());
                    switch (bookCase)
                    {
                        case 1:
                            AddBook();
                            break;
                        case 2:
                            UpdateBook();
                            break;
                        case 3:
                            RemoveBook();
                            break;
                        case 4:
                            GetAllBook();
                            break;
                        case 5:
                            SearchBook();
                            break;
                        case 6:
                            Console.Clear();
                            Console.WriteLine("");
                            bookLoop = false;
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.SetCursorPosition(1, 1);
                            Console.WriteLine("Invalid input!!!");
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(1, 1);
                    Console.WriteLine("Sorry try agian once!!!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                catch (LibraryMSException)
                {
                    throw new LibraryMSException("Some unknown exception is occured..");
                }
            }
        }
    }
    #endregion

}