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

        protected void Browse_Click(object sender, EventArgs e)
        {

        }

        public IEnumerable<System.String> Repeater_GetData()
        {
             var gallery = new Gallery();
             return gallery.GetImageNames();
        }
    }
}