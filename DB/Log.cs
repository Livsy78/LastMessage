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
        private DateTime Time { get; set; }


        // fill manually
        [Column(IsPrimaryKey = false, CanBeNull = false, DbType = "varchar(32)", IsDbGenerated = false)]
        public LogType Type { get; set; }

        [Column(IsPrimaryKey = false, CanBeNull = false, DbType = "nvarchar(MAX)", IsDbGenerated = false)]
        public string Text { get; set; }

        [Column(IsPrimaryKey = false, CanBeNull = true, DbType = "int", IsDbGenerated = false)]
        public int? EntityID { get; set; }

        [Column(IsPrimaryKey = false, CanBeNull = true, DbType = "varchar(16)", IsDbGenerated = false)]
        public LogEntityType? EntityType { get; set; }

    
        public static void Add(Log log)
        {
            log.ID = -1;

            log.UserID = 
                log.UserID == default(int) ?
                (
                    log.UserID = HttpContext.Current.User.Identity.IsAuthenticated ? 
                        DB.User.GetByFieldValue("Email", HttpContext.Current.User.Identity.Name).ID
                        : 
                        -1
                )
                :
                log.UserID
            ;
            
            log.Time = DateTime.Now;

            log.Save();
        }

    }

    public enum LogType 
    {
        ERROR,
        WARNING,
        REGISTER_USER,
        SAVE_MESSAGE,
        SEND_MESSAGE,

    }

    public enum LogEntityType
    {
        Message,
    }

}