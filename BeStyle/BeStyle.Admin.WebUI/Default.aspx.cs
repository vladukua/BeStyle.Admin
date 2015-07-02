using System;
using System.Diagnostics;
using System.Web.Security;
using BeStyle.Admin.WebUI.Code.Roles;

namespace BeStyle.Admin.WebUI
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnSignOut_OnClick(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }
    }
}