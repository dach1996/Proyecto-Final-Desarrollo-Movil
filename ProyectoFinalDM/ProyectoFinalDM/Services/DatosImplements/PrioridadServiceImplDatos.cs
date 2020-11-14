using ProyectoFinalDM.Models;
using ProyectoFinalDM.Services.IService;
using ProyectoFinalDM.Services.WSImplements;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinalDM.Services
{
    public class PrioridadServiceImplDatos : IPrioridadService
    {
        private ObservableCollection<String> prioridades;

        public PrioridadServiceImplDatos()
        {
            prioridades = new ObservableCollection<String>();
       
        }

        public String buscarPrioridad(string prioridad)
        {
            return StaticData.prioridades.FirstOrDefault(p=>p==prioridad);

        }

        public Task consultarPrioridades()
        {
            return Task.Run(() =>
            {
                prioridades.Add( "Alta" );
                prioridades.Add( "Media" );
                prioridades.Add( "Baja" );
                StaticData.prioridades = prioridades;
            });
            
        }

        public ObservableCollection<String> listarPrioridades()
        {
            return StaticData.prioridades;
        }
    }
}
