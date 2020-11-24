using Microcharts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkiaSharp;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace ProyectoFinalDM.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GraficaView : ContentPage
    {
        List<ChartEntry> entryList;
        public GraficaView()
        {
            InitializeComponent();
            entryList = new List<ChartEntry>();
        }

        private void LoadEntries(string empresalocal)
        {
            entryList.Clear();
            Dictionary<string, object> localespersonas = new Dictionary<string, object>();
            int[] personas = new int[] { 100, 50, 10, 30, 0, 10, 70, 0, 10, 10 };
            localespersonas.Add("Crocs - Bosque", personas);
            personas = new int[] { 23, 50, 100, 30, 5, 10, 70, 68, 32, 0 };
            localespersonas.Add("Crocs - San Marino", personas);
            personas = new int[] { 80, 80, 100, 50, 55, 100, 70, 68, 50, 60 };
            localespersonas.Add("Taty - San Marino", personas);
            personas = new int[] { 0, 50, 100, 0, 25, 10, 70, 30, 0, 0 };
            localespersonas.Add("Taty - CCI", personas);
            personas = new int[] { };
            foreach (KeyValuePair<string, object> kvp in localespersonas)
            {
                if (kvp.Key == empresalocal)
                {

                    personas = kvp.Value as int[];
                }
            }


            int[] horas = new int[] { 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 };
            //int[] personas = new int[] { 100, 50, 10, 30, 0, 10, 70, 0, 10, 10 };

            var random = new Random();

            var color = String.Format("#{0:X6}", random.Next(0x1000000));

            for (int i = 0; i < personas.Length; i++)
            {
                color = String.Format("#{0:X6}", random.Next(0x1000000));
                ChartEntry e1 = new ChartEntry(personas[i])
                {
                    Label = horas[i].ToString() + ":00h",
                    ValueLabel = personas[i].ToString(),
                    Color = SKColor.Parse(color)
                };
                entryList.Add(e1);

            }
        }



        void OnButtonClicked(object sender, EventArgs args)
        {
            Button button = (Button)sender;
            //Cargar nuesta lista de entries;
            try
            {
                LoadEntries(picker.SelectedItem.ToString());
                //Asignar los datos dentro de los entrys a los gráficos dentro de la vista XAML
                linesChart.Chart = new LineChart()
                {
                    Entries = entryList
                };

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                DisplayAlert("Error", "Seleccione un local", "OK");
            }


        }

    }
}