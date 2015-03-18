using System;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using Models.ViewModels;
using Services.ApplicationSettingsService;

namespace Services.AdminLoginService.Implementation
{
    public class AdminLoginService : IAdminLoginService
    {
        private readonly string _login;
        private readonly string _password;

        public AdminLoginService(IApplicationSettingsService applicationSettingsService)
        {
            _login = applicationSettingsService.GetKey("adminLogin");
            _password = applicationSettingsService.GetKey("adminPassword");
        }


        public LoginViewModel Login(LoginViewModel loginViewModel)
        {
            if (String.Equals(loginViewModel.Login, _login) && String.Equals(loginViewModel.Password, _password))
            {
                loginViewModel.Authorized = true;
            }
            else
            {
                loginViewModel.Authorized = false;
            }

            return loginViewModel;
        }

        public void SetLoginCookies(string userName)
        {
            FormsAuthentication.SetAuthCookie(userName,false);
        }

        public void Logout()
        {
            FormsAuthentication.SignOut();
        }

        public HttpCookieCollection Cookies()
        {
            return HttpContext.Current.Response.Cookies;
        }
    }
}