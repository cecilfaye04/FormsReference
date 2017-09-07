using SQLite;
using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace XamarinRFID
{
    [Table("Login")]
    public class Login
    {
        [PrimaryKey, AutoIncrement]
        public int DatabaseId { get; set; }


        public bool IsLoggedIn{ get; set; }
    }
}
