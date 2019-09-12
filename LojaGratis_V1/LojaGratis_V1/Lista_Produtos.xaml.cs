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
    public partial class Lista_Produtos : ContentPage
    {
        public Lista_Produtos()
        {
            InitializeComponent();
            Mostra_Lista();
        }

        private async void Mostra_Lista()
        {

           FuncoesBD funcs = new FuncoesBD();

        IList<Produtos> lista_prod;
        lista_prod= await funcs.Retorna_Lista_Produtos();

            view_lista_produtos.ItemsSource = lista_prod;
            BindingContext = this;


        }
   
    }
}