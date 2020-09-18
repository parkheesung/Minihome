using MiniHome.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiniHome.WebUI
{
    public class MiniHomeController : DefaultController
    {
        public MiniHomeController(IMiniHomeRepository rep, IWebSite site) : base(rep, site)
        {
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            this.MySite.SetController(this);
            ViewBag.controller = this;
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
        }
    }
}