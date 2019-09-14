using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LojaGratis_V1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Admin_Menu : ContentPage
    {
        public Admin_Menu()
        {
            InitializeComponent();
        }

        private async void B_Cad_Prod_Clicked(object sender, EventArgs e)
        {
            var detailPage = new Admin_Cad_Prod();
            await Navigation.PushModalAsync(detailPage);
        }

        private async void B_Cad_Usu_Clicked(object sender, EventArgs e)
        {
            var detailPage = new Admin_Cad_Usu();
            await Navigation.PushModalAsync(detailPage);
        }

        private async void B_Rel_Usuarios_Clicked(object sender, EventArgs e)
        {
            var detailPage = new Admin_Rel_Usu();
            await Navigation.PushModalAsync(detailPage);
        }

        private async void B_Pagar_Clicked(object sender, EventArgs e)
        {
            var detailPage = new Admin_Pagar();
            await Navigation.PushModalAsync(detailPage);
        }

        private async void B_Rel_Consumo_Geral_Clicked(object sender, EventArgs e)
        {
            var detailPage = new Admin_Rel_Consumo_Geral();
            await Navigation.PushModalAsync(detailPage);

        }
    }
}