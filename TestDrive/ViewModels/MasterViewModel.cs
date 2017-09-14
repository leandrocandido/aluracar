using System;
using TestDrive.Models;

namespace TestDrive.ViewModels
{
    public class MasterViewModel
    {
        private string nome = "Leandro emanuel Candido";
        private string email = "leandro.candido@yahoo.com.br";
        private readonly Usuario usuario;
        public string Nome
        {
            get { return this.usuario.nome; }
            set { this.usuario.nome = value; }
        }

        public string Email
        {
            get { return this.usuario.email; }
            set { this.usuario.email = value; }
        }

        public MasterViewModel(Usuario user)
        {
            this.usuario = user;
        }
    }
}
