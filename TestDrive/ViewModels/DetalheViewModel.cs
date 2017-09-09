using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TestDrive.Models;

namespace TestDrive.ViewModels
{
    public class DetalheViewModel : BaseViewModel
    {

		public Models.Veiculo Veiculo { get; set; }


		public bool TemFreioABS
		{
			get
			{
				return Veiculo.TemFreioABS;
			}
			set
			{
				Veiculo.TemFreioABS = value;
				OnPropertyChanged();
				OnPropertyChanged(nameof(ValorTotal));
				/*if (temFreioABS)
                    DisplayAlert("Freio ABS", "Ligado!", "Ok");
                else
                    DisplayAlert("Freio ABS", "Desligado!", "Ok");*/
			}
		}

		public bool TemArCondicionado
		{
			get
			{
				return Veiculo.TemArCondicionado;
			}
			set
			{
				Veiculo.TemArCondicionado = value;
				OnPropertyChanged();
				OnPropertyChanged(nameof(ValorTotal));
			}
		}

		public bool TemMP3Player
		{
			get
			{
				return Veiculo.TemMp3player;
			}
			set
			{
				Veiculo.TemMp3player = value;
				OnPropertyChanged();
				OnPropertyChanged(nameof(ValorTotal));
			}
		}


		public string ValorTotal
		{
			get { return Veiculo.PrecoTotalFormatado; }

		}

		public string TextoFreioABS
		{
			get
			{
				return string.Format("Freio ABS - {0}", Veiculo.FREIO_ABS);
			}
		}

		public string TextoArcondicionado
		{
			get
			{
				return string.Format("Ar Condicionado - {0}", Veiculo.AR_CONDICIONADO);
			}
		}

		public string TextoMp3Player
		{
			get
			{
				return string.Format("Mp3 Player - {0}", Veiculo.MP3_PLAYER);
			}
		}

        public DetalheViewModel(Veiculo veiculo)
        {
            this.Veiculo = veiculo;
        }

 /*       public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged( [CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(name));
        }
 */
    }
}
