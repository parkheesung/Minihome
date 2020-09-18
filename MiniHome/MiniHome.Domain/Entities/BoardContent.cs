using OctopusV3.Core;
using System;
using System.Data;
using System.Text;

namespace MiniHome.Domain
{
    public class BoardContent : IEntity
    {
        [Entity("BoardContentSeq", SqlDbType.BigInt, 8)]
        public long BoardContentSeq { get; set; } = 0;

        [Entity("BoardMasterSeq", SqlDbType.BigInt, 8)]
        public long BoardMasterSeq { get; set; } = 0;

        [Entity("Title", SqlDbType.NVarChar, 100)]
        public string Title { get; set; } = string.Empty;

        [Entity("Content", SqlDbType.NVarChar, 0)]
        public string Content { get; set; } = string.Empty;

        [Entity("MemberSeq", SqlDbType.BigInt, 8)]
        public long MemberSeq { get; set; } = 0;

        [Entity("RegistDate", SqlDbType.DateTime2, 8)]
        public DateTime RegistDate { get; set; }

        [Entity("LastUpdate", SqlDbType.DateTime2, 8)]
        public DateTime LastUpdate { get; set; }

        [Entity("IsEnabled", SqlDbType.Bit, 1)]
        public bool IsEnabled { get; set; } = true;

        [Entity("LikeCount", SqlDbType.Int, 4)]
        public int LikeCount { get; set; } = 0;

        [Entity("UnLikeCount", SqlDbType.Int, 4)]
        public int UnLikeCount { get; set; } = 0;

        [Entity("ViewCount", SqlDbType.Int, 4)]
        public int ViewCount { get; set; } = 0;

        [Entity("ShareCount", SqlDbType.Int, 4)]
        public int ShareCount { get; set; } = 0;


        public virtual string TableName { get { return "BoardContent"; } set { } }
        public virtual string TargetColumn { get { return "BoardContentSeq"; } set { } }

        public BoardContent()
        {
        }
    }
}


