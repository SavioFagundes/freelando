﻿using Freelando.Api.Converters;
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
     }
 }