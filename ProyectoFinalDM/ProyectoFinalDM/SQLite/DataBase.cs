using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoFinalDM.SQLite
{
     public interface DataBase
    {
        SQLiteAsyncConnection GetConnection();
    }
}
