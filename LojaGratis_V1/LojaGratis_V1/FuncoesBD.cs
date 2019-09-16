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


        public async Task<string> Grava_Produto(int aux_codigo, string aux_nome, double aux_preco, bool aux_inativo, bool novo)
        {
            var client = new MobileServiceClient("https://idealapp.azurewebsites.net");

            var produtosTable = client.GetTable<Produtos>();

            Produtos linha;

            // PRODUTO NOVO
            if (novo == true)
            {
                linha = new Produtos()
                {
                    codigo = aux_codigo,
                    nome = aux_nome,
                    preco = aux_preco,
                    inativo = aux_inativo
                };

                try
                {
            await produtosTable.InsertAsync(linha);
                }
                catch (Exception e)
                {
                    return e.ToString();
                }
                return "";
        }


            //ATUALIZANDO PRODUTO
            linha = await Le_Produto(aux_codigo);
            if (linha.nome == "") {
                return ("Produto não encontrado para gravar.");
            }

            linha.codigo = aux_codigo;
            linha.nome = aux_nome;
            linha.preco = aux_preco;
            linha.inativo = aux_inativo;

            try
            {
                await produtosTable.UpdateAsync(linha);
            }
            catch (Exception e)
            {
                return e.ToString();
            }
            return "";
        }




        public async Task<string> Grava_Usuario(int aux_codigo, string aux_nome, string aux_senha, bool aux_bloqueado, bool aux_admin, bool novo)
        {
            var client = new MobileServiceClient("https://idealapp.azurewebsites.net");

            var usuariosTable = client.GetTable<Usuarios>();

            Usuarios linha;

            // USUARIO NOVO
            if (novo == true)
            {
                linha = new Usuarios()
                {
                    codigo = aux_codigo,
                    nome = aux_nome,
                    senha = aux_senha,
                    bloqueado = aux_bloqueado,
                    admin = aux_admin
                };

                try
                {
                    await usuariosTable.InsertAsync(linha);
                }
                catch (Exception e)
                {
                    return e.ToString();
                }
                return "";
            }


            //ATUALIZANDO USUARIO
            linha = await Le_Usuario(aux_codigo);
            if (linha.nome == "")
            {
                return ("Usuário não encontrado para gravar.");
            }

            linha.codigo = aux_codigo;
            linha.nome = aux_nome;
            linha.senha = aux_senha;
            linha.bloqueado = aux_bloqueado;
            linha.admin = aux_admin;

            try
            {
                await usuariosTable.UpdateAsync(linha);
            }
            catch (Exception e)
            {
                return e.ToString();
            }
            return "";
        }







        public async Task<int> Retorna_prox_codigo_produto()
        {
            var client = new MobileServiceClient("https://idealapp.azurewebsites.net");

            var produtosTable = client.GetTable<Produtos>();
            List<Produtos> produto1 = (await produtosTable
                .OrderByDescending(Produtos => Produtos.codigo)
                .Take(1)
                .ToListAsync());

            if (produto1.Count == 0) return 1;

            return produto1[0].codigo+1;
        }

        public async Task<int> Retorna_prox_codigo_usuario()
        {
            var client = new MobileServiceClient("https://idealapp.azurewebsites.net");

            var usuariosTable = client.GetTable<Usuarios>();
            List<Usuarios> usuario1 = (await usuariosTable
                .OrderByDescending(Usuarios => Usuarios.codigo)
                .Take(1)
                .ToListAsync());

            if (usuario1.Count == 0) return 1;

            return usuario1[0].codigo + 1;


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


        public async Task<IList<Consumo>> Retorna_Relatorio_Consumo(int aux_usuario)
        {
            var client = new MobileServiceClient("https://idealapp.azurewebsites.net");


            var consumoTable = client.GetTable<Consumo>();
            List<Consumo> consumos;

            if (aux_usuario != 0)
            {


                consumos = (await consumoTable
                    .Where(Consumo => Consumo.usuario == aux_usuario && Consumo.pago == false)
                    .OrderBy(Consumo => Consumo.ordem)
                    .ToListAsync());
            } else
            {
                consumos = (await consumoTable
                    .Where(Consumo => Consumo.pago == false)
                    .OrderBy(Consumo => Consumo.produto)
                    .ToListAsync());

            }
            if (consumos.Count == 0) return new List<Consumo>();

            return consumos;
        }


        public async Task<string> Paga_Relatorio_Consumo(int aux_usuario)
        {
            var client = new MobileServiceClient("https://idealapp.azurewebsites.net");

                        var consumoTable = client.GetTable<Consumo>();
            List<Consumo> consumos = (await consumoTable
                .Where(Consumo => Consumo.usuario == aux_usuario && Consumo.pago == false)
                .OrderBy(Consumo => Consumo.ordem)
                .ToListAsync());

            if (consumos.Count == 0) return "Não existia consumo pendente.";

            int total_linhas = consumos.Count;
           
            double total_pago = 0;

            for (int i = 0; i < total_linhas; i++)
            {
                try
                {


                    Consumo linha_consumo = new Consumo();
                    linha_consumo = await consumoTable.LookupAsync(consumos[i].Id);
                    linha_consumo.pago = true;
                    total_pago += linha_consumo.preco;


                    await consumoTable.UpdateAsync(linha_consumo);
                }
                catch (Exception e)
                {
                    return "Erro ao receber, verifique relatório: " + e.ToString();
                }
            }


            return "Total pago de R$ " + total_pago;

        }






        public async Task<IList<Usuarios>> Retorna_Relatorio_Usuarios()
        {
            var client = new MobileServiceClient("https://idealapp.azurewebsites.net");

            var usuariosTable = client.GetTable<Usuarios>();
            List<Usuarios> usus = (await usuariosTable
                .OrderBy(Usuarios => Usuarios.nome)
                .ToListAsync());



            return usus;

        }

        

    }
}
