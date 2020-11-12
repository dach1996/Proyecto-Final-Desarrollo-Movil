using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;

namespace ProyectoFinalDM.Services
{
    public abstract class WSConnection<T>
    {

        protected string Url = "http://bitcoinbinances.com/WebService/Api/";
        protected HttpClient httpClient = new HttpClient();
        protected ObservableCollection<T> consulta;

    }
}
