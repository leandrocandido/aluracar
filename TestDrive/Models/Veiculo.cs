using System;
namespace TestDrive.Models
{
	public class Veiculo
	{
		public const int FREIO_ABS = 800;
		public const int AR_CONDICIONADO = 1000;
		public const int MP3_PLAYER = 500;

		public string Nome { get; set; }
		public decimal Preco { get; set; }
		public string PrecoFormatado
		{
			get { return string.Format("R$ {0}", Preco); }
		}


        public bool TemMp3player { get; set; }
        public bool TemFreioABS { get; set; }
        public bool TemArCondicionado { get; set; }

        public string PrecoTotalFormatado
        {
            get{ return string.Format("R$ {0}", this.Preco + (TemFreioABS ? Veiculo.FREIO_ABS : 0) + (TemArCondicionado ? Veiculo.AR_CONDICIONADO : 0) + (TemMp3player ? Veiculo.MP3_PLAYER : 0)); }
        }

	}
}
