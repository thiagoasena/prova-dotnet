using System;
using System.Collections.Generic;
using System.Linq;

class Pessoa
{
    public string nome { get; set; }
    public DateTime dataNascimento { get; set; }
    public string CPF { get; set; }

    public Pessoa(string nome, DateTime dataNascimento, string cpf)
    {
        nome = nome;
        dataNascimento = dataNascimento;
        CPF = ValidarCPF(cpf) ? cpf : throw new ArgumentException("CPF");
    }

    private bool ValidarCPF(string cpf)
    {
        if (string.IsNullOrWhiteSpace(cpf) || cpf.Length != 11 || !cpf.All(char.IsDigit))
        {
            return false;
        }

    }

    class Advogado : Pessoa
    {
        public string CNA { get; set; }

        public Advogado(string nome, DateTime dataNascimento, string cpf, string cna)
        : base(nome, dataNascimento, cpf)
        {
            CNA = ValidarCNA(cna) ? cna : throw new ArgumentException("CNA INVALIDO");
        }

        private bool ValidarCNA(string cna)
        {
            return !string.IsNullOrWhiteSpace(cna) && cna.Length >= 6;
        }
    }

    class Cliente : Pessoa
    {
        public string estadoCivil { get; set; }
        public string profissao { get; set; }

        public Cliente(string nome, DateTime dataNascimento, string CPF, string estadoCivil, string profissao)
             : base(nome, dataNascimento, CPF)
        {
            estadoCivil = estadoCivil;
            profissao = profissao;
        }
    }

    class Escritorio
    {
        public List<Advogado> Advogados { get; set; }

        public List<Cliente> Clientes { get; set; }

        public Escritorio()
        {
            Advogados = new List<Advogado>();
            Clientes = new List<Cliente>();
        }

        public void adicionaAdvogado(Advogado advogado)
        {
            if (!Advogados.Any(a => a.CPF == advogado.CPF) && !Advogados.Any(a => a.CNA == advogado.CNA))

            {
                Advogados.Add(advogado);
            }
        }

        public void adicionaCliente(Cliente cliente)
        {
            if (!Clientes.Any(c => c.CPF == cliente.CPF))
            {
                Clientes.Add(cliente);
            }
        }


    }

    class Relatorio
    {
        public static List<Advogado> AdvogadosEntreIdades(List<Advogado> advogados, int idadeMin, int idadeMx)
        {
            DateTime dataAtual = DateTime.Now;
            return advogados.Where(a => (dataAtual - a.dataNascimento).Days/365 >= idadeMin && (dataAtual - a.dataNascimento).Days/ 365 <= idadeMx).ToList();
        }
    }





}
