using Microsoft.AspNetCore.SignalR.Client;
using ProyectoFinalDM.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalDM.Services.SignalR
{
    class HubTicket
    {
       private string linkHub = "http://alexmoyag-001-site2.ftempurl.com/ticketsHub";
        // private string linkHub = "http://192.168.100.29:5000/ticketsHub";
        public static HubConnection hubConnection;
        public HubTicket()
        {
            if (hubConnection == null)
            hubConnection = new HubConnectionBuilder()
               .WithUrl(linkHub).WithAutomaticReconnect()
               .Build();
        }

        public void suscribirceTicket()
        {
            hubConnection.On<int, UsuarioModel>("recibirNotificaciónTicket", (codTicket, usuario) =>
            {
                Plugin.LocalNotifications.CrossLocalNotifications.Current.Show("Nueva modificación", $"{usuario.NombreCompleto} ha modificado el ticket: {codTicket}");
            });
            this.Connect();
        }
        public void suscribirceCargarDetalles(Action funcionCargarDetalles)
        {
            hubConnection.On<int, UsuarioModel>("recibirNotificaciónTicket", (codTicket, usuario) =>
            {
                funcionCargarDetalles();
            });
            this.Connect();
        }
        public async void Connect()
        {
            try
            {
                if (hubConnection.State != HubConnectionState.Connected)
                {
                    await hubConnection.StartAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public async void Disconnect()
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

        public async void enviarMensajeHubTicket(int codTicket, UsuarioModel usuario)
        {
            try
            {
                this.Connect();
                await hubConnection.InvokeAsync("notificarTicket", codTicket, usuario);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
