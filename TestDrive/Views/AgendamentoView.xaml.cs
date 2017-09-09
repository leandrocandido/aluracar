using System;
using System.Collections.Generic;
using TestDrive.Models;
using TestDrive.ViewModels;
using Xamarin.Forms;

namespace TestDrive.Views
{
    public partial class AgendamentoView : ContentPage
    {
        
        public AgendamentoViewModel viewModel { get; set; }

        public AgendamentoView(Veiculo veiculo)
        {
            InitializeComponent();
            this.viewModel = new AgendamentoViewModel(veiculo);
            this.BindingContext = this.viewModel;
        }

  /*      void Handle_Clicked(object sender, System.EventArgs e)
        {
		
           
        }
*/

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<Agendamento>(this, "Agendamento",
            async (msg) =>
            {
                var confirma = await DisplayAlert("Salvar agendamento",
                                                    "Deseja mesmo enviar o agendamento?",
                                                    "Sim", 
                                                    "Não"
                            );

                if (confirma == true)
                {
                    this.viewModel.SalvarAgendamento();
					/*DisplayAlert("Agendamento",
						string.Format(@"Veiculo {0}
                                        Nome: {1}
                                        Fone: {2}
                                        Email: {3}
                                        Data Agendamento: {4}
                                        Hora Agendamento: {5} ",
									  this.viewModel.Agendamento.Veiculo.Nome,
									  this.viewModel.Agendamento.Nome,
									  this.viewModel.Agendamento.Phone,
									  this.viewModel.Agendamento.Email,
									  this.viewModel.Agendamento.DataAgendamento.ToString("dd/MM/yyyy"),
									  this.viewModel.Agendamento.HoraAgendamento), "OK"); */
                }
				
            });


            MessagingCenter.Subscribe<Agendamento>(this,"SucessoAgendamento",
                                                   (obj) => {
                DisplayAlert("Agendamento","Agendamento salvo com sucesso","Ok"); 
            });

            MessagingCenter.Subscribe<ArgumentException>(this,"FalhaAgendamento",(obj) => {
                DisplayAlert("Agendamento", "Falha ao agendar o test drive, verifique os dados e tente novamente mais tarde", "Ok");
			});
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Agendamento>(this,"Agendamento");

            MessagingCenter.Unsubscribe<Agendamento>(this,"SucessoAgendamento");
            MessagingCenter.Unsubscribe<ArgumentException>(this, "FalhaAgendamento");

        }

    }
}
