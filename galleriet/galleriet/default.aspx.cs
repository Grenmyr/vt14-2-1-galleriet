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
        // Property to check if any Session MSG
        private bool HasMessage
        {
            get { return Session["text"] != null; }
        }

        // Property to set and get SessionMSG
        public string Message
        {
            get
            {
                var message = Session["text"] as string;
                Session.Remove("text");
                return message;
            }

            set { Session["text"] = value; }
        }

        // Propety setting Filename
        public string FileName
        {
            get { return Request.QueryString["name"]; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            // Setting my CurrentImage controls url to the path to the picture + querystring that i get from my Property FileName.
            CurrentImage.ImageUrl = "~/Files/Images/" + FileName;

            if (HasMessage)
            {
                Literal.Visible = true;
                Literal.Text = Message;
            }
        }

        public IEnumerable<System.String> Repeater_GetData()
        {
            return gallery.GetImageNames();
        }

        protected void Upload_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                // Fråga mats om säkerhet jämfört med querystring genom att gå via kontrollen.
                var selectedPic = Select.FileContent;
                var selectedName = Select.FileName;
                // Try/catch that throw customized error from my Gallery.cs file and present them in my validationsummary control.
                try
                {
                    var savedfilename = gallery.SaveImage(selectedPic, selectedName);
                    Message = String.Format("Du har laddat upp {0}", savedfilename);
                    Response.Redirect("?name=" + savedfilename);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(String.Empty, ex.Message);
                }
            }
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                if (FileName != null)
                {
                    try
                    {
                            gallery.DeleteImage(FileName);
                            Message = String.Format("Du har tagit bort{0}", FileName);
                            Response.Redirect("?name=" + FileName);
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError(String.Empty, ex.Message);
                    }
                }
            }
        }
    }
}