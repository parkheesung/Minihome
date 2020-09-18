using OctopusV3.Core;
using System;
using System.Data;
using System.Text;

namespace MiniHome.Domain
{
    public class Comment : IEntity
    {
        [Entity("CommentSeq", SqlDbType.BigInt, 8)]
        public long CommentSeq { get; set; } = 0;

        [Entity("Content", SqlDbType.NVarChar, 0)]
        public string Content { get; set; } = string.Empty;

        [Entity("MemberSeq", SqlDbType.BigInt, 8)]
        public long MemberSeq { get; set; } = 0;

        [Entity("URL", SqlDbType.VarChar, 255)]
        public string URL { get; set; } = string.Empty;

        [Entity("LikeCount", SqlDbType.Int, 4)]
        public int LikeCount { get; set; } = 0;

        [Entity("UnLikeCount", SqlDbType.Int, 4)]
        public int UnLikeCount { get; set; } = 0;

        [Entity("RegistDate", SqlDbType.DateTime2, 8)]
        public DateTime RegistDate { get; set; }

        [Entity("LastUpdate", SqlDbType.DateTime2, 8)]
        public DateTime LastUpdate { get; set; }

        [Entity("IsEnabled", SqlDbType.Bit, 1)]
        public bool IsEnabled { get; set; } = true;


        public virtual string TableName { get { return "Comment"; } set { } }
        public virtual string TargetColumn { get { return "CommentSeq"; } set { } }

        public Comment()
        {
        }
    }
}


