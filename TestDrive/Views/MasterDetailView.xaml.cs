using System;
using System.Collections.Generic;
using TestDrive.Models;
using Xamarin.Forms;

namespace TestDrive.Views
{
    public partial class MasterDetailView : MasterDetailPage
    {
        private readonly Usuario usuario;

        public MasterDetailView(Usuario user)
        {
            InitializeComponent();
            this.usuario = user;
            this.Master = new MasterView(user);
            //this.Detail = new ListagemView();
        }
    }
}
