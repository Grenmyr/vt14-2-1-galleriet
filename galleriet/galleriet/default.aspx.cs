using galleriet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace galleriet
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public IEnumerable<System.String> Repeater_GetData()
        {
            var gallery = new Gallery();
            return gallery.GetImageNames();
        }

        protected void Upload_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                var selectedPic = FileUpload.FileContent;
                var filename = FileUpload.FileName;
                var gallery = new Gallery();

                // Try/catch that throw customized error from my Gallery.cs file and present them in my validationsummary control.
                try
                {
                    gallery.SaveImage(selectedPic, filename);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(String.Empty, ex.Message);
                }
            }
        }
    }
}