﻿using Freelando.Api.Converters;
 using Freelando.Dados;
 using Microsoft.AspNetCore.Mvc;
 using Microsoft.EntityFrameworkCore;
 using Freelando.Api.Requests;
 namespace Freelando.Api.Endpoints;
 
 public static class ProfissionalExtension
 {
     public static void AddEndPointProfissional(this WebApplication app)
     {
         app.MapGet("/profissionais", async ([FromServices] ProfissionalConverter converter, [FromServices] FreelandoContext contexto) =>
         {
            var profissional = converter.EntityListToResponseList(contexto.Profissionais.Include(e => e.Especialidades).ToList());
             var entries = contexto.ChangeTracker.Entries();
             return Results.Ok(await Task.FromResult(profissional));
         }).WithTags("Profissional").WithOpenApi();

         app.MapPost("/profissional", async ([FromServices] ProfissionalConverter converter, [FromServices] FreelandoContext contexto, ProfissionalRequest profissionalRequest) =>
         {
             var profissional = converter.RequestToEntity(profissionalRequest);
             await contexto.Profissionais.AddAsync(profissional);
             await contexto.SaveChangesAsync();
             return Results.Created($"/profissional/{profissional.Id}", profissional);
         }).WithTags("Profissional").WithOpenApi();
     }
 }