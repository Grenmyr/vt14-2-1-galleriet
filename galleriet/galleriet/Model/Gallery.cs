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
        Regex ApprovedExtensions;
        Regex SantizePath;
        string PhysicalUploadedImagesPath;

        // Konstruktor
        private static Gallery()
        {
        }

        public IEnumerable<string> GetImageNames()
        {

            throw new NotImplementedException("Tom metod");
        }

        public bool ImageExist(string name)
        {
            throw new NotImplementedException("tom imageexistmetod");
        }

        private bool IsValidImage(Image image)
        {
            throw new NotImplementedException("tom isvalidimagemetod");
        }

        public string SaveImage(Stream stream, string fileName)
        {
            throw new NotImplementedException("saveimagemetod");
        }
    }
}