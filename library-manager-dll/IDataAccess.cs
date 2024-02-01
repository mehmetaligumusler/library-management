﻿//IDataAccess.cs

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement;
using System.Collections.Generic;

namespace LibraryManagement {
/// <summary>
/// Generic interface for data access operations.
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IDataAccess<T> {
  /// <summary>
  /// Writes data to a file
  /// </summary>
  /// <param name="data"></param>
  /// <param name="filePath"></param>
  void WriteToFile(List<T> data, string filePath);

  /// <summary>
  /// Reads data from a file.
  /// </summary>
  /// <param name="filePath"></param>
  /// <returns></returns>
  List<T> ReadFromFile(string filePath);
  /// <summary>
  /// Updates data in a file.
  /// </summary>
  /// <param name="data"></param>
  /// <param name="filePath"></param>
  void UpdateFile(List<T> data, string filePath);
}


}