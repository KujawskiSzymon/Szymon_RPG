using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Szymon_RPG.Data
{
   public interface ISQLlite
    {
        SQLiteConnection GetConnection();
    }
}
