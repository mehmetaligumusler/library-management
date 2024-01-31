//Books.cs

using System;
using System.Collections.Generic;
using System.Linq;
using LibraryManagement;

namespace LibraryManagement
{

    #region Book Class
    
    public class Book
    {
        

        
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string BookAuthor { get; set; }
        public int BookCopies { get; set; }
        public int BookYear { get; set; }
        public int BookPages { get; set; }
        public void DisplayDetails()
        {
            Console.WriteLine($"{this.BookId,-15}{this.BookName,-15}{this.BookAuthor,-15}{this.BookCopies,-15}{this.BookYear,-15}{this.BookPages,-15}");
        }
        
        public Book()
        {
            BookId = 0;
            BookName = string.Empty;
            BookAuthor = string.Empty;
            BookCopies = 0;
            BookYear = 0;
            BookPages = 0;
        }
        
    }
    #endregion


    #region Book Operation
    public class BookDAL
    {

        //LIST USED TO STORE BOOK DETAILS =>DAL
        public static List<Book> books = new List<Book>();

        //RETURNING BOOKS FROM BOOK TABLE =>DAL
        public List<Book> GetAllBooksDAL()
        {
            return books;
        }

        


        //ADDING BOOKS INTO BOOK TABLE =>DAL
        public bool AddBooksDAL(int bookId, string bookName, string bookAuthor, int bookCopies, int bookYear, int bookPages)
        {
            bool isDone = false;
            try
            {
                Book addBook = new Book() { BookId = bookId, BookName = bookName, BookAuthor = bookAuthor, BookCopies = bookCopies, BookYear = bookYear, BookPages = bookPages};
                books.Add(addBook);
                isDone = true;

            }
            catch (ApplicationException e)
            {
                isDone = false;
                throw new LibraryMSException(e.Message);
            }
            return isDone;
        }

        //UPDATING BOOKS FROM BOOK TABLE =>DAL
        public bool UpdateBooksDAL(int bookId, string bookName, string bookAuthor, int bookCopies, int bookYear, int bookPages)
        {
            bool isDone = false;
            try
            {
                Book updateBook = books.Find(s => s.BookId == bookId);
                updateBook.BookName = bookName;
                updateBook.BookAuthor = bookAuthor;
                updateBook.BookCopies = bookCopies;
                updateBook.BookYear = bookYear;
                updateBook.BookPages = bookPages;
                isDone = true;
            }
            catch (ApplicationException e)
            {
                isDone = false;
                throw new LibraryMSException(e.Message);

            }
            return isDone;
        }

        //REMOVING BOOKS FROM BOOK TABLE =>DAL
        public bool RemoveBooksDAL(int bookId)
        {
            bool isDone = false;
            try
            {
                Book removeBook = books.Find(s => s.BookId == bookId);
                books.Remove(removeBook);
                isDone = true;
            }
            catch (ApplicationException e)
            {
                isDone = false;
                throw new LibraryMSException(e.Message);
            }
            return isDone;
        }
    }
    #endregion


    #region Book Validation
    public class BookBLL
    {

        private bool BookValidation(int bookId, string bookName, string bookAuthor, int bookCopies, int bookYear, int bookPages)
        {
            bool bookValid;

            if (bookId == 0 || bookId >= 100000)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(1, 1);
                Console.WriteLine("Invalid Book id!!!, book id should be in between 1 to 100000");
                Console.ForegroundColor = ConsoleColor.White;

                bookValid = false;
            }
            else if (bookName.Length <= 2 || bookName.Length > 30)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(1, 1);
                Console.WriteLine("Invalid Book name!!!, minimum 3 maximum 30 characters are allowed");
                Console.ForegroundColor = ConsoleColor.White;

                bookValid = false;
            }
            else if (bookName.Any(char.IsDigit))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(1, 1);
                Console.WriteLine("Invalid Book name!!!, name should not contains digits");
                Console.ForegroundColor = ConsoleColor.White;

                bookValid = false;
            }

            else if (bookAuthor.Length <= 2 || bookAuthor.Length > 30)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(1, 1);
                Console.WriteLine("Invalid Author name!!!, minimum 3 maximum 30 characters are allowed");
                Console.ForegroundColor = ConsoleColor.White;

                bookValid = false;
            }
            else if (bookAuthor.Any(char.IsDigit))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(1, 1);
                Console.WriteLine("Invalid Author name!!!, name should not contains digits");
                Console.ForegroundColor = ConsoleColor.White;

                bookValid = false;
            }

            else if (bookCopies == 0 || bookCopies > 200)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(1, 1);
                Console.WriteLine("Invalid Book copies!!!, book id should be in between 1 to 200");
                Console.ForegroundColor = ConsoleColor.White;

                bookValid = false;
            }
            else if (bookYear == 0 || bookYear > 10000)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(1, 1);
                Console.WriteLine("Invalid Book year!!!, book year should be 1 to 10000");
                Console.ForegroundColor = ConsoleColor.White;

                bookValid = false;
            }
            else if (bookPages ==0 || bookPages > 15000)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(1, 1);
                Console.WriteLine("Invalid Book pages!!!, book pages should be 1 to 15000");
                Console.ForegroundColor = ConsoleColor.White;

                bookValid = false;
            }  
            else
            {
                bookValid = true;
            }
            return bookValid;
        }


        BookDAL dalBook = new BookDAL();
        //ADDING BOOK INTO BOOK TABLE =>BLL
        public void AddBookBLL(int bookId, string bookName, string bookAuthor, int bookCopies, int bookYear, int bookPages)
        {

            Console.Clear();
            bool isValidated = BookValidation(bookId, bookName, bookAuthor, bookCopies, bookYear, bookPages);
            if (isValidated)
            {
                /*BookDAL dalBook = new BookDAL();*/
                bool isDone = dalBook.AddBooksDAL(bookId, bookName, bookAuthor, bookCopies, bookYear, bookPages);
                if (isDone == true)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(1, 1);
                    Console.WriteLine("Book added successfully...");
                    Console.ForegroundColor = ConsoleColor.White;

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(1, 1);
                    Console.WriteLine("Try again...");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(1, 1);
                Console.WriteLine("Try again...");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        //UPDATING BOOK FROM BOOK TABLE =>BLL 
        public void UpdateBookBLL(int bookId, string bookName, string bookAuthor, int bookCopies, int bookYear, int bookPages)
        {
            bool isValidated = BookValidation(bookId, bookName, bookAuthor, bookCopies, bookYear, bookPages);
            if (isValidated)
            {
                /* BookDAL dalBook = new BookDAL();*/
                bool isDone = dalBook.UpdateBooksDAL(bookId, bookName, bookAuthor, bookCopies, bookYear, bookPages);
                if (isDone == true)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(1, 1);
                    Console.WriteLine("Book updated successfully...");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(1, 1);
                    Console.WriteLine("Try again...");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(1, 1);
                Console.WriteLine("Try again...");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        //REMOVING BOOK FROM BOOK TABLE =>BLL
        public void RemoveBookBLL(int bookId)
        {
            if (bookId != 0 || bookId <= 100000)
            {
                /*BookDAL dalBook = new BookDAL();*/
                bool isDone = dalBook.RemoveBooksDAL(bookId);
                if (isDone == true)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(1, 1);
                    Console.WriteLine("Book deleted successfully...");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(1, 1);
                    Console.WriteLine("Try again...");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(1, 1);
                Console.WriteLine("Invalid Book id!!!");
                Console.SetCursorPosition(1, 2);
                Console.WriteLine("Try again...");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        //RETURNING BOOKS FROM BOOK TABLE =>BLL
        public List<Book> GetAllBookBLL()
        {
            Console.Clear();
            List<Book> books = dalBook.GetAllBooksDAL();
            return books;
        }

    }
    #endregion

}

