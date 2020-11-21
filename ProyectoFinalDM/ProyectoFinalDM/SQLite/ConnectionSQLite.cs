using ProyectoFinalDM.Models.SQLite;
using ProyectoFinalDM.Services.Security;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProyectoFinalDM.SQLite
{
    public class ConnectionSQLite
    {
        private SQLiteAsyncConnection conn;
        public static string nombreBaseDatos = "Usuario.db3";
        private SQLiteConnection db;
        public ConnectionSQLite()
        {
            this.conn = DependencyService.Get<DataBase>().GetConnection();
            this.db = this.getDataBase();
        }
       
        public SQLiteConnection getDataBase()
        {
            var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), nombreBaseDatos);
            var db = new SQLiteConnection(databasePath);
            return db;
        }

        public void createTableUser()
        {
            this.db.CreateTable<UsuarioModelSQLite>();
        }

        public List<UsuarioModelSQLite> buscarUsuario()
        {
            try
            {
                return this.db.Query<UsuarioModelSQLite>("Select * From UsuarioModelSQLite");
            }
            catch (Exception)
            {
                return new List<UsuarioModelSQLite>();
            }
           
        }

        public async Task<int> registrarUsuario(string username, string password)
        {
            try
            {
                var usuarioSql = new UsuarioModelSQLite
                {
                    username = Encrypt.Encriptar(username),
                    password = Encrypt.Encriptar(password)
                };
           return await conn.InsertAsync(usuarioSql);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return 0;
        }
        public void eliminarUsuarios()
        {
            this.db.Query<UsuarioModelSQLite>("Delete From UsuarioModelSQLite");
        }


    }
}
