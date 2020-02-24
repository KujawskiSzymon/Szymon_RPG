using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Szymon_RPG.Data;
using Szymon_RPG.Droid.Data;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLlite_Android))]

namespace Szymon_RPG.Droid.Data
{
    class SQLlite_Android : ISQLlite
    {
        public SQLlite_Android() { }
        public SQLite.SQLiteConnection GetConnection()
        {
            var sqlliteFileName = "TestDB.db3";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, sqlliteFileName);
            var conn = new SQLite.SQLiteConnection(path);
            return conn;
        }
    }
}