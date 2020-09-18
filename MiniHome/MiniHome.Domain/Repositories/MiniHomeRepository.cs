using System;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;
using OctopusV3.Core;
using OctopusV3.Data;

namespace MiniHome.Domain
{
	public class MiniHomeRepository : DefaultRepository, IMiniHomeRepository
	{
		public MiniHomeRepository() : base()
		{
		}

		public ReturnValue BoardContentSave(BoardContent boardcontent)
		{
			var result = new ReturnValue();

			try
			{
				using (var cmd = new SqlCommand("ESP_BoardContent_Save", this.SqlConn))
				{
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.AddParameterInput("@BoardMasterSeq", System.Data.SqlDbType.BigInt, boardcontent.BoardMasterSeq, 8);
					cmd.AddParameterInput("@Title", System.Data.SqlDbType.NVarChar, boardcontent.Title, 200);
					cmd.AddParameterInput("@Content", System.Data.SqlDbType.NVarChar, boardcontent.Content, -1);
					cmd.AddParameterInput("@LikeCount", System.Data.SqlDbType.Int, boardcontent.LikeCount, 4);
					cmd.AddParameterInput("@UnLikeCount", System.Data.SqlDbType.Int, boardcontent.UnLikeCount, 4);
					cmd.AddParameterInput("@ViewCount", System.Data.SqlDbType.Int, boardcontent.ViewCount, 4);
					cmd.AddParameterInput("@ShareCount", System.Data.SqlDbType.Int, boardcontent.ShareCount, 4);
					cmd.AddParameterInput("@MemberSeq", System.Data.SqlDbType.BigInt, boardcontent.MemberSeq, 8);
					cmd.AddParameterInput("@BoardContentSeq", System.Data.SqlDbType.BigInt, boardcontent.BoardContentSeq, 8);
					result = cmd.ExecuteReturnValue();
				}
			}
			catch (Exception ex)
			{
				if (this.Logger != null) this.Logger.Error(ex);
				result.Error(ex);
			}

			return result;
		}

		public ReturnValue BoardMasterSave(BoardMaster boardmaster)
		{
			var result = new ReturnValue();

			try
			{
				using (var cmd = new SqlCommand("ESP_BoardMaster_Save", this.SqlConn))
				{
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.AddParameterInput("@Title", System.Data.SqlDbType.NVarChar, boardmaster.Title, 200);
					cmd.AddParameterInput("@BdsCode", System.Data.SqlDbType.VarChar, boardmaster.Code, 30);
					cmd.AddParameterInput("@BoardType", System.Data.SqlDbType.VarChar, boardmaster.BoardType, 30);
					cmd.AddParameterInput("@Category_A", System.Data.SqlDbType.VarChar, boardmaster.Category_A, 30);
					cmd.AddParameterInput("@Category_B", System.Data.SqlDbType.VarChar, boardmaster.Category_B, 30);
					cmd.AddParameterInput("@Category_C", System.Data.SqlDbType.VarChar, boardmaster.Category_C, 30);
					cmd.AddParameterInput("@BoardMasterSeq", System.Data.SqlDbType.BigInt, boardmaster.BoardMasterSeq, 8);
					result = cmd.ExecuteReturnValue();
				}
			}
			catch (Exception ex)
			{
				if (this.Logger != null) this.Logger.Error(ex);
				result.Error(ex);
			}

			return result;
		}

		public ReturnValue CommentSave(Comment comment)
		{
			var result = new ReturnValue();

			try
			{
				using (var cmd = new SqlCommand("ESP_Comment_Save", this.SqlConn))
				{
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.AddParameterInput("@MemberSeq", System.Data.SqlDbType.BigInt, comment.MemberSeq, 8);
					cmd.AddParameterInput("@Content", System.Data.SqlDbType.NVarChar, comment.Content, -1);
					cmd.AddParameterInput("@URL", System.Data.SqlDbType.VarChar, comment.URL, 255);
					cmd.AddParameterInput("@LikeCount", System.Data.SqlDbType.Int, comment.LikeCount, 4);
					cmd.AddParameterInput("@UnLikeCount", System.Data.SqlDbType.Int, comment.UnLikeCount, 4);
					cmd.AddParameterInput("@CommentSeq", System.Data.SqlDbType.BigInt, comment.CommentSeq, 8);
					result = cmd.ExecuteReturnValue();
				}
			}
			catch (Exception ex)
			{
				if (this.Logger != null) this.Logger.Error(ex);
				result.Error(ex);
			}

			return result;
		}

		public ReturnValue CommonSave(Common common)
		{
			var result = new ReturnValue();

			try
			{
				using (var cmd = new SqlCommand("ESP_Common_Save", this.SqlConn))
				{
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.AddParameterInput("@MajorCode", System.Data.SqlDbType.VarChar, common.MajorCode, 30);
					cmd.AddParameterInput("@MinorCode", System.Data.SqlDbType.VarChar, common.MinorCode, 30);
					cmd.AddParameterInput("@CommonCode", System.Data.SqlDbType.VarChar, common.Code, 30);
					cmd.AddParameterInput("@Name", System.Data.SqlDbType.NVarChar, common.Name, 100);
					cmd.AddParameterInput("@Level", System.Data.SqlDbType.Int, common.Level, 4);
					cmd.AddParameterInput("@MajorName", System.Data.SqlDbType.NVarChar, common.MajorName, 100);
					cmd.AddParameterInput("@MinorName", System.Data.SqlDbType.NVarChar, common.MinorName, 100);
					cmd.AddParameterInput("@CommonSeq", System.Data.SqlDbType.BigInt, common.CommonSeq, 8);
					result = cmd.ExecuteReturnValue();
				}
			}
			catch (Exception ex)
			{
				if (this.Logger != null) this.Logger.Error(ex);
				result.Error(ex);
			}

			return result;
		}

		public ReturnValue MemberSave(Member member)
		{
			var result = new ReturnValue();

			try
			{
				using (var cmd = new SqlCommand("ESP_Member_Save", this.SqlConn))
				{
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.AddParameterInput("@Email", System.Data.SqlDbType.VarChar, member.Email, 255);
					cmd.AddParameterInput("@Name", System.Data.SqlDbType.NVarChar, member.Name, 60);
					cmd.AddParameterInput("@NickName", System.Data.SqlDbType.NVarChar, member.NickName, 100);
					cmd.AddParameterInput("@Password", System.Data.SqlDbType.VarChar, member.Password, 512);
					cmd.AddParameterInput("@IsOut", System.Data.SqlDbType.Bit, member.IsOut, 1);
					cmd.AddParameterInput("@IsMailCheck", System.Data.SqlDbType.Bit, member.IsMailCheck, 1);
					cmd.AddParameterInput("@UsingPoint", System.Data.SqlDbType.Int, member.UsingPoint, 4);
					cmd.AddParameterInput("@UsedPoint", System.Data.SqlDbType.Int, member.UsedPoint, 4);
					cmd.AddParameterInput("@Area", System.Data.SqlDbType.NVarChar, member.Area, 200);
					cmd.AddParameterInput("@UserType", System.Data.SqlDbType.VarChar, member.UserType, 30);
					cmd.AddParameterInput("@UserGrade", System.Data.SqlDbType.VarChar, member.UserGrade, 30);
					cmd.AddParameterInput("@Addr1", System.Data.SqlDbType.NVarChar, member.Addr1, 200);
					cmd.AddParameterInput("@Addr2", System.Data.SqlDbType.NVarChar, member.Addr2, 200);
					cmd.AddParameterInput("@MemberSeq", System.Data.SqlDbType.BigInt, member.MemberSeq, 8);
					result = cmd.ExecuteReturnValue();
				}
			}
			catch (Exception ex)
			{
				if (this.Logger != null) this.Logger.Error(ex);
				result.Error(ex);
			}

			return result;
		}

		public ReturnValue PartBoardSave(PartBoard partboard)
		{
			var result = new ReturnValue();

			try
			{
				using (var cmd = new SqlCommand("ESP_PartBoard_Save", this.SqlConn))
				{
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.AddParameterInput("@AgendaValue", System.Data.SqlDbType.VarChar, partboard.AgendaValue, 30);
					cmd.AddParameterInput("@BoardContentSeq", System.Data.SqlDbType.BigInt, partboard.BoardContentSeq, 8);
					cmd.AddParameterInput("@BoardMasterSeq", System.Data.SqlDbType.BigInt, partboard.BoardMasterSeq, 8);
					cmd.AddParameterInput("@MemberSeq", System.Data.SqlDbType.BigInt, partboard.MemberSeq, 8);
					cmd.AddParameterInput("@PartBoardSeq", System.Data.SqlDbType.BigInt, partboard.PartBoardSeq, 8);
					result = cmd.ExecuteReturnValue();
				}
			}
			catch (Exception ex)
			{
				if (this.Logger != null) this.Logger.Error(ex);
				result.Error(ex);
			}

			return result;
		}

		public ReturnValue PartCommentSave(PartComment partcomment)
		{
			var result = new ReturnValue();

			try
			{
				using (var cmd = new SqlCommand("ESP_PartComment_Save", this.SqlConn))
				{
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.AddParameterInput("@AgendaValue", System.Data.SqlDbType.VarChar, partcomment.AgendaValue, 30);
					cmd.AddParameterInput("@MemberSeq", System.Data.SqlDbType.BigInt, partcomment.MemberSeq, 8);
					cmd.AddParameterInput("@CommentSeq", System.Data.SqlDbType.BigInt, partcomment.CommentSeq, 8);
					cmd.AddParameterInput("@PartCommentSeq", System.Data.SqlDbType.BigInt, partcomment.PartCommentSeq, 8);
					result = cmd.ExecuteReturnValue();
				}
			}
			catch (Exception ex)
			{
				if (this.Logger != null) this.Logger.Error(ex);
				result.Error(ex);
			}

			return result;
		}
	}
}

