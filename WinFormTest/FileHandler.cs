using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WinFormTest
{
    public class FileHandler
    {
        private static int _readLength = 1024; // byte 
        public static bool ReadFile(string filePath)
        {
            bool result = default(bool);
            try
            {
                if (IsExistsFile(filePath))
                {
                    FileInfo _fInfo = new FileInfo(filePath);
                    if (_fInfo.Length == 0)
                    {
                        throw new Exception("File is Empty");
                    }
                    using (FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                    {
                        int readlength = 0;
                        byte[] b = new byte[_readLength];
                        do
                        {
                            readlength = stream.Read(b, 0, _readLength);
                            b = new byte[_readLength];
                        }
                        while (readlength > 0);
                        result = true;
                    }
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static bool WriteFile(string FilePath, string Data)
        {
            bool result = default(bool);
            try
            {
                if (IsExistsFile(FilePath) && ValidateData(Data))
                {
                    using (FileStream fstream = new FileStream(FilePath, FileMode.Open, FileAccess.Write))
                    {
                        byte[] info = new UTF8Encoding(true).GetBytes(Data);

                        byte[] b = new byte[_readLength];
                        do
                        {
                            fstream.Write(b, 0, b.Length);
                        }
                        while (true);
                        
                    }
                }
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private static bool IsExistsFile(string filePath)
        {
            bool result = default(bool);
            try
            {
                result = (!string.IsNullOrEmpty(filePath) && File.Exists(filePath));
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static bool ValidateData(string Data)
        {
            if (string.IsNullOrEmpty(Data))
            {
                throw new Exception("Data is empty"); 
            }
            return true;
        }

    }
}
