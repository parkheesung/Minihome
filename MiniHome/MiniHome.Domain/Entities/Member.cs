using OctopusV3.Core;
using System;
using System.Data;
using System.Text;

namespace MiniHome.Domain
{
    public class Member : IEntity
    {
        [Entity("MemberSeq", SqlDbType.BigInt, 8)]
        public long MemberSeq { get; set; } = 0;

        [Entity("Email", SqlDbType.VarChar, 255)]
        public string Email { get; set; } = string.Empty;

        [Entity("Name", SqlDbType.NVarChar, 30)]
        public string Name { get; set; } = string.Empty;

        [Entity("NickName", SqlDbType.NVarChar, 50)]
        public string NickName { get; set; } = string.Empty;

        [Entity("Addr1", SqlDbType.NVarChar, 100)]
        public string Addr1 { get; set; } = string.Empty;

        [Entity("Addr2", SqlDbType.NVarChar, 100)]
        public string Addr2 { get; set; } = string.Empty;

        [Entity("RegistDate", SqlDbType.DateTime2, 8)]
        public DateTime RegistDate { get; set; }

        [Entity("LastUpdate", SqlDbType.DateTime2, 8)]
        public DateTime LastUpdate { get; set; }

        [Entity("LastLogin", SqlDbType.DateTime2, 8)]
        public DateTime LastLogin { get; set; }

        [Entity("Password", SqlDbType.VarChar, 512)]
        public string Password { get; set; } = string.Empty;

        [Entity("IsOut", SqlDbType.Bit, 1)]
        public bool IsOut { get; set; } = false;

        [Entity("IsMailCheck", SqlDbType.Bit, 1)]
        public bool IsMailCheck { get; set; } = false;

        [Entity("IsEnabled", SqlDbType.Bit, 1)]
        public bool IsEnabled { get; set; } = true;

        [Entity("UsingPoint", SqlDbType.Int, 4)]
        public int UsingPoint { get; set; } = 0;

        [Entity("UsedPoint", SqlDbType.Int, 4)]
        public int UsedPoint { get; set; } = 0;

        [Entity("Area", SqlDbType.NVarChar, 100)]
        public string Area { get; set; } = string.Empty;

        [Entity("UserType", SqlDbType.VarChar, 30)]
        public string UserType { get; set; } = string.Empty;

        [Entity("UserGrade", SqlDbType.VarChar, 30)]
        public string UserGrade { get; set; } = string.Empty;


        public virtual string TableName { get { return "Member"; } set { } }
        public virtual string TargetColumn { get { return "MemberSeq"; } set { } }

        public Member()
        {
        }
    }
}


