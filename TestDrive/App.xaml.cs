using Xamarin.Forms;
using TestDrive.Views;
using TestDrive.Models;

namespace TestDrive
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            //para iniciar a pilha de navegacao
            //MainPage = new NavigationPage (new ListagemView());

            MainPage = new LoginView();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            MessagingCenter.Subscribe<Usuario>(this, "SucessoLogin",
            (usuario)=>
            {
                //MainPage = new NavigationPage(new ListagemView());   
                MainPage = new MasterDetailView(usuario);
			});
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
