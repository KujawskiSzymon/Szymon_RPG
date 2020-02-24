using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Szymon_RPG.Models
{
   public class Token
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string AccessToken { get; set; }
        public string ErrorDesc { get; set; }
        public DateTime ExpireDate { get; set; }
        public int expire_in { get; set; }

        public Token() { }
        
    }
}
