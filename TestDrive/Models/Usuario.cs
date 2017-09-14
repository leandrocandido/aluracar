﻿using System;
namespace TestDrive.Models
{
    public class Usuario
    {
        public string nome { get; set; }
        public string senha { get; set; }
        public string email { get; set; }
        public int id { get; set; }
        public string dataNascimento { get; set; }
        public string telefone { get; set; }

        public Usuario()
        {
        }
    }

    public class ResultadoLogin
    {
        public Usuario usuario
        {
            get;
            set;
        }
    }
}
