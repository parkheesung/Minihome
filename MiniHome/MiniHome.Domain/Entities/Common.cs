using OctopusV3.Core;
using System;
using System.Data;
using System.Text;

namespace MiniHome.Domain
{
    public class Common : IEntity
    {
        [Entity("CommonSeq", SqlDbType.BigInt, 8)]
        public long CommonSeq { get; set; } = 0;

        [Entity("MajorCode", SqlDbType.VarChar, 30)]
        public string MajorCode { get; set; } = string.Empty;

        [Entity("MinorCode", SqlDbType.VarChar, 30)]
        public string MinorCode { get; set; } = string.Empty;

        [Entity("Code", SqlDbType.VarChar, 30)]
        public string Code { get; set; } = string.Empty;

        [Entity("MajorName", SqlDbType.NVarChar, 50)]
        public string MajorName { get; set; } = string.Empty;

        [Entity("MinorName", SqlDbType.NVarChar, 50)]
        public string MinorName { get; set; } = string.Empty;

        [Entity("Name", SqlDbType.NVarChar, 50)]
        public string Name { get; set; } = string.Empty;

        [Entity("IsEnabled", SqlDbType.Bit, 1)]
        public bool IsEnabled { get; set; } = true;

        [Entity("Level", SqlDbType.Int, 4)]
        public int Level { get; set; } = 0;


        public virtual string TableName { get { return "Common"; } set { } }
        public virtual string TargetColumn { get { return "CommonSeq"; } set { } }

        public Common()
        {
        }
    }
}


