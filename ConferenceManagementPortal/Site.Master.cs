﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConferenceManagementPortal
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/adminlogin.aspx");
        }

        protected void LinkButton11_Click(object sender, EventArgs e)
        {

        }

        protected void LinkButton8_Click(object sender, EventArgs e)
        {

        }

        protected void LinkButton9_Click(object sender, EventArgs e)
        {

        }

        protected void LinkButton10_Click(object sender, EventArgs e)
        {
            //redirects
            Response.Redirect("~/adminmembermanagement.aspx");
        }

        protected void LinkButton12_Click(object sender, EventArgs e)
        {

        }
    }
}