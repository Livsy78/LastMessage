using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Linq;
using System.Data.Linq.Mapping; // [Table(..)]

namespace LastMessage.DB
{
    [Table(Name = "User")]
    public class User : BaseTemplate<User>
    {
        [Column(IsPrimaryKey = true, CanBeNull = false, DbType = "int", IsDbGenerated = true)]
        public int ID { get; set; }

        [Column(IsPrimaryKey = false, CanBeNull = false, DbType = "varchar(16)", IsDbGenerated = false)]
        public UserStatus Status { get; set; }

        [Column(IsPrimaryKey = false, CanBeNull = false, DbType = "varchar(64)", IsDbGenerated = false)]
        public string Email { get; set; }

        [Column(IsPrimaryKey = false, CanBeNull = false, DbType = "nvarchar(32)", IsDbGenerated = false)]
        public string Password { get; set; }
        
        [Column(IsPrimaryKey = false, CanBeNull = false, DbType = "nvarchar(128)", IsDbGenerated = false)]
        public string Name { get; set; }

    }


    public enum UserStatus
    {
        ADMIN,
        VIP,
        ACTIVE,
        PREMIUM,
        DISABLED,
    }

}