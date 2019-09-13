
using LiteDB;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace LojaGratis_V1
{
    public class FuncoesGerais
    {


        public static string geral_Nome_User { get; set; }
        public static int geral_Codigo_User { get; set; }

        public static bool geral_User_admin { get; set; }
    
        
        public static void Apaga_Dados_Usuario(bool Remove_Dados_App)
        {
            FuncoesGerais.geral_Nome_User = "";
            FuncoesGerais.geral_Codigo_User = 0;
            FuncoesGerais.geral_User_admin = false;

            if (Remove_Dados_App == true)
            {
                Application.Current.Properties["Usuario"] = "";
                Application.Current.Properties["Usuario_Codigo"] = 0;
                Application.Current.Properties["Usuario_Admin"] = false;
                
                Application.Current.SavePropertiesAsync();
            }

        }
          
    }



    }

