using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freelando.Modelos;
public class Projeto
{
    public Projeto()
     {
 
     }
 
     public Projeto(Guid id, string? titulo, string descricao, StatusProjeto status, Cliente? cliente, ICollection<Especialidade>? especialidades)
     {
         Id = id;
         Titulo = titulo;
         Descricao = descricao;
         Status = status;
         Cliente = cliente;
         Especialidades = especialidades;
     }
    public Guid Id { get; set; }
    public string? Titulo { get; set; }
    public  string? Descricao { get; set; }
    public StatusProjeto Status { get; set; }
    public Cliente? Cliente { get; set; }
    public ICollection<Especialidade>? Especialidades { get; set; }
    public ICollection<ProjetoEspecialidade> ProjetosEspecialidades { get;} = [];
    public Servico Servico { get; set; }
}
