using ProyectoFinalDM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ProyectoFinalDM.Services.IService
{
   public interface ICategoriasService 
    {
        ObservableCollection<CategoriaModel> listarCategorias();
    }
}
