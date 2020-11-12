using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;

namespace ProyectoFinalDM.Services
{
    public abstract class WSConnection<T>
    {

        protected string Url = "http://192.168.100.29/WebService/Api/";
        protected HttpClient httpClient = new HttpClient();
        protected ObservableCollection<T> consulta;

    }
}
