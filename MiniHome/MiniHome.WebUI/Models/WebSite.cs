using MiniHome.Domain;
using OctopusV3.Core;
using OctopusV3.Net.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiniHome.WebUI
{
    public class WebSite : IWebSite
    {
        public MiniHomeController controller { get; set; }

        public WebSite()
        {
            CryptoHelper.AES256.SecretKey = GlobalConfig.Secret;
        }

        public void SetController(Controller _controller)
        {
            this.controller = _controller as MiniHomeController;
        }

        public void CookieSet(string cookieName, string cookieValue)
        {
            CookieHelper.CookieSet(cookieName, cookieValue);
        }

        public void CookieSet(string cookieName, string cookieValue, DateTime expiredDate)
        {
            CookieHelper.CookieSet(cookieName, cookieValue, expiredDate);
        }

        public object CookieGet(string cookieName)
        {
            return CookieHelper.CookieGet(cookieName);
        }

        public void CookieErase(string cookieName)
        {
            CookieHelper.CookieRemove(cookieName);
        }

        public bool CookieExists(string cookieName)
        {
            return CookieHelper.CookieExists(cookieName);
        }

        public ReturnValue PasswordCheck(Member member, string Password)
        {
            var result = new ReturnValue();

            if (string.IsNullOrWhiteSpace(member.Password))
            {
                result.Success(member.MemberSeq, "Reset");
            }
            else if (string.IsNullOrWhiteSpace(Password))
            {
                result.Error("비밀번호를 입력하세요.");
            }
            else
            {
                if (member.IsCrypto)
                {
                    if (CryptoHelper.SHA512.ValidateCheck(member.Password, Password))
                    {
                        result.Success(member.MemberSeq);
                    }
                    else
                    {
                        result.Error("비밀번호가 일치하지 않습니다.");
                    }
                }
                else
                {
                    if (member.Password == Password)
                    {
                        result.Success(member.MemberSeq);
                    }
                    else
                    {
                        result.Error("비밀번호가 일치하지 않습니다.");
                    }
                }
            }

            return result;
        }

        public string CryptoDecrypt(string data)
        {
            return CryptoHelper.AES256.Decrypt(data);
        }

        public string CryptoEncrypt(string data)
        {
            return CryptoHelper.AES256.Encrypt(data);
        }
    }
}