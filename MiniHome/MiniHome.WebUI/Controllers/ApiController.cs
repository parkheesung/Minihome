using MiniHome.Domain;
using OctopusV3.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiniHome.WebUI
{
    public class ApiController : MiniHomeController
	{
        public ApiController(IMiniHomeRepository rep, IWebSite site) : base(rep, site)
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

		[Route("Api/BoardContent/Save")]
		public JsonResult ApiBoardContent_Save(BoardContent boardcontent)
		{
			var result = new ReturnValue();

			result = this.Repository.BoardContentSave(boardcontent);

			return Json(result);
		}

		[Route("Api/BoardMaster/Save")]
		public JsonResult ApiBoardMaster_Save(BoardMaster boardmaster)
		{
			var result = new ReturnValue();

			result = this.Repository.BoardMasterSave(boardmaster);

			return Json(result);
		}

		[Route("Api/Comment/Save")]
		public JsonResult ApiComment_Save(Comment comment)
		{
			var result = new ReturnValue();

			result = this.Repository.CommentSave(comment);

			return Json(result);
		}

		[Route("Api/Common/Save")]
		public JsonResult ApiCommon_Save(Common common)
		{
			var result = new ReturnValue();

			result = this.Repository.CommonSave(common);

			return Json(result);
		}

		[Route("Api/Member/Save")]
		public JsonResult ApiMember_Save(Member member)
		{
			var result = new ReturnValue();

			result = this.Repository.MemberSave(member);

			return Json(result);
		}

		[Route("Api/PartBoard/Save")]
		public JsonResult ApiPartBoard_Save(PartBoard partboard)
		{
			var result = new ReturnValue();

			result = this.Repository.PartBoardSave(partboard);

			return Json(result);
		}

		[Route("Api/PartComment/Save")]
		public JsonResult ApiPartComment_Save(PartComment partcomment)
		{
			var result = new ReturnValue();

			result = this.Repository.PartCommentSave(partcomment);

			return Json(result);
		}




	}
}