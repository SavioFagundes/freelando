namespace Freelando.Modelos;
public class Cliente
{
    public Cliente()
     {
     }
 
     public Cliente(Guid id, string nome, string cpf, string email, string telefone, ICollection<Projeto>? projetos)
     {
         this.Id = id;
         this.Nome = nome;
         this.Cpf = cpf;
         this.Email = email;
         this.Telefone = telefone;
         this.Projetos = projetos ?? new List<Projeto>();
     }
    public Guid Id { get; set; }
    public string? Nome { get; set; }
    public string? Cpf { get; set; }
    public string? Email { get; set; }
    public string? Telefone { get; set; }
    public ICollection<Projeto>? Projetos { get; set; }
}
