using ProyectoFinalDM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ProyectoFinalDM.Services.WSImplements
{
    public class StaticData
    {
        public static ObservableCollection<UsuarioModel> usuarios;
        public static ObservableCollection<ClienteModel> clientes;
        public static ObservableCollection<CategoriaModel> categorias;
        public static ObservableCollection<LocalModel> locales;
        public static ObservableCollection<String> prioridades;
        public static ObservableCollection<String> estados;
        public static UsuarioModel usuaroLogeado;
        public static String rutaImagenes = "http://alexmoyag-001-site1.ftempurl.com/api/";


    }
}
