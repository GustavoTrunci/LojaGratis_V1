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
    public partial class Admin_Rel_Usu : ContentPage
    {
        public Admin_Rel_Usu()
        {
            InitializeComponent();
            Mostra_Relatorio();
        }

        public async void Mostra_Relatorio()
        {

            FuncoesBD funcs = new FuncoesBD();

            IList<Usuarios> lista_usuarios;
            lista_usuarios = await funcs.Retorna_Relatorio_Usuarios();

            view_relatorio.ItemsSource = lista_usuarios;
            BindingContext = this;

        }
    }
}