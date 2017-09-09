using System;
namespace TestDrive.Models
{
    public class Agendamento
    {

		public string Nome { get; set; }
		public string Phone { get; set; }
		public string Email { get; set; }
		public Models.Veiculo Veiculo { get; set; }

		private DateTime dataAgendamento = DateTime.Today;
		public DateTime DataAgendamento
		{
			get
			{
				return dataAgendamento;
			}
			set
			{
				dataAgendamento = value;
			}
		}

		private TimeSpan horaAgendamento;
		public TimeSpan HoraAgendamento
		{
			get
			{
				return this.horaAgendamento;
			}
			set
			{
				this.horaAgendamento = value;
			}
		}

        public Agendamento()
        {
            this.Veiculo = new Veiculo();
        }
    }
}
