using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JsonApi
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ScrumDoHelper obj = new ScrumDoHelper();

            Response.Write(obj.getStoriesInIteration(20948));
        }
    }
}