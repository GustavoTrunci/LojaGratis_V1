using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using LojaGratis_V1.Tables;

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
