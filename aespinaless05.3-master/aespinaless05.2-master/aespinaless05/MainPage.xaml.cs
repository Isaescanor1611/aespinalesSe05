using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace aespinaless05
{

    public partial class MainPage : ContentPage
    {
        private const string Url = "http://192.168.17.25/wsuisrael/post.php";
        private HttpClient cliente = new HttpClient();
        private ObservableCollection<aespinaless05.Datos> datos;
        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnMostrar_Clicked(object sender, EventArgs e)
        {
            var contenido = await cliente.GetStringAsync(Url);
            List<aespinaless05.Datos> listPost = JsonConvert.DeserializeObject<List<aespinaless05.Datos>>(contenido);
            datos = new ObservableCollection<Datos>(listPost);
            listaEstudiantes.ItemsSource = datos;
        }

        private void listaEstudiantes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var objetoEstudiante = (Datos)e.SelectedItem;
            /*
            int codigo = Convert.ToInt32(objetoEstudiante.codigo.ToString());
            string nombre = objetoEstudiante.nombre.ToString();
            string apellido = objetoEstudiante.apellido.ToString();
            int edad = Convert.ToInt32(objetoEstudiante.edad.ToString());
            */
            Navigation.PushAsync(new AcEliminar(objetoEstudiante));
        }
    }
}
