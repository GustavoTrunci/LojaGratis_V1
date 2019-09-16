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
    public partial class Consumir : ContentPage
    {
        private FuncoesBD funcs = new FuncoesBD();
        private string aux_produto_atual="";
        private double aux_preco_atual=0;

        public Consumir()
        {
            InitializeComponent();

            
        }

        private async void B_Consumir_Clicked(object sender, EventArgs e)
        {

            Mensagem.Text = "";
            b_voltar.IsEnabled = false;
            b_Consumir.IsEnabled = false;

            if (aux_produto_atual=="")
            {
                Mensagem.Text = "Busque um produto.";
                b_voltar.IsEnabled = true;
                b_Consumir.IsEnabled = true;
                return;
            }


            bool usuario_ativo = await funcs.Verifica_Usuario_Ativo(FuncoesGerais.geral_Codigo_User);
            if (usuario_ativo == false)
            {
                Mensagem.Text = "Usuário bloqueado.";
                b_voltar.IsEnabled = true;
                b_Consumir.IsEnabled = true;
                return;
            }

            string retorno = await funcs.Grava_Consumo (FuncoesGerais.geral_Codigo_User, aux_produto_atual, aux_preco_atual);

            if (retorno != "")
            {
                Mensagem.Text = "ERRO!!!!!!! ERROO!!!! " + retorno;
                b_voltar.IsEnabled = true;
                b_Consumir.IsEnabled = true;
                return;
            }

            b_voltar.IsEnabled = true;
            b_Consumir.IsEnabled = true;

            Mensagem.Text = "OBRIGADO!!!!";


        }

        private void B_voltar_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();

        }

        private async void B_buscar_Clicked(object sender, EventArgs e)
        {
           
            Mensagem.Text = "";
            aux_preco_atual = 0;
            aux_produto_atual ="";

            int aux_codigo=0;
            try
            {
                aux_codigo = Convert.ToInt32(codigo.Text);
            }
            catch { }
            
            if (aux_codigo <= 0)
            {
                Mensagem.Text = "Código inválido.";
                return;
            }
                            

            

            Produtos retorno = await funcs.Le_Produto(aux_codigo);

            if (retorno.nome is null)
            {
                Mensagem.Text = "Produto não encontrado.";
                return;
            }

            nome_produto.Text = retorno.nome;
            preco_produto.Text = "R$ " + retorno.preco;

            aux_produto_atual = retorno.nome;
            aux_preco_atual = retorno.preco;
                                 

        }
    }
}