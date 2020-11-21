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
using ProyectoFinalDM.Droid;
using ProyectoFinalDM.SQLite;
using SQLite;
[assembly: Xamarin.Forms.Dependency(typeof(SQLiteClient))]
namespace ProyectoFinalDM.Droid
{
    class SQLiteClient: DataBase
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var document = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var parth = Path.Combine(document, ConnectionSQLite.nombreBaseDatos);
            return new SQLiteAsyncConnection(parth);
        }
    }
}