using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Text;
using LojaGratis_V1.Tables;
using System.Threading.Tasks;
using Android.Net;

namespace LojaGratis_V1
{
    class FuncoesBD
    {
        public async Task<bool>  Testa_conexao()
        {
            var client = new MobileServiceClient("https://idealapp.azurewebsites.net");

            var lojasTable = client.GetTable<Lojas>();
            List<Lojas> loja1 = (await lojasTable
                .Where(Lojas => Lojas.codigo == 1)
                .ToListAsync());

            if (loja1.Count == 0) return false;
            return true;

        }

        public async Task<Usuarios> Le_Usuario(int codigo)
        {
            var client = new MobileServiceClient("https://idealapp.azurewebsites.net");

            var usuariosTable = client.GetTable<Usuarios>();
            List<Usuarios> usuarios1 = (await usuariosTable
                .Where(Usuarios => Usuarios.codigo == codigo)
                .ToListAsync());

            if (usuarios1.Count == 0) return new Usuarios();

            return usuarios1[0];

        }

        public async Task<Usuarios> Le_Usuario(string nome)
        {
            var client = new MobileServiceClient("https://idealapp.azurewebsites.net");

            var usuariosTable = client.GetTable<Usuarios>();
            List<Usuarios> usuarios1 = (await usuariosTable
                .Where(Usuarios => Usuarios.nome == nome)
                .ToListAsync());

            if (usuarios1.Count == 0) return new Usuarios();

            return usuarios1[0];

        }


        public async Task<bool> Verifica_Usuario_Ativo(int codigo)
        {
            var client = new MobileServiceClient("https://idealapp.azurewebsites.net");

            var usuariosTable = client.GetTable<Usuarios>();
            List<Usuarios> usuarios1 = (await usuariosTable
                .Where(Usuarios => Usuarios.codigo == codigo)
                .ToListAsync());

            if (usuarios1.Count == 0) return false;

            if (usuarios1[0].bloqueado == true) return false;

            return true;

        }



        public async Task<Produtos> Le_Produto(int codigo)
        {
            var client = new MobileServiceClient("https://idealapp.azurewebsites.net");

            var produtosTable = client.GetTable<Produtos>();
            List<Produtos> produto1 = (await produtosTable
                .Where(Produtos => Produtos.codigo == codigo)
                .ToListAsync());

            if (produto1.Count == 0) return new Produtos();

            return produto1[0];

        }


        public async Task<string> Grava_Consumo (int aux_usuario, string aux_produto, double aux_preco)
        {


            if (aux_usuario == 0) return "Usuário inválido.";
            if (aux_produto == "") return "Produto inválido.";
            if (aux_preco == 0) return "Preço inválido.";

            var client = new MobileServiceClient("https://idealapp.azurewebsites.net");
            var consumoTable = client.GetTable<Consumo>();

            Consumo linha = new Consumo() { usuario=aux_usuario, data=DateTime.Today, pago=false, preco=aux_preco, produto=aux_produto, hora= DateTime.Now.ToString("HH:mm:ss")};

            try
            {
                await consumoTable.InsertAsync(linha);
            }
            catch (Exception e)
            {
                return e.ToString();
            }
            
            return "";
        }



        public async Task<IList<Produtos>> Retorna_Lista_Produtos()
        {
            var client = new MobileServiceClient("https://idealapp.azurewebsites.net");

            var produtosTable = client.GetTable<Produtos>();
            List<Produtos> prods = (await produtosTable
                .Where(Produtos => Produtos.inativo==false)
                .ToListAsync());

           

            return prods;

        }


        public async Task<IList<Consumo>> Retorna_Relatorio(int aux_usuario)
        {
            var client = new MobileServiceClient("https://idealapp.azurewebsites.net");


            var consumoTable = client.GetTable<Consumo>();
            List<Consumo> consumos = (await consumoTable
                .Where(Consumo => Consumo.usuario==aux_usuario && Consumo.pago == false)
                .OrderBy(Consumo => Consumo.ordem)
                .ToListAsync());

            if (consumos.Count == 0) return new List<Consumo>();

            return consumos;



        }

    }
    }
