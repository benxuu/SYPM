using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MesserRDLC
{
    public partial class index : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblang.Text = Profile.MyCultrue.ToLower();
        }
    }
}