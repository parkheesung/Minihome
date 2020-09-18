using OctopusV3.Core;
using System;
using System.Data;
using System.Text;

namespace MiniHome.Domain
{
    public class PartComment : IEntity
    {
        [Entity("PartCommentSeq", SqlDbType.BigInt, 8)]
        public long PartCommentSeq { get; set; } = 0;

        [Entity("RegistDate", SqlDbType.DateTime2, 8)]
        public DateTime RegistDate { get; set; }

        [Entity("AgendaValue", SqlDbType.VarChar, 30)]
        public string AgendaValue { get; set; } = string.Empty;

        [Entity("MemberSeq", SqlDbType.BigInt, 8)]
        public long MemberSeq { get; set; } = 0;

        [Entity("CommentSeq", SqlDbType.BigInt, 8)]
        public long CommentSeq { get; set; } = 0;


        public virtual string TableName { get { return "PartComment"; } set { } }
        public virtual string TargetColumn { get { return "PartCommentSeq"; } set { } }

        public PartComment()
        {
        }
    }
}


