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



    }
    }
