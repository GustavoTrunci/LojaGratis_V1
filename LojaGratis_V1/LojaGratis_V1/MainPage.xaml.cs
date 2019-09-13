using Microsoft.WindowsAzure.MobileServices;
using System.Collections.Generic;
using Xamarin.Forms;
using LojaGratis_V1.Tables;
using System.Threading.Tasks;
using Android.Widget;
using Android.Content.Res;

namespace LojaGratis_V1
{
    public partial class MainPage : ContentPage
    {
        

        public  MainPage()
        {
            InitializeComponent();
            if (FuncoesGerais.geral_User_admin==true)
            {
                b_Admin.IsVisible  = true;
                    }

            l_usuario.Text = FuncoesGerais.geral_Codigo_User + "-" + FuncoesGerais.geral_Nome_User + "-" + FuncoesGerais.geral_User_admin.ToString();


        }

    

       
        private async void teste_bd()
        {
            var client = new MobileServiceClient("https://idealapp.azurewebsites.net");



            var lojasTable = client.GetTable<Lojas>();
            List<Lojas> loja1 = (await lojasTable
                .Where(Lojas => Lojas.codigo == 2)
                .ToListAsync());



            var testeTable = client.GetTable<Teste>();

            var lista = await testeTable.ToListAsync();

            Teste linha = new Teste() { teste = "foi" };

            await testeTable.InsertAsync(linha);

            linha.teste = "foi mesmo";

            await testeTable.UpdateAsync(linha);
        }

        private async void B_Consumir_Clicked(object sender, System.EventArgs e)
        {

            if (FuncoesGerais.geral_Codigo_User == 0)
            {
                return;
            }
            var detailPage = new Consumir();
                await Navigation.PushModalAsync(detailPage);
           

        }

        private async void B_Relatorio_Clicked(object sender, System.EventArgs e)
        {
            var detailPage = new Relatorio1();
            await Navigation.PushModalAsync(detailPage);
        }

        private async void B_Lista_Prod_Clicked(object sender, System.EventArgs e)
        {
            var detailPage = new Lista_Produtos();
            await Navigation.PushModalAsync(detailPage);
        }

        private async void B_Admin_Clicked(object sender, System.EventArgs e)
        {
            var detailPage = new Admin_Menu();
            await Navigation.PushModalAsync(detailPage);
        }

        private async void B_Logout_Clicked(object sender, System.EventArgs e)
        {
            FuncoesGerais.Apaga_Dados_Usuario(true);


            //Android.OS.Process.KillProcess(Android.OS.Process.MyPid());

            var detailPage = new Login();
            await Navigation.PushModalAsync(detailPage);
        }
    }

    internal class Teste
    {
        public string Id { get; set; }
        public string teste { get; set; }


    }
}
