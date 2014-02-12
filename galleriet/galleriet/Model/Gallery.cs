using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace galleriet.Model
{
    public class Gallery
    {
        private static readonly Regex ApprovedExtensions;
        private static readonly Regex SantizePath;
        private static string PhysicalUploadedImagesPath;
        private static string PhysicalUploadedThumbNailPath;

        // Constructor
        static Gallery()
        {
            //Setting Regex pattern to field.
            string pattern = @"^.*\.(gif|jpg|png)$";
            ApprovedExtensions = new Regex(pattern, RegexOptions.IgnoreCase);

            //Setting physical direction to my files
            PhysicalUploadedImagesPath = Path.Combine(AppDomain.CurrentDomain.GetData("APPBASE").ToString(), @"Files\Images");
            PhysicalUploadedThumbNailPath = Path.Combine(AppDomain.CurrentDomain.GetData("APPBASE").ToString(), @"Files\Thumbnails");

            // "GetInvalidFileNameChars()" is a built in collection of illegal chars, which i after saving into variable "invalidchars".
            // Using my expression "invalidchars "to set my field "sanitizePath" IF the regex escape "invalidchars"
            var invalidChars = new string(Path.GetInvalidFileNameChars());
            SantizePath = new Regex(string.Format("[{0}]", Regex.Escape(invalidChars)));
        }

        public IEnumerable<string> GetImageNames()
        {
            // Getting files from the path saving them into an array.
            var images = new DirectoryInfo(PhysicalUploadedImagesPath).GetFiles();
            List<string> imagesAdressList = new List<string>(50);

            for (int i = 0; i < images.Length; i++)
            {
                imagesAdressList.Add(images[i].ToString());
            }

            // Using "Select" loop my list to match against Regexobject approved extensions.
            imagesAdressList.Select(imageName => ApprovedExtensions.IsMatch(imageName));
            imagesAdressList.TrimExcess();
            imagesAdressList.Sort();

            return imagesAdressList.AsReadOnly();

        }

        public bool ImageExist(string name)
        {
           
            //return GetImageNames().Contains(name);
            return File.Exists(string.Format("{0}/{1}",PhysicalUploadedImagesPath, name));
        }

        private bool IsValidImage(Image image)
        {
            return image.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Gif.Guid ||
            image.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Jpeg.Guid ||
            image.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Png.Guid;
        }

        public string SaveImage(Stream stream, string fileName)
        {
            try
            {
                ApprovedExtensions.Match(fileName);
            }
            catch (Exception)
            {

                throw new ArgumentException("Du kan endast spara bilder i format gif|jpg|png");
            }
            throw new NotImplementedException("saveimagemetod");
        }
    }
}