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
            Func<Especialidade, bool> validarDescricao = especialidade => !string.IsNullOrWhiteSpace(especialidade.Descricao) && char.IsUpper(especialidade.Descricao[0]);
            if(!validarDescricao(especialidade) )
            {
                return Results.BadRequest("A descrição da especialidade deve começar com uma letra maiúscula e não pode ser vazia.");
            }
            await contexto.Especialidades.AddAsync(especialidade);
            await contexto.SaveChangesAsync();
            return Results.Created($"/especialidade/{especialidade.Id}", especialidade);

        }).WithTags("Especialidade").WithOpenApi();

        app.MapPut("/especialidade/{id}", async ([FromServices] EspecialidadeConverter converter, [FromServices] FreelandoContext contexto, EspecialidadeRequest especialidadeRequest, Guid id) =>
        {
            var especialidade = await contexto.Especialidades.FindAsync(id);
            if (especialidade == null)
            {
                return Results.NotFound();
            }
            var especialidadeAtualizada = converter.RequestToEntity(especialidadeRequest);
            especialidade.Descricao = especialidadeAtualizada.Descricao;
            especialidade.Projetos = especialidadeAtualizada.Projetos;
            await contexto.SaveChangesAsync();
            return Results.Ok(especialidade);
        }).WithTags("Especialidade").WithOpenApi();

        // app.MapDelete("/especialidade/{id}", async ([FromServices] EspecialidadeConverter converter, [FromServices] FreelandoContext contexto, Guid id) =>
        // {
        //     var especialidade = await contexto.Especialidades.FindAsync(id);
        //     if (especialidade == null)
        //     {
        //         return Results.NotFound();
        //     }
        //     contexto.Especialidades.Remove(especialidade);
        //     await contexto.SaveChangesAsync();
        //     return Results.NoContent();
        // }).WithTags("Especialidade").WithOpenApi();
        app.MapDelete("/especialidade/{id}", async ([FromServices] EspecialidadeConverter converter, [FromServices] FreelandoContext contexto, Guid id) =>
        {
            using (var transaction = await contexto.Database.BeginTransactionAsync())
            {
                try
                {
                    var especialidade = await contexto.Especialidades.FindAsync(id);
                    if (especialidade == null)
                    {
                        return Results.NotFound();
                    }
                    contexto.Especialidades.Remove(especialidade);
                    await contexto.SaveChangesAsync();
                    transaction.Commit();
                    return Results.NoContent();

                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    return Results.BadRequest(ex.Message);
                }
            }
        }).WithTags("Especialidade").WithOpenApi();
    }
}

