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
            Verifica_Conexao();
            Chama_Tela_Login();
           


        }

        private async void Chama_Tela_Login()
        {
            Login tela_log = new Login();
            await Navigation.PushAsync(tela_log);
        }

        private async void Verifica_Conexao()
        {

            FuncoesBD funcs = new FuncoesBD();


            bool retorno = await funcs.Testa_conexao();
            if (retorno == false)
            {
                Toast.MakeText(Android.App.Application.Context , "Sem Conexão com a Internet", ToastLength.Short).Show();
                
               /*if (Device.RuntimePlatform== "Android")
                {
                    Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
                }*/
                
            }
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

    }

    internal class Teste
    {
        public string Id { get; set; }
        public string teste { get; set; }


    }
}
