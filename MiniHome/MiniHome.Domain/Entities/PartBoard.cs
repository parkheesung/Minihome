using OctopusV3.Core;
using System;
using System.Data;
using System.Text;

namespace MiniHome.Domain
{
    public class PartBoard : IEntity
    {
        [Entity("PartBoardSeq", SqlDbType.BigInt, 8)]
        public long PartBoardSeq { get; set; } = 0;

        [Entity("BoardContentSeq", SqlDbType.BigInt, 8)]
        public long BoardContentSeq { get; set; } = 0;

        [Entity("BoardMasterSeq", SqlDbType.BigInt, 8)]
        public long BoardMasterSeq { get; set; } = 0;

        [Entity("MemberSeq", SqlDbType.BigInt, 8)]
        public long MemberSeq { get; set; } = 0;

        [Entity("RegistDate", SqlDbType.DateTime2, 8)]
        public DateTime RegistDate { get; set; }

        [Entity("AgendaValue", SqlDbType.VarChar, 30)]
        public string AgendaValue { get; set; } = string.Empty;


        public virtual string TableName { get { return "PartBoard"; } set { } }
        public virtual string TargetColumn { get { return "PartBoardSeq"; } set { } }

        public PartBoard()
        {
        }
    }
}


