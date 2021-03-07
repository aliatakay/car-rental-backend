using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace Core.Utilities.Helpers
{
    public static class FileHelper
    {
        public static string StoreImageFile(IFormFile image, string directory)
        {
            string imagePath = Path.GetTempFileName();

            if (image.Length > 0)
            {
                using (var fileStream = new FileStream(imagePath, FileMode.Create))
                {
                    image.CopyTo(fileStream);
                }
            }

            string fileName = image.FileName;

            string fileExtension = Path.GetExtension(fileName);

            string uniqueName = Guid.NewGuid().ToString();

            string newFileName = string.Concat(uniqueName, fileExtension);

            string newFilePath = string.Concat(directory, newFileName);

            File.Move(imagePath, newFilePath);

            return newFilePath;
        }
    }
}
