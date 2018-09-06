using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Linq;
using System.Data.Linq.Mapping; // [Table(..)]

namespace LastMessage.DB
{
    [Table(Name = "Log")]
    public class Log : BaseTemplate<Log>
    {
        [Column(IsPrimaryKey = true, CanBeNull = false, DbType = "int", IsDbGenerated = true)]
        public int ID { get; set; }

        [Column(IsPrimaryKey = false, CanBeNull = false, DbType = "int", IsDbGenerated = false)]
        public int UserID { get; set; }

        [Column(IsPrimaryKey = false, CanBeNull = false, DbType = "datetime", IsDbGenerated = false)]
        public DateTime Time { get; set; }

        [Column(IsPrimaryKey = false, CanBeNull = false, DbType = "varchar(32)", IsDbGenerated = false)]
        public LogType Type { get; set; }

        [Column(IsPrimaryKey = false, CanBeNull = false, DbType = "nvarchar(MAX)", IsDbGenerated = false)]
        public string Text { get; set; }

        [Column(IsPrimaryKey = false, CanBeNull = true, DbType = "int", IsDbGenerated = false)]
        public int? EntityID { get; set; }

    }

    public enum LogType 
    {
        ERROR,
    }


}