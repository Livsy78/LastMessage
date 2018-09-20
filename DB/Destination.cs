using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Linq;
using System.Data.Linq.Mapping; // [Table(..)]

namespace LastMessage.DB
{
    [Table(Name = "Destination")]
    public class Destination : BaseTemplate<Destination>
    {
        [Column(IsPrimaryKey = true, CanBeNull = false, DbType = "int", IsDbGenerated = true)]
        public int ID { get; set; }

        [Column(IsPrimaryKey = false, CanBeNull = false, DbType = "varchar(16)", IsDbGenerated = false)]
        public DestinationtStatus Status { get; set; }

        [Column(IsPrimaryKey = false, CanBeNull = false, DbType = "int", IsDbGenerated = false)]
        public int RecipientID { get; set; }

        [Column(IsPrimaryKey = false, CanBeNull = false, DbType = "varchar(16)", IsDbGenerated = false)]
        public DestinationType Type { get; set; }

        [Column(IsPrimaryKey = false, CanBeNull = false, DbType = "nvarchar(64)", IsDbGenerated = false)]
        public string Address { get; set; }

    }

    public enum DestinationtStatus
    {
        ACTIVE,
        DISABLED,
    }

    public enum DestinationType // used .ToString() for showing to user
    {
        Email,
        SMS,
    }

}