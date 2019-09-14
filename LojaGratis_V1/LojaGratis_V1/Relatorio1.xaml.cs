using LojaGratis_V1.Tables;
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
    public partial class Relatorio1 : ContentPage
    {
        public Relatorio1()
        {
            InitializeComponent();
            Mostra_Relatorio();
        }

        public async void Mostra_Relatorio()
        {

            FuncoesBD funcs = new FuncoesBD();

            IList<Consumo> lista_consumo;
            lista_consumo = await funcs.Retorna_Relatorio_Consumo(FuncoesGerais.geral_Codigo_User);

            view_relatorio.ItemsSource = lista_consumo;
            BindingContext = this;

            double Total = 0;

            foreach (Consumo i in lista_consumo)
            {
                Total = Total + i.preco;
            }

            l_total.Text = "R$ " + Total;
        }
    }
}