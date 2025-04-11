using Freelando.Dados;
using Freelando.Modelo;
using Microsoft.EntityFrameworkCore;
using Freelando.Api.Converters;
using Microsoft.AspNetCore.Mvc;

namespace Freelando.Api.Endpoints;

public static class EspecialidadeExtension
{
    public static void AddEndPointEspecialidade(this WebApplication app)
    {
        app.MapGet("/especialidades", async ([FromServices] EspecialidadeConverter converter, [FromServices] FreelandoContext contexto) =>
        {
            var especialidades = converter.EntityListToResponseList(contexto.Especialidades.AsNoTracking().ToList());
            return Results.Ok(await Task.FromResult(especialidades));
        }).WithTags("Especialidade").WithOpenApi();
    }
}

