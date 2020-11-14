﻿using Newtonsoft.Json;
using ProyectoFinalDM.INotifyProperty;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoFinalDM.Models
{
    public class ClienteModel : Notificaciones

    {
        private int codCliente;


        [JsonProperty(PropertyName = "cod_cliente")]
        public int CodCliente
        {
            get { return codCliente; }
            set { codCliente = value; this.OnPropertyChanged(); }
        }

        private string nombreCliente;


        [JsonProperty(PropertyName = "nomb_cliente")]
        public string NombreCliente
        {
            get { return nombreCliente; }
            set { nombreCliente = value; this.OnPropertyChanged(); }
        }

        private string imagenCliente;


        [JsonProperty(PropertyName = "image_cliente")]
        public string ImagenCliente
        {
            get { return imagenCliente; }
            set { imagenCliente = value; this.OnPropertyChanged(); }
        }

        private string userCliente;


        [JsonProperty(PropertyName = "usu_cliente")]
        public string UserCliente
        {
            get { return userCliente; }
            set { userCliente = value; this.OnPropertyChanged(); }
        }

        private string passwordCliente;


        [JsonProperty(PropertyName = "pass_cliente")]
        public string PasswordCliente
        {
            get { return passwordCliente; }
            set { passwordCliente = value; this.OnPropertyChanged(); }
        }


        public override bool Equals(object obj)
        {
            return obj is ClienteModel model &&
                   codCliente == model.codCliente &&
                   CodCliente == model.CodCliente &&
                   nombreCliente == model.nombreCliente &&
                   NombreCliente == model.NombreCliente &&
                   imagenCliente == model.imagenCliente &&
                   ImagenCliente == model.ImagenCliente &&
                   userCliente == model.userCliente &&
                   UserCliente == model.UserCliente &&
                   passwordCliente == model.passwordCliente &&
                   PasswordCliente == model.PasswordCliente;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
