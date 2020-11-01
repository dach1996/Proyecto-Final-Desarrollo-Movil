﻿using System;
using System.Collections.Generic;
using System.Text;
using ProyectoFinalDM.Models;
using System.Collections.ObjectModel;

namespace ProyectoFinalDM.ViewModel
{
    class ClienteViewModel
    {
        private ObservableCollection<Cliente> clientes;

        public ClienteViewModel()
        {
            this.clientes = new ObservableCollection<Cliente>();
            clientes.Add(new Cliente
            {
                codCliente = 0,
                nombreCliente = "Crocs",
                imagenCliente = "https://es.shoppertrak.com/wp-content/uploads//2018/05/crocs-logo.jpg",
                userCliente = "",
                passwordCliente = ""
            });

            clientes.Add(new Cliente
            {
                codCliente = 1,
                nombreCliente = "Taty",
                imagenCliente = "https://www.taty.com.ec/wp-content/uploads/2020/05/taty-boutique-imagen-redes-sociales.png",
                userCliente = "",
                passwordCliente = ""
            });
            clientes.Add(new Cliente
            {
                codCliente = 2,
                nombreCliente = "Supermaxi",
                imagenCliente = "https://www.corporacionfavorita.com/wp-content/uploads/2020/03/cf-logos-supermaxi.jpg",
                userCliente = "",
                passwordCliente = ""
            });
        }

        public ObservableCollection<Cliente> Clientes { get => clientes; set => clientes = value; }
    }
}
