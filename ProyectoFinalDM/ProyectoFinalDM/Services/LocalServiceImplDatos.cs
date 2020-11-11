using ProyectoFinalDM.Models;
using ProyectoFinalDM.Services.IService;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ProyectoFinalDM.Services
{
    class LocalServiceImplDatos : ILocalesService
    {
        public ObservableCollection<LocalModel> locales { get; set; }
        public LocalServiceImplDatos()
        {
            locales = new ObservableCollection<LocalModel>();
            locales.Add(new LocalModel { CodLocal = 1, NombreLocal = "San Marino" });
            locales.Add(new LocalModel { CodLocal = 2, NombreLocal = "San Luis" });
            locales.Add(new LocalModel { CodLocal = 3, NombreLocal = "Scala" });
            locales.Add(new LocalModel { CodLocal = 4, NombreLocal = "Sol" });
            locales.Add(new LocalModel { CodLocal = 5, NombreLocal = "Ventura" });
            locales.Add(new LocalModel { CodLocal = 6, NombreLocal = "Quicentro" });
        }
        public ObservableCollection<LocalModel> listarLocales()
        {
            return locales;
        }
    }
}
