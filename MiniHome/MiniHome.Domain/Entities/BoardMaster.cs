using OctopusV3.Core;
using System;
using System.Data;
using System.Text;

namespace MiniHome.Domain
{
    public class BoardMaster : IEntity
    {
        [Entity("BoardMasterSeq", SqlDbType.BigInt, 8)]
        public long BoardMasterSeq { get; set; } = 0;

        [Entity("Title", SqlDbType.NVarChar, 100)]
        public string Title { get; set; } = string.Empty;

        [Entity("Code", SqlDbType.VarChar, 30)]
        public string Code { get; set; } = string.Empty;

        [Entity("RegistDate", SqlDbType.DateTime2, 8)]
        public DateTime RegistDate { get; set; }

        [Entity("LastUpdate", SqlDbType.DateTime2, 8)]
        public DateTime LastUpdate { get; set; }

        [Entity("IsEnabled", SqlDbType.Bit, 1)]
        public bool IsEnabled { get; set; } = true;

        [Entity("Category_A", SqlDbType.VarChar, 30)]
        public string Category_A { get; set; } = string.Empty;

        [Entity("Category_B", SqlDbType.VarChar, 30)]
        public string Category_B { get; set; } = string.Empty;

        [Entity("Category_C", SqlDbType.VarChar, 30)]
        public string Category_C { get; set; } = string.Empty;

        [Entity("BoardType", SqlDbType.VarChar, 30)]
        public string BoardType { get; set; } = string.Empty;


        public virtual string TableName { get { return "BoardMaster"; } set { } }
        public virtual string TargetColumn { get { return "BoardMasterSeq"; } set { } }

        public BoardMaster()
        {
        }
    }
}


