﻿﻿using Freelando.Api.Converters;
 using Freelando.Dados;
 using Microsoft.AspNetCore.Mvc;
 using Microsoft.EntityFrameworkCore;
 using Freelando.Api.Requests;

 namespace Freelando.Api.Endpoints;
 
 public static class ServicoExtensions
 {
     public static void AddEndPointServico(this WebApplication app)
     {
         app.MapGet("/servicos", async ([FromServices] ServicoConverter converter, [FromServices] FreelandoContext contexto) =>
         {
             var servico = converter.EntityListToResponseList(contexto.Servicos.ToList());
             var entries = contexto.ChangeTracker.Entries();
             return Results.Ok(await Task.FromResult(servico));
         }).WithTags("Servicos").WithOpenApi();

         app.MapPost("/servico", async ([FromServices] ServicoConverter converter, [FromServices] FreelandoContext contexto, ServicoRequest servicoRequest) =>
         {
             var servico = converter.RequestToEntity(servicoRequest);
             await contexto.Servicos.AddAsync(servico);
             await contexto.SaveChangesAsync();
             return Results.Created($"/servico/{servico.Id}", servico);
         }).WithTags("Servicos").WithOpenApi();

         app.MapPut("/servico/{id}", async ([FromServices] ServicoConverter converter, [FromServices] FreelandoContext contexto, ServicoRequest servicoRequest, Guid id) =>
         {
             var servico = await contexto.Servicos.FindAsync(id);
             if (servico == null)
             {
                 return Results.NotFound();
             }
             var servicoAtualizado = converter.RequestToEntity(servicoRequest);
             servico.Titulo = servicoAtualizado.Titulo;
             servico.Descricao = servicoAtualizado.Descricao;
             servico.Status = servicoAtualizado.Status;
            await contexto.SaveChangesAsync();
             return Results.Ok(servico);
         }).WithTags("Servicos").WithOpenApi();

         app.MapDelete("/servico/{id}", async ([FromServices] ServicoConverter converter, [FromServices] FreelandoContext contexto, Guid id) =>
         {
             var servico = await contexto.Servicos.FindAsync(id);
             if (servico == null)
             {
                 return Results.NotFound();
             }
             contexto.Servicos.Remove(servico);
             await contexto.SaveChangesAsync();
             return Results.NoContent();

         }).WithTags("Servicos").WithOpenApi();
     }
 }