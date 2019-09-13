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
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }

        private async void B_Login_Clicked(object sender, EventArgs e)
        {
            FuncoesBD funcs = new FuncoesBD();

            string nome_user = Usuario.Text.Trim();

            Usuarios retorno = await funcs.Le_Usuario(nome_user);

            if (retorno.nome is null) {
                Mensagem.Text = "Usuário não encontrado.";
                return;
            }

            if (retorno.senha != Senha.Text )
            {
                Mensagem.Text = "Senha inválida.";
                return;
            }

            Application.Current.Properties["Usuario"] = retorno.nome;
            Application.Current.Properties["Usuario_Codigo"] = retorno.codigo;
            Application.Current.Properties["Usuario_Admin"] = retorno.admin;

           await Application.Current.SavePropertiesAsync();

            FuncoesGerais.geral_Nome_User = retorno.nome;
            FuncoesGerais.geral_Codigo_User = retorno.codigo;
            FuncoesGerais.geral_User_admin = retorno.admin;

            await Navigation.PopModalAsync();
        }
    }
}