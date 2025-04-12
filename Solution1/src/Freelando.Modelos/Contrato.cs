using System;
using Freelando.Modelos;
namespace Freelando.Modelos;
public class Contrato
{
    public Contrato()
    {
    }

    public Contrato(Guid id, double valor, Vigencia vigencia, Servico? servico, Guid profissionalId)
    {
        Id = id;
        Valor = valor;
        Vigencia = vigencia;
        Servico = servico;
        ProfissionalId = profissionalId;
    }
    public Guid Id { get; set; }
    public double Valor { get; set; }
    public Vigencia? Vigencia { get; set; }
    public Servico? Servico { get; set; }
    public Guid ServicoId { get; set; }
    public Guid ProfissionalId { get; set; }
    public Profissional? Profissional { get; set; }
}