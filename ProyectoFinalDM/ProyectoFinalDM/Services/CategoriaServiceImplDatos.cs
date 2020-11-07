using ProyectoFinalDM.Models;
using ProyectoFinalDM.Services.IService;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ProyectoFinalDM.Services
{
    public class CategoriaServiceImplDatos : ICategoriasService
    {
        private ObservableCollection<CategoriaModel> categorias;
        public CategoriaServiceImplDatos()
        {
            categorias = new ObservableCollection<CategoriaModel>();
            categorias.Add(new CategoriaModel
            {
                CodCategoria = 1,
                NombreCategoria = "Revisión"
            });
            categorias.Add(new CategoriaModel
            {
                CodCategoria = 2,
                NombreCategoria = "Instalación"
            });
            categorias.Add(new CategoriaModel
            {
                CodCategoria = 3,
                NombreCategoria = "Validación"
            });
            categorias.Add(new CategoriaModel
            {
                CodCategoria = 4,
                NombreCategoria = "Seguimiento"
            });
            categorias.Add(new CategoriaModel
            {
                CodCategoria = 5,
                NombreCategoria = "Datos"
            });
        }
        public ObservableCollection<CategoriaModel> listarCategorias()
        {
            return this.categorias;

        }
    }
}
