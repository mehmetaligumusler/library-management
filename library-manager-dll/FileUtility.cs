// FileUtility.cs

using System.IO;
using System.Security.Cryptography;
using LibraryManagement;

namespace LibraryManagement {
/// <summary>
/// Utility class for file-related operations.
/// </summary>
public class FileUtility {
  /// <summary>
  /// Deletes a file if it exists.
  /// </summary>
  public static bool DeleteFile(string path) {
    if (File.Exists(path))
      File.Delete(path);

    return true;
  }

  /// <summary>
  /// Reads a block of data from a file.
  /// </summary>
  public static byte[] ReadBlock(int count, int blocksize, string path) {
    byte[] buffer = new byte[blocksize];

    using (FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read)) {
      fileStream.Seek((count - 1) * blocksize, SeekOrigin.Begin);
      fileStream.Read(buffer, 0, buffer.Length);
    }

    return buffer;
  }

  /// <summary>
  /// Appends a block of data to the end of a file.
  /// </summary>
  public static bool AppendBlock(byte[] data, string path) {
    using (FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write)) {
      fileStream.Seek(0, SeekOrigin.End);
      fileStream.Write(data, 0, data.Length);
    }

    return true;
  }

  /// <summary>
  /// Updates a block of data in a file.
  /// </summary>
  public static bool UpdateBlock(byte[] data, int count, int blocksize, string path) {
    using (FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write)) {
      fileStream.Seek((count - 1) * blocksize, SeekOrigin.Begin);
      fileStream.Write(data, 0, data.Length);
    }

    return true;
  }

  /// <summary>
  /// Deletes a block of data in a file.
  /// </summary>
  public static bool DeleteBlock(int count, int blocksize, string path) {
    byte[] data = new byte[blocksize];

    using (FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write)) {
      fileStream.Seek((count - 1) * blocksize, SeekOrigin.Begin);
      fileStream.Write(data, 0, data.Length);
    }

    return true;
  }
}
}
