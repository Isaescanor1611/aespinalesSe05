using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace aespinaless05
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AcEliminar : ContentPage
    {
        private object txtCodigo;
        private object txtNombre;

        public AcEliminar(Datos datos)
        {
            InitializeComponent();
            txtCodigo.Text = datos.codigo.ToString();
            txtNombre.Text = datos.nombre.ToString();
            txtApellido.Text = datos.apellido.ToString();
            txtEdad.Text = datos.edad.ToString();
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }

        private void btnActualizar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient cliente = new WebClient();
                string Url = "http://192.168.17.25/wsuisrael/post.php";
                string codigo = txtCodigo.Text;
                string nombre = txtNombre.Text;
                string apellido = txtApellido.Text;
                string edad = txtEdad.Text;

                string url = $"{Url}?codigo={codigo}&nombre={nombre}&apellido={apellido}&edad={edad}";

                var parametros = new System.Collections.Specialized.NameValueCollection();
                parametros.Add("codigo", txtCodigo.Text);
                parametros.Add("nombre", txtNombre.Text);
                parametros.Add("apellido", txtApellido.Text);
                parametros.Add("edad", txtEdad.Text);
                cliente.UploadValues(url, "PUT", parametros);
                //Mensaje TOAST
                var mensaje = "Dato actualizado";
                DependencyService.Get<Mensaje>().LongAlert(mensaje);

                Navigation.PushAsync(new MainPage());
            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", ex.Message, "Cerrar");
            }
        }

        private void btnEliminar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient cliente = new WebClient();
                string Url = "http://192.168.17.25/wsuisrael/post.php";
                string codigo = txtCodigo.Text;
                string nombre = txtNombre.Text;
                string apellido = txtApellido.Text;
                string edad = txtEdad.Text;

                string url = $"{Url}?codigo={codigo}";

                var parametros = new System.Collections.Specialized.NameValueCollection();
                parametros.Add("codigo", txtCodigo.Text);
                parametros.Add("nombre", txtNombre.Text);
                parametros.Add("apellido", txtApellido.Text);
                parametros.Add("edad", txtEdad.Text);
                cliente.UploadValues(url, "DELETE", parametros);
                //Mensaje TOAST
                var mensaje = "Dato eliminado";
                DependencyService.Get<Mensaje>().LongAlert(mensaje);

                Navigation.PushAsync(new MainPage());
            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", ex.Message, "Cerrar");
            }

        }
    }
}
