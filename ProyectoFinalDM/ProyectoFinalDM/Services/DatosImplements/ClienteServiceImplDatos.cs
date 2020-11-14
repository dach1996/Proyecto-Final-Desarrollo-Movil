using ProyectoFinalDM.Models;
using ProyectoFinalDM.Services.IService;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace ProyectoFinalDM.Services
{
    public class ClienteServiceImplDatos 
    {
        private ObservableCollection<ClienteModel> clientes;
        public ClienteServiceImplDatos()
        {
            clientes = new ObservableCollection<ClienteModel>();

            clientes.Add(new ClienteModel
            {
                CodCliente = 0,
                NombreCliente = "Crocs",
                ImagenCliente = "https://es.shoppertrak.com/wp-content/uploads//2018/05/crocs-logo.jpg",
                UserCliente = "",
                PasswordCliente = ""
            });

            clientes.Add(new ClienteModel
            {
                CodCliente = 1,
                NombreCliente = "Taty",
                ImagenCliente = "https://www.taty.com.ec/wp-content/uploads/2020/05/taty-boutique-imagen-redes-sociales.png",
                UserCliente = "",
                PasswordCliente = ""
            });
            clientes.Add(new ClienteModel
            {
                CodCliente = 2,
                NombreCliente = "Supermaxi",
                ImagenCliente = "https://www.corporacionfavorita.com/wp-content/uploads/2020/03/cf-logos-supermaxi.jpg",
                UserCliente = "",
                PasswordCliente = ""
            });
        }
        public ObservableCollection<ClienteModel> listarClientes()
        {
            return clientes;
        }

        public ClienteModel buscarCliente(int codCliente)
        {
            return clientes.FirstOrDefault(c => c.CodCliente==codCliente);
        }
    }
}
