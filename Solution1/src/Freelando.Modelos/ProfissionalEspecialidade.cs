using System;

namespace Freelando.Modelos;

public class ProfissionalEspecialidade
{
    public Guid ProfissionalId { get; set; }
    public Profissional? Profissional { get; set; }
    
    public Guid EspecialidadeId { get; set; }
    public Especialidade? Especialidade { get; set; }
} 