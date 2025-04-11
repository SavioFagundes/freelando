using System;
using Freelando.Modelos;
namespace Freelando.Modelo;
public class Contrato
{
    public Contrato()
    {
    }

    public Contrato(Guid id, double valor, Vigencia vigencia)
    {
        Id = id;
        Valor = valor;
        Vigencia = vigencia;
    }
    public Guid Id { get; set; }
    public double Valor { get; set; }
    public Vigencia? Vigencia { get; set; }

}