using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Windows.Input;
using TestDrive.Models;
using Xamarin.Forms;

namespace TestDrive.ViewModels
{
    public class LoginViewModel
    {
        private string usuario;
        private string senha;

        public string Usuario
        {
            get { return usuario; }
            set 
            { 
                this.usuario = value;
                ((Command)EntrarCommand).ChangeCanExecute();
            }
        }

		public string Senha
		{
			get { return senha; }
			set 
            { 
                this.senha = value; 
                ((Command)EntrarCommand).ChangeCanExecute();
            }
		}

        public ICommand EntrarCommand { get; private set; }

        public LoginViewModel()
        {
            EntrarCommand = new Command(async () =>
            {
                //MessagingCenter.Send<Usuario>(new Usuario(), "SucessoLogin");

                LoginService ls = new LoginService();

                await ls.FazerLogin(new Login(usuario,senha));

            }, () => {
                return !string.IsNullOrEmpty(usuario) && !string.IsNullOrEmpty(senha) ;   
            });
        }

    }
}
