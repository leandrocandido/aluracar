﻿using System;
using System.Collections.Generic;

namespace TestDrive.Models
{
    public class ListagemVeiculos
    {
        public List<Veiculo> Veiculos = new List<Veiculo>();

        public ListagemVeiculos()
        {
			this.Veiculos = new List<Veiculo>
			{
				new Veiculo { Nome = "Azera V6", Preco = 60000 },
				new Veiculo { Nome = "Fiesta 2.0", Preco = 50000 },
				new Veiculo { Nome = "HB20 S", Preco = 40000},
                new Veiculo { Nome = "Hilux 4x4", Preco = 90000}
			};
        }
    }
}
