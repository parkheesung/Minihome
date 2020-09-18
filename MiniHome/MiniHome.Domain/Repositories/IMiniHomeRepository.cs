using System;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;
using OctopusV3.Core;
using OctopusV3.Data;

namespace MiniHome.Domain
{
	public interface IMiniHomeRepository : IDefaultRepository
	{

		ReturnValue BoardContentSave(BoardContent boardcontent);

		ReturnValue BoardMasterSave(BoardMaster boardmaster);

		ReturnValue CommentSave(Comment comment);

		ReturnValue CommonSave(Common common);

		ReturnValue MemberSave(Member member);

		ReturnValue PartBoardSave(PartBoard partboard);

		ReturnValue PartCommentSave(PartComment partcomment);
	}
}

