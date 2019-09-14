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
    public partial class Admin_Rel_Consumo_Geral : ContentPage
    {
        FuncoesBD funcs = new FuncoesBD();
        public Admin_Rel_Consumo_Geral()
        {
            InitializeComponent();
            Mostra_Relatorio();
        }

        private async void Mostra_Relatorio()
        {



            IList<Consumo> lista_consumo;
            lista_consumo = await funcs.Retorna_Relatorio_Consumo(0);

            view_relatorio.ItemsSource = lista_consumo;
            BindingContext = this;

            double Total = 0;

            foreach (Consumo i in lista_consumo)
            {
                Total += i.preco;
            }

            l_total.Text = "R$ " + Total;
        }

      
       
    }
}