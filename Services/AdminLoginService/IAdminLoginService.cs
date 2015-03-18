using System.Web;
using Models.ViewModels;

namespace Services.AdminLoginService
{
    public interface IAdminLoginService
    {
        LoginViewModel Login(LoginViewModel loginViewModel);
        void SetLoginCookies(string userName);
        void Logout();
        HttpCookieCollection Cookies();
    }
}