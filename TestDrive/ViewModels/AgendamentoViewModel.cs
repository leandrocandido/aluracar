using System;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using Newtonsoft.Json;
using TestDrive.Models;
using Xamarin.Forms;

namespace TestDrive.ViewModels
{
    public class AgendamentoViewModel : BaseViewModel
    {

		public Agendamento Agendamento { get; set; }

		public string Nome 
        {
            get 
            { 
                return Agendamento.Nome; 
            } 
            set 
            { 
                Agendamento.Nome = value; 
                OnPropertyChanged();
                ((Command)AgendarCommand).ChangeCanExecute();
            } 
        }

		public string Phone 
        { 
            get 
            { 
                return Agendamento.Phone; 
            } 
            set 
            { 
                Agendamento.Phone = value;
				OnPropertyChanged();
				((Command)AgendarCommand).ChangeCanExecute();
            } 
        }

		public string Email 
        { 
            get 
            { 
                return Agendamento.Email; 
            } 
            set 
            { 
                Agendamento.Email = value;
				OnPropertyChanged();
				((Command)AgendarCommand).ChangeCanExecute();
            } 
        }

		public Models.Veiculo Veiculo { get { return Agendamento.Veiculo; } set { Agendamento.Veiculo = value; } }
        const string URL_POST_AGENDAMENTO = "http://aluracar.kerokuapp.com/salvaragendamento";
                                          
        public ICommand AgendarCommand { get; set; }

		public DateTime DataAgendamento
		{
			get
			{
				return Agendamento.DataAgendamento;
			}
			set
			{
				Agendamento.DataAgendamento = value;
			}
		}

		public TimeSpan HoraAgendamento
		{
			get
			{
				return Agendamento.HoraAgendamento;
			}
			set
			{
				Agendamento.HoraAgendamento = value;
			}
		}


		public AgendamentoViewModel(Veiculo veiculo)
        {
            this.Agendamento = new Agendamento();
            this.Agendamento.Veiculo = veiculo;

            AgendarCommand = new Command(() =>
           {
               MessagingCenter.Send<Agendamento>(this.Agendamento, "Agendamento");
           }, () =>
            {
                return !string.IsNullOrEmpty(this.Nome)
                             && !string.IsNullOrEmpty(this.Email)
                             && !string.IsNullOrEmpty((this.Phone)); 
            });

        }

        public async void SalvarAgendamento()
        {

            HttpClient client = new HttpClient();


            var dataHoraAgendamento = new DateTime(
                DataAgendamento.Year , DataAgendamento.Month , DataAgendamento.Day,
                HoraAgendamento.Hours , HoraAgendamento.Minutes , HoraAgendamento.Seconds
            );

            var json = JsonConvert.SerializeObject(new
            {
                nome = Nome,
                fone = Phone,
                email = Email,
                caro = Veiculo.Nome,
                preco = Veiculo.Preco,
                datagendamento = dataHoraAgendamento

            });

            var conteudo = new StringContent(json, Encoding.UTF8,"application/json");
            var resposta = await client.PostAsync(URL_POST_AGENDAMENTO, conteudo );

            if (resposta.IsSuccessStatusCode)
            {
                MessagingCenter.Send<Agendamento>(this.Agendamento,"SucessoAgendamento");
            }
            else
            {
                MessagingCenter.Send<ArgumentException>(new ArgumentException(), "FalhaAgendamento");
            }
        }
    }
}
