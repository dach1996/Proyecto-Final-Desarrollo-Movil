using ProyectoFinalDM.Models;
using ProyectoFinalDM.Services.IService;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ProyectoFinalDM.Services
{
    class PrioridadServiceImplDatos : IPrioridadService
    {
        private ObservableCollection<PrioridadModel> prioridades;

        public PrioridadServiceImplDatos()
        {
            prioridades = new ObservableCollection<PrioridadModel>();
            prioridades.Add(new PrioridadModel { CodPrioridad = 1, NombrePrioridad = "INGRESADO" });
            prioridades.Add(new PrioridadModel { CodPrioridad = 2, NombrePrioridad = "EN PROCESO" });
            prioridades.Add(new PrioridadModel { CodPrioridad = 3, NombrePrioridad = "COMPLETADO" });
        }
        public ObservableCollection<PrioridadModel> listarPrioridades()
        {
            return prioridades;
        }
    }
}
