﻿﻿using System.Collections.Generic;
using TestDrive.Models;
using TestDrive.ViewModels;
using Xamarin.Forms;

namespace TestDrive.Views
{
    


    public partial class ListagemView : ContentPage
    {
      
        private ListagemViewModel ViewModel { get; set; } 

        public ListagemView()
        {
            InitializeComponent();
            this.ViewModel = new ListagemViewModel();
            this.BindingContext = this.ViewModel;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            MessagingCenter.Subscribe<Veiculo>(this, "VeiculoSelecionado" , 
                (msg) =>
                {
					Navigation.PushAsync(new DetalheView(msg));
                });

            await ViewModel.GetveiculosAsync();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Veiculo>(this, "VeiculoSelecionado");

        }

    }
}
