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
    public partial class Admin_Cad_Usu : ContentPage
    {
        private FuncoesBD funcs = new FuncoesBD();
        private string novo_gravar = "";

        public Admin_Cad_Usu()
        {
            InitializeComponent();
        }
        private async void B_Novo_Clicked(object sender, EventArgs e)
        {
            Mensagem.Text = "";
            int prox;
            prox = await funcs.Retorna_prox_codigo_usuario();

            Codigo.Text = prox.ToString();

            novo_gravar = "NOVO";
        }

        private async void B_Alterar_Clicked(object sender, EventArgs e)
        {
            novo_gravar = "";
            Mensagem.Text = "";
            Usuarios retorno = await funcs.Le_Usuario(Convert.ToInt32(Codigo.Text));

            if (retorno.nome is null)
            {
                Mensagem.Text = "Usuário não encontrado.";
                return;
            }

            Codigo.Text = retorno.codigo.ToString();
            Nome.Text = retorno.nome;
            Senha.Text = retorno.senha;
            Bloqueado.IsToggled = retorno.bloqueado;
            Admin.IsToggled = retorno.admin;

            novo_gravar = "GRAVAR";


        }

        private async void B_Gravar_Clicked(object sender, EventArgs e)
        {
            Mensagem.Text = "";
            bool novo_registro = false;

            if (novo_gravar == "")
            {
                Mensagem.Text = "Função não escolhida.";
                return;
            }

            if (novo_gravar == "NOVO")
            {
                novo_registro = true;
            }

            string ret = await funcs.Grava_Usuario(Convert.ToInt32(Codigo.Text), Nome.Text, Senha.Text, Bloqueado.IsToggled , Admin.IsToggled, novo_registro);
            if (ret == "")
            {
                Mensagem.Text = "Registro Gravado";
            }
            else
            {
                Mensagem.Text = ret;
            }


        }
    }
}