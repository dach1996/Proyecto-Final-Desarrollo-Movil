﻿using Microsoft.AspNetCore.SignalR.Client;
using ProyectoFinalDM.INotifyProperty;
using ProyectoFinalDM.Models;
using ProyectoFinalDM.Services;
using ProyectoFinalDM.Services.IService;
using ProyectoFinalDM.Services.WSImplements;
using ProyectoFinalDM.View.Imagenes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProyectoFinalDM.ViewModel.Detalles
{
    public class ListaDetallesViewModel : Notificaciones
    {
        private IDetallesService detallesService = new DetalleServiceImplWS();
        private DetalleModel detalleModel;

        public Action RefresRefreshScrollDown;
        public DetalleModel detalle
        {
            get { return detalleModel; }
            set { detalleModel = value; this.OnPropertyChanged(); }
        }

        public ObservableCollection<DetalleModel> detalles { get; set; }
        private HubConnection hubConnection;
        public TicketModel ticket { get; set; }
        public ICommand guardarDetalleCommnad { get; set; }
        public ICommand verImagenesDetalleCommand { get; set; }
        public ListaDetallesViewModel(TicketModel ticket)

        {
            detalles = new ObservableCollection<DetalleModel>();
            detalle = new DetalleModel();
            this.ticket = ticket;
            cargarDatosTicket();
            this.guardarDetalleCommnad = new Command(() => guardarDetalle());
            this.verImagenesDetalleCommand = new Command(() => verImagenesDetalle());
            hubConnection = new HubConnectionBuilder()
                .WithUrl("http://alexmoyag-001-site2.ftempurl.com/ticketsHub").WithAutomaticReconnect()
                .Build();
            hubConnection.On<int, UsuarioModel>("recibirNotificaciónTicket", (codTicket, usuario) =>
            {
                Plugin.LocalNotifications.CrossLocalNotifications.Current.Show("Nueva modificación", $"{usuario.NombreCompleto} ha modificado el ticket: {codTicket}");
                this.cargarDatosTicket();
            });
            Connect();



        }
        public async void Connect()
        {
            try
            {
                await hubConnection.StartAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public async Task Disconnect()
        {
            try
            {
                await hubConnection.StopAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        private async void verImagenesDetalle()
        {
            await App.navegacion.PushAsync(new ListaImagenesView(this.ticket));
        }

        private async void cargarDatosTicket()
        {
            IsBusy = true;

            var consulta = await detallesService.buscarDetallesPorIdTicket(ticket.CodTicket);
            this.detalles.Clear();
            foreach (var item in consulta)
            {
                detalles.Add(item);
            }
            IsBusy = false;
            MessagingCenter.Send<object, object>(this, "MessageReceived", this.detalles.LastOrDefault());


        }


        private async void guardarDetalle()
        {
            this.detalle.Usuario = StaticData.usuaroLogeado;
            this.detalle.Ticket = this.ticket;
            await detallesService.guardarDetalle(this.detalle);
            cargarDatosTicket();
            this.detalle.TextoDetalle = "";
            await hubConnection.InvokeAsync("notificarTicket", this.ticket.CodTicket, StaticData.usuaroLogeado);
          

        }


    }
}
