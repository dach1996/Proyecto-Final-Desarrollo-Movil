using ProyectoFinalDM.Models;
using ProyectoFinalDM.Services.IService;
using ProyectoFinalDM.Services.WSImplements;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalDM.Services
{
    class EstadoServiceImplDatos : IEstadosService
    {
        private ObservableCollection<String> estados;

        public EstadoServiceImplDatos()
        {
            estados = new ObservableCollection<String>();

        }

        public String buscarEstado(string estado)
        {
            return StaticData.estados.FirstOrDefault(e => e== estado) ;

        }

        public Task consultarEstados()
        {

            return Task.Run(() =>
            {
                estados.Add("Ingresado");
                estados.Add("En Proceso");
                estados.Add("Completo");
                StaticData.estados = estados;
            });


        }

        public ObservableCollection<String> listarEstados()
        {
            return StaticData.estados;
        }


    }
}
