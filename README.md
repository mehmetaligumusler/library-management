# Library Management System

This project contains a simple C# application simulating a library management system. The library system includes the ability to add, update, delete books, and list existing books. Additionally, there is an admin module for user authentication to log in to the system.

## Project Structure

The project consists of the following key components:

- **LibraryManagement**: Main project folder containing the source code.
  - **DataAccess.cs**: Defines data access operations for book entities.
  - **Books.cs**: Represents the book entity, data access layer, business logic layer, and validation.
  - **Admin.cs**: Manages admin entities, data access layer, and validation.
  - **IDataAccess.cs**: Interface defining generic data access operations.
  - **ConversionUtility.cs**: Utility methods for data conversion.
  - **FileUtility.cs**: Utility methods for file operations.
  - **LibraryMSException.cs**: Custom exception class for the library management system.

## How to Run

To run the project, follow these steps:

1. Clone the repository: `git clone https://github.com/mehmetaligumusler/library-management.git`
2. Open the solution in Visual Studio.
3. Build the solution.
4. Run the application.

Feel free to explore and enhance the functionality as needed. Contributions are welcome!

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
