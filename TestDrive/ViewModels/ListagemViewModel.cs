using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TestDrive.Models;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace TestDrive.ViewModels
{
    public class ListagemViewModel : BaseViewModel
    {
        public ObservableCollection<Models.Veiculo> Veiculos { get; set; }
        private Veiculo veiculoSelecionado;
        private const string URL_GET_VEICULOS = "http://aluracar.herokuapp.com";

        private Boolean aguarde;

        public Boolean Aguarde 
        { 
            get { return aguarde; } 
            set 
            { 
                this.aguarde = value; 
                OnPropertyChanged();
            } 
        }


        public Veiculo VeiculoSelecionado 
        {
            get 
            { 
                return veiculoSelecionado; 
            }
            set 
            {
                this.veiculoSelecionado = value;
                if (value != null)
                    MessagingCenter.Send(this.veiculoSelecionado, "VeiculoSelecionado");

            }
        }
        public ListagemViewModel()
        {
            //this.Veiculos = new ListagemVeiculos().Veiculos;
            this.Veiculos = new ObservableCollection<Veiculo>();
        }

        public async Task GetveiculosAsync()
        {
            this.Aguarde = true;
            HttpClient client = new HttpClient();
            string result = await client.GetStringAsync(URL_GET_VEICULOS);

            var lstveiculos =  JsonConvert.DeserializeObject<VeiculoJson[]>(result);

            foreach(VeiculoJson v in lstveiculos)
            {
                this.Veiculos.Add(new Veiculo
                {
                    Nome = v.nome,
                    Preco = v.preco
                });
            }
            this.Aguarde = false;
        }

    }


    public class VeiculoJson
    {
        public string nome { get; set; }
        public int preco { get; set; }
    }
}
