using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Linq;
using System.Data.Linq.Mapping; // [Table(..)]

namespace LastMessage.DB
{
    [Table(Name = "Message")]
    public class Message : BaseTemplate<Message>
    {
        [Column(IsPrimaryKey = true, CanBeNull = false, DbType = "int", IsDbGenerated = true)]
        public int ID { get; set; }

        [Column(IsPrimaryKey = false, CanBeNull = false, DbType = "varchar(16)", IsDbGenerated = false)]
        public MessageStatus Status { get; set; }

        [Column(IsPrimaryKey = false, CanBeNull = false, DbType = "int", IsDbGenerated = false)]
        public int UserID { get; set; }
        
        [Column(IsPrimaryKey = false, CanBeNull = false, DbType = "datetime", IsDbGenerated = false)]
        public DateTime TimeToSend { get; set; }
        
        [Column(IsPrimaryKey = false, CanBeNull = false, DbType = "nvarchar(64)", IsDbGenerated = false)]
        public string Title { get; set; }

        [Column(IsPrimaryKey = false, CanBeNull = false, DbType = "nvarchar(MAX)", IsDbGenerated = false)]
        public string  Text { get; set; }
    }

    public enum MessageStatus
    {
        ACTIVE,
        DISABLED,
        SENT,
    }

}