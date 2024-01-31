using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement;
using System.Collections.Generic;

namespace LibraryManagement
{   
        public interface IDataAccess<T>
        {
            void WriteToFile(List<T> data, string filePath);
            List<T> ReadFromFile(string filePath);
            void UpdateFile(List<T> data, string filePath);
        }
    

}