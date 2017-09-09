﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using TestDrive.Models;
using Xamarin.Forms;

namespace TestDrive
{

    public class LoginException : Exception
    {
        public LoginException(string  msg) : base(msg)
        {
            
        }
    }

    public class LoginService
    {
        public LoginService()
        {
        }

		public async System.Threading.Tasks.Task FazerLogin(Login login)
		{
            //joao@alura.com.br
            //alura123
			using (var client = new HttpClient())
			{
				var camposFormulario = new FormUrlEncodedContent(new[]
				{
                    new KeyValuePair<string,string>("email",login.Email),
                    new KeyValuePair<string,string>("senha",login.Senha)
					});
				client.BaseAddress = new Uri("https://aluracar.herokuapp.com/login");

				var resultado = await client.PostAsync("/login", camposFormulario);

                if(resultado.IsSuccessStatusCode)
				    MessagingCenter.Send<Usuario>(new Usuario(), "SucessoLogin");
                else
                    MessagingCenter.Send<LoginException>(new LoginException("usuario ou senha incorretos!"), "FalhaLogin");
			}
		}
    }
}