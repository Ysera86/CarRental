using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace Core.Utilities.Helpers
{
    public class FileHelper
    {
        public static string Add(IFormFile file)
        {
            try
            {
                string currentPath = Directory.GetCurrentDirectory();

                var folderPath = Path.Combine(currentPath, "Upload", "Files");

                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);

                var filePath = Path.Combine(folderPath, Guid.NewGuid().ToString());
                if (file.Length > 0)
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyToAsync(stream);
                    }
                }

                return filePath;
            }
            catch (Exception excepiton)
            {
                return excepiton.Message;
            }

        }

        public static string Update(string filePath, IFormFile file)
        {

            try
            {
                File.Delete(filePath);

                string currentPath = Directory.GetCurrentDirectory();

                var folderPath = Path.Combine(currentPath, "Upload", "Files");

                filePath = Path.Combine(folderPath, Guid.NewGuid().ToString());

                if (file.Length > 0)
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyToAsync(stream);
                    }
                }

                return filePath;
            }
            catch (Exception excepiton)
            {
                return excepiton.Message;
            }
        }

        public static bool Delete(string filePath)
        {
            try
            {
                File.Delete(filePath);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}