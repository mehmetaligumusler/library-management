//DataAccess.cs


using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using LibraryManagement;

namespace LibraryManagement {
/// <summary>
/// Implementation of IDataAccess interface for managing book data in a file.
/// </summary>
public class BookDataAccess : IDataAccess<Book> {
  /// <summary>
  /// Write a list of Book objects to a binary file.
  /// </summary>
  /// <param name="data"></param>
  /// <param name="filePath"></param>
  public void WriteToFile(List<Book> data, string filePath) {
    using (BinaryWriter writer = new BinaryWriter(File.Open(filePath, FileMode.Create))) {
      foreach (var item in data) {
        writer.Write(item.BookId);
        writer.Write(item.BookName);
        writer.Write(item.BookAuthor);
        writer.Write(item.BookCopies);
        writer.Write(item.BookYear);
        writer.Write(item.BookPages);
      }
    }
  }

  /// <summary>
  /// Read a list of Book objects from a binary file.
  /// </summary>
  /// <param name="filePath"></param>
  /// <returns></returns>
  public List<Book> ReadFromFile(string filePath) {
    List<Book> books = new List<Book>();

    if (File.Exists(filePath)) {
      using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open), Encoding.Default)) {
        while (reader.BaseStream.Position < reader.BaseStream.Length) {
          int bookId = reader.ReadInt32();
          string bookName = reader.ReadString();
          string bookAuthor = reader.ReadString();
          int bookCopies = reader.ReadInt32();
          int bookYear = reader.ReadInt32();
          int bookPages = reader.ReadInt32();
          books.Add(new Book {
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


  /// <summary>
  /// Update a file with a new list of Book objects.
  /// </summary>
  /// <param name="data"></param>
  /// <param name="filePath"></param>
  public void UpdateFile(List<Book> data, string filePath) {
    WriteToFile(data, filePath);
  }
}
}
