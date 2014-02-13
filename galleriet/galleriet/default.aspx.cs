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
        private Gallery _gallery;
        
        // Property setting Gallery
        public Gallery gallery
        {
            // Lazy initializasion, if null at left side, create gallery instance, else return the already initialized field.
            get { return _gallery ?? (_gallery = new Gallery()); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            // Setting my CurrentImage controls url to the path of the picture in querystring that is selected from my hyperlink control onclick.
            CurrentImage.ImageUrl = "~/Files/Images/" + Request.QueryString;
        }

        public IEnumerable<System.String> Repeater_GetData()
        {
            return gallery.GetImageNames();
        }

        protected void Upload_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                var selectedPic = Select.FileContent;
                var filename = Select.FileName;
                // Try/catch that throw customized error from my Gallery.cs file and present them in my validationsummary control.
                try
                {
                    gallery.SaveImage(selectedPic, filename);
                    Literal.Visible = true;
                    Literal.Text = String.Format("Bilden {0} har laddats upp.", filename);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(String.Empty, ex.Message);
                }
            }
        }
    }
}