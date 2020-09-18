using MiniHome.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiniHome.WebUI
{
    public class MemberController : MiniHomeController
    {
        public MemberController(IMiniHomeRepository rep, IWebSite site) : base(rep, site)
        {
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
        }

        public ActionResult Index()
        {
            return RedirectToAction("Login");
        }

        public ActionResult Login(string BackURL = "")
        {
            return View(this);
        }
    }
}