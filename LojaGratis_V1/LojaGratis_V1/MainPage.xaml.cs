using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LojaGratis_V1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            teste_bd();
        }

        private async void teste_bd()
        {
            var client = new MobileServiceClient("https://idealapp.azurewebsites.net",);
            

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
