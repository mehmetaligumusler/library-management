// DataAccess.cs


using System;
using System.Collections.Generic;
using System.IO;
using LibraryManagement;

namespace LibraryManagement
{
    public class BookDataAccess : IDataAccess<Book>
    {
        public void WriteToFile(List<Book> data, string filePath)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(filePath, FileMode.Create)))
            {
                foreach (var item in data)
                {
                    writer.Write(item.BookId);
                    writer.Write(item.BookName);
                    writer.Write(item.BookAuthor);
                    writer.Write(item.BookCopies);
                    writer.Write(item.BookYear);
                    writer.Write(item.BookPages);
                }
            }
        }

        public List<Book> ReadFromFile(string filePath)
        {
            List<Book> books = new List<Book>();

            if (File.Exists(filePath))
            {
                using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
                {
                    while (reader.PeekChar() > -1)
                    {
                        int bookId = reader.ReadInt32();
                        string bookName = reader.ReadString();
                        string bookAuthor = reader.ReadString();
                        int bookCopies = reader.ReadInt32();
                        int bookYear = reader.ReadInt32();
                        int bookPages = reader.ReadInt32();

                        books.Add(new Book
                        {
                            BookId = bookId,
                            BookName = bookName,
                            BookAuthor = bookAuthor,
                            BookCopies = bookCopies,
                            BookYear = bookYear,
                            BookPages = bookPages
                        });
                    }
                }
            }

            return books;
        }

        public void UpdateFile(List<Book> data, string filePath)
        {
            WriteToFile(data, filePath);
        }
    }
}
