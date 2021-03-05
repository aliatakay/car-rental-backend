using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleUI
{
    public static class FileHelper
    {
        public static string RenameImageWithGuid(string imageName)
        {
            string path = $"C:\\Users\\asus\\Desktop\\images\\";

            string imagePath = string.Concat(path, imageName);

            string guid = Guid.NewGuid().ToString();

            string newImageName = string.Concat(path, guid, ".png");

            File.Move(imagePath, newImageName);

            return newImageName;
        }

        public static void MoveImage(string imageName)
        {
            string path = $"C:\\Users\\asus\\Desktop\\images\\";

            string imagePath = string.Concat(path, imageName);

            string newImagePath = string.Concat(@"C:\Users\asus\Desktop\C#\RentalManagement\BLL\Constants\", imageName);

            File.Move(imagePath, newImagePath);

        }
    }
}
