using System;
using System.Windows.Input;
using TestDrive.Models;
using Xamarin.Forms;

namespace TestDrive.ViewModels
{
    public class MasterViewModel : BaseViewModel
    {
        //private string nome = "Leandro emanuel Candido";
        //private string email = "leandro.candido@yahoo.com.br";
        private readonly Usuario usuario;

		public ICommand EditarPerfilCommand { get; private set; }
		public ICommand SalvarCommand { get; private set; }
        public ICommand EditarCommand { get; private set; }

        private Boolean editando = false;
        public Boolean Editando
        {
            get  { return this.editando; }

            private set 
            { 
                this.editando = value;
                OnPropertyChanged(nameof(Editando));
            }
        }


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

		public string DataNascimento
		{
			get { return this.usuario.dataNascimento; }
			set { this.usuario.dataNascimento = value; }
		}

		public string Telefone
		{
			get { return this.usuario.telefone; }
			set { this.usuario.telefone = value; }
		}


        public MasterViewModel(Usuario user)
        {
            this.usuario = user;
            DefinirComandos();

        }

        private void DefinirComandos()
        {
            this.EditarPerfilCommand = new Command(() =>
            {
                MessagingCenter.Send<Usuario>(this.usuario, "EditarPerfil");
            });

            this.SalvarCommand = new Command(() =>
            {
                this.Editando = false;
                MessagingCenter.Send<Usuario>(this.usuario, "SucessoSalvarUsuario");
            });

            //comando para o botar editar 
            this.EditarCommand = new Command(() => 
            {
                this.Editando = true;
            });

        }

    }
}
