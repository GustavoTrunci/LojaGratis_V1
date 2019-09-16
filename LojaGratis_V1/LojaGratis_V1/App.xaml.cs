using Android.Widget;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Android.Content.Res;
using System.Threading.Tasks;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace LojaGratis_V1
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            Verifica_Conexao();
            Le_Dados_Usuario();


#if DEBUG
          //  FuncoesGerais.geral_Codigo_User = 1;
          //  FuncoesGerais.geral_Nome_User = "Gustavo";
          //  FuncoesGerais.geral_User_admin = true;
#endif

            if (FuncoesGerais.geral_Nome_User == "")
            {
              Chama_Tela_Login();
            }
            else
            {

            }



            MainPage = new NavigationPage(new MainPage());



           

            
            
        }

        private void Le_Dados_Usuario()
        {
            if (Application.Current.Properties.ContainsKey("Usuario"))
            {
                FuncoesGerais.geral_Nome_User = Application.Current.Properties["Usuario"].ToString();
                FuncoesGerais.geral_Codigo_User = (int)Application.Current.Properties["Usuario_Codigo"];
                FuncoesGerais.geral_User_admin = (bool)Application.Current.Properties["Usuario_Admin"];

            }
            else
            {
                FuncoesGerais.Apaga_Dados_Usuario(false);
            }
            
                                       

        }
    private async void Chama_Tela_Login()
    {
            //MainPage = new NavigationPage(new Login());
            MainPage = new NavigationPage();

            var detailPage = new Login();
            await MainPage.Navigation.PushModalAsync(detailPage);
            // Login = new NavigationPage(new Login());
            //  Login tela_log = new Login();
            //  await Navigation.PushAsync(tela_log);
        }


    protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }



        private async void Verifica_Conexao()
        {

            FuncoesBD funcs = new FuncoesBD();


            bool retorno = await funcs.Testa_conexao();
            if (retorno == false)
            {
                Toast.MakeText(Android.App.Application.Context, "Sem Conexão com a Internet", ToastLength.Short).Show();

                /*if (Device.RuntimePlatform== "Android")
                 {
                     Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
                 }*/

            }
        }






    }



}
