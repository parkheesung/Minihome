using OctopusV3.Core;
using System;
using System.Web.Mvc;

namespace MiniHome.Domain
{
    public interface IWebSite
    {
        void SetController(Controller controller);

        void CookieSet(string cookieName, string cookieValue);
        void CookieSet(string cookieName, string cookieValue, DateTime expiredDate);

        object CookieGet(string cookieName);

        void CookieErase(string cookieName);

        bool CookieExists(string cookieName);

        ReturnValue PasswordCheck(Member member, string Password);

        string CryptoDecrypt(string data);

        string CryptoEncrypt(string data);
    }
}
