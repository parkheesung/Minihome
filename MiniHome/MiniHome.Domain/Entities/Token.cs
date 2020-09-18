using OctopusV3.Core;
using System;
using System.Data;
using System.Text;

namespace MiniHome.Domain
{
    public class Token : IEntity
    {
        [Entity("TokenKey", SqlDbType.Char, 36)]
        public string TokenKey { get; set; } = string.Empty;

        [Entity("RegistDate", SqlDbType.DateTime2, 8)]
        public DateTime RegistDate { get; set; }

        [Entity("ExpiredDate", SqlDbType.DateTime2, 8)]
        public DateTime ExpiredDate { get; set; }

        [Entity("IsEnabled", SqlDbType.Bit, 1)]
        public bool IsEnabled { get; set; } = true;

        [Entity("MemberSeq", SqlDbType.BigInt, 8)]
        public long MemberSeq { get; set; } = 0;


        public virtual string TableName { get { return "Token"; } set { } }
        public virtual string TargetColumn { get { return "TokenKey"; } set { } }

        public Token()
        {
        }
    }
}


