using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;

namespace ProyectoFinalDM.Services
{
    public abstract class WSConnection<T>
    {

        protected string Url = "http://alexmoyag-001-site1.ftempurl.com/api/";
        protected HttpClient httpClient = new HttpClient();
        protected ObservableCollection<T> consulta;


    }
}
