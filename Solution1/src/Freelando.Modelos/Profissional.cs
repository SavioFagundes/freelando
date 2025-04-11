﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freelando.Modelo;
public class Profissional
{
    public Profissional()
     {
     }
 
     public Profissional(Guid id, string? nome, string? cpf, string? email, string? telefone)
     {
         Id = id;
         Nome = nome;
         Cpf = cpf;
         Email = email;
         Telefone = telefone;
     }
    public Guid Id { get; set; }
    public string? Nome { get; set; }
    public string? Cpf { get; set; }
    public string? Email { get; set; }
    public string? Telefone { get; set; }

}
