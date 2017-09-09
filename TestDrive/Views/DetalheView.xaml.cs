using System;
using System.Collections.Generic;
using TestDrive.Models;
using TestDrive.ViewModels;
using Xamarin.Forms;

namespace TestDrive.Views
{
    public partial class DetalheView : ContentPage
    {
        public Veiculo Veiculo { get; set; }


        public DetalheView(Veiculo veiculo)
        {
            InitializeComponent();
            this.Veiculo = veiculo;
            this.BindingContext = new DetalheViewModel(veiculo);
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            
            Navigation.PushAsync(new AgendamentoView(this.Veiculo));
        }
    }
}
