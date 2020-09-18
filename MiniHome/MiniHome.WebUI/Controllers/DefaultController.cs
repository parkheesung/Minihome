using MiniHome.Domain;
using OctopusV3.Net.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiniHome.WebUI
{
    public class DefaultController : BaseController
    {
        protected IMiniHomeRepository Repository { get; set; }

        public IWebSite MySite { get; set; }

        public DefaultController(IMiniHomeRepository rep, IWebSite site) : base()
        {
            this.Repository = rep;
            this.MySite = site;
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            this.Repository.Open(GlobalConfig.Current.ConnectionString);
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
            this.Repository.Close();
        }
    }
}