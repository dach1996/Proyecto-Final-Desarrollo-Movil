using ProyectoFinalDM.Models;
using ProyectoFinalDM.Services.IService;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace ProyectoFinalDM.Services
{
    public class DetalleServiceImplDatos : IDetallesService
    {
        public static ObservableCollection<DetalleModel> detalles { get; set; }


        public DetalleServiceImplDatos()
        {
            detalles = new ObservableCollection<DetalleModel>();
            detalles.Add(new DetalleModel { CodDetalle = 1, CodUsuario = 1, FechaDetalle = DateTime.Now, TextoDetalle = "Prueba" });
            detalles.Add(new DetalleModel { CodDetalle = 2, CodUsuario = 1, FechaDetalle = DateTime.Now, TextoDetalle = "Prueba" });
            detalles.Add(new DetalleModel { CodDetalle = 3, CodUsuario = 1, FechaDetalle = DateTime.Now, TextoDetalle = "Prueba" });
            detalles.Add(new DetalleModel { CodDetalle = 4, CodUsuario = 1, FechaDetalle = DateTime.Now, TextoDetalle = "Prueba" });
            detalles.Add(new DetalleModel { CodDetalle = 5, CodUsuario = 1, FechaDetalle = DateTime.Now, TextoDetalle = "Prueba" });

        }
        public void editarDetalle(DetalleModel detalle)
        {
            for (int i = 0; i < detalles.Count; i++)
            {
                if (detalles[i].CodDetalle == detalle.CodDetalle)
                {
                    detalles[i] = detalle;
                }
            }

        }

        public void eliminarDetalle(int codDetalle)
        {
            detalles.ForEach(d =>
            {
                if (d.CodDetalle == codDetalle)
                {
                    detalles.Remove(d);
                }
            }
            );
        }

        public ObservableCollection<DetalleModel> listarDetalles()
        {
            return detalles;
        }

        public void nuevoDetalles(DetalleModel detalle)
        {
            detalles.Add(detalle);
        }
    }
}
