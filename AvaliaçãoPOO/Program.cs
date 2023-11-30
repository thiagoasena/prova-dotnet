﻿using System;
using System.Collections.Generic;
using System.Security.Cryptography;

class Pessoa
{
    public string Nome { get; set; }
    public DateTime DataNascimento { get; set; }
    public string CPF { get; set; }

    public Pessoa (string Nome, DateTime DataNascimento, string CPF)
    {
        Nome = Nome; 
        DataNascimento = DataNascimento;
        CPF = ValidarCPF(cpf) ? CPF : throw new ArgumentException("CPF");
    }

    private bool ValidarCPF (string cpf)
    {
        if (String.IsNullOrWhiteSpace(cpf))
        return false;   

        cpf = cpf.Replace(".", "").Replace("-", "");

        if (cpf.Length != 11)
        return false;

        if(!cpf.All(char.IsDigit))
        return false;
    }
}