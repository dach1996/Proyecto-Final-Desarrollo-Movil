using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoFinalDM.Models.SQLite
{
    public class UsuarioModelSQLite
    {
        [PrimaryKey, AutoIncrement]
        public int codUsuario { get; set; }
        public String  username { get; set; }
        public String  password { get; set; }
    }
}
