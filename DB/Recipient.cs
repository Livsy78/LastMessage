using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Linq;
using System.Data.Linq.Mapping; // [Table(..)]

namespace LastMessage.DB
{
    [Table(Name = "Recipient")]
    public class Recipient : BaseTemplate<Recipient>
    {
        [Column(IsPrimaryKey = true, CanBeNull = false, DbType = "int", IsDbGenerated = true)]
        public int ID { get; set; }

        [Column(IsPrimaryKey = false, CanBeNull = false, DbType = "varchar(16)", IsDbGenerated = false)]
        public RecipientStatus Status { get; set; }

        [Column(IsPrimaryKey = false, CanBeNull = false, DbType = "int", IsDbGenerated = false)]
        public int MessageID { get; set; }

        [Column(IsPrimaryKey = false, CanBeNull = false, DbType = "nvarchar(64)", IsDbGenerated = false)]
        public string Name { get; set; }

    }

    public enum RecipientStatus
    {
        ACTIVE,
        DISABLED,
    }

}