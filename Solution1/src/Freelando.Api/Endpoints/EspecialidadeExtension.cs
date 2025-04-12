using Freelando.Dados;
using Freelando.Modelos;
using Microsoft.EntityFrameworkCore;
using Freelando.Api.Converters;
using Microsoft.AspNetCore.Mvc;
using Freelando.Api.Requests;
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

        app.MapPost("/especialidades", async ([FromServices] EspecialidadeConverter converter, [FromServices] FreelandoContext contexto, EspecialidadeRequest especialidadeRequest) =>
        {
            var especialidade = converter.RequestToEntity(especialidadeRequest);
            await contexto.Especialidades.AddAsync(especialidade);
            await contexto.SaveChangesAsync();
            return Results.Created($"/especialidade/{especialidade.Id}", especialidade);

        }).WithTags("Especialidade").WithOpenApi();
    }
}

