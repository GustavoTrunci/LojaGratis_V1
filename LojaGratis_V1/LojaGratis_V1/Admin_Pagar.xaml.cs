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
    public partial class Admin_Pagar : ContentPage
    {
        FuncoesBD funcs = new FuncoesBD();
        Usuarios usu_atual = new Usuarios();

        public Admin_Pagar()
        {
            InitializeComponent();
        }



        private async void Mostra_Relatorio(int codigo_user)
        {

           

            IList<Consumo> lista_consumo;
            lista_consumo = await funcs.Retorna_Relatorio_Consumo(codigo_user);

            view_relatorio.ItemsSource = lista_consumo;
            BindingContext = this;

            double Total = 0;

            foreach (Consumo i in lista_consumo)
            {
                Total = Total + i.preco;
            }

            l_total.Text = "R$ " + Total;
        }

        private async void B_buscar_Clicked(object sender, EventArgs e)
        {

            usu_atual = await funcs.Le_Usuario(Convert.ToInt32(Usuario.Text));
            Nome_User.Text = usu_atual.nome;

            Mostra_Relatorio(usu_atual.codigo);
        }

        private async void B_Pagar_Clicked(object sender, EventArgs e)
        {

            b_Pagar.IsEnabled = false;

            Mensagem.Text = "";
            if (usu_atual.nome == "" )
            {
                Mensagem.Text = "Encontre um usuário antes.";
                b_Pagar.IsEnabled = true;
                return;
            }

            string retorno;
            retorno = await funcs.Paga_Relatorio_Consumo(usu_atual.codigo);

            Mensagem.Text = retorno;
            b_Pagar.IsEnabled = true;



            

        }
    }
}