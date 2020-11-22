using ProyectoFinalDM.Models;
using ProyectoFinalDM.Models.MasterPage;
using ProyectoFinalDM.Services.WSImplements;
using ProyectoFinalDM.View;
using ProyectoFinalDM.View.Huella;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoFinalDM.ViewModel.MaterPage
{
    class MasterPageViewModel
    {

        // Se crea el menú en el constructor ya que son datos estaticos y no requiere implementación
        public List<MaterPageItems> menuList { get; set; }
        public UsuarioModel Usuario { get; set; }
        public MasterPageViewModel()
        {
            this.Usuario = StaticData.usuaroLogeado;
            menuList = new List<MaterPageItems>();
            menuList.Add(new MaterPageItems() { Titulo = "Tickets", Icono = "MenuItemTickets.png", Pagina = typeof(TicketView) });
            menuList.Add(new MaterPageItems() { Titulo = "Tráfico", Icono = "MenuItemTrafico.png", Pagina = typeof(GraficaView) });
            menuList.Add(new MaterPageItems() { Titulo = "Cargar Información", Icono = "MenuItemDatos.png", Pagina = typeof(TicketView) });
            menuList.Add(new MaterPageItems() { Titulo = "Huella dactilar", Icono = "MenuItemHuella.png", Pagina = typeof(HuellaView) });
            menuList.Add(new MaterPageItems() { Titulo = "Acerca de", Icono = "MenuItemAcercaDe.png", Pagina = typeof(TicketView) });
    
        }
    }
}
