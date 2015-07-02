using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using BeStyle.Admin.WebUI.Code.Roles;

namespace BeStyle.Admin.WebUI.Pages
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var isAuthenticated = (User != null) && User.Identity.IsAuthenticated;
            /*
            if (isAuthenticated)
            {
                FormsAuthentication.RedirectFromLoginPage(User.Identity.Name, true);
            }
            */
        }

        protected void lgnLogin_OnLoggingIn(object sender, LoginCancelEventArgs e)
        {
            FormsAuthentication.Initialize();
            if (!IsValidInput())
            {
                return;
            }

            var userName = "volodia";
            var password = "volodia";

            if (lgnLogin.UserName == userName && lgnLogin.Password == password)
            {
                FormsAuthenticationUtil.RedirectFromLoginPage(lgnLogin.UserName, AdminRoles.Master, true);
                // FormsAuthentication.RedirectFromLoginPage(lgnLogin.UserName, true);
            }
        }

        private bool IsValidInput()
        {
            const string userNamePattern = @"[\w]{5,}";
            const string emailPattern = @"[a-z0-9_-]+@[a-z0-9_-]+(\.[a-z0-9_-]+)*\.[a-z]{2,6}$";
            const string passwordPattern = @"[\w./()@=\-?\*,]{5,}";
            var regUserName = new Regex(userNamePattern);
            var regEmail = new Regex(emailPattern);
            var regPassword = new Regex(passwordPattern);
            if (!regUserName.IsMatch(lgnLogin.UserName) && !regEmail.IsMatch(lgnLogin.UserName))
            {
                return false;
            }
            if (!regPassword.IsMatch(lgnLogin.Password))
            {
                return false;
            }

            return true;
        }
    }
}