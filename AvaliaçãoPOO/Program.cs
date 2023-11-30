using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;

class Pessoa
{
    public string Nome { get; set; }
    public DateTime DataNascimento { get; set; }
    public string CPF { get; set; }

    public Pessoa (string Nome, DateTime DataNascimento, string cpf)
    {
        Nome = Nome; 
        DataNascimento = DataNascimento;
        CPF = ValidarCPF(cpf) ? cpf : throw new ArgumentException("CPF");
    }

    private bool ValidarCPF(string cpf)
    {
        if (String.IsNullOrWhiteSpace(cpf))
        return false;   

        cpf = cpf.Replace(".", "").Replace("-", "");

        if (cpf.Length != 11)
        return false;

        if(!cpf.All(char.IsDigit))
        return false;
    }

    class Advogado : Pessoa {
        public string CNA {get; set;}

        public Advogado(string nome, DateTime dataNascimento, string cpf, string cna)
        : base(nome, dataNascimento, cpf)
        {
            CNA = ValidarCNA(cna) ? cna : throw new ArgumentException("CNA INVALIDO");
        }

        private bool ValidarCNA(string cna){

        }
    }
}
