using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Freelando.Dados;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Freelando.Api.Responses;

namespace Freelando.Api.Endpoints;

public static class RelatorioExtension
{
    public static void AddEndPointRelatorio(this WebApplication app)
    {
        app.MapGet("/relatorios/precoContrato", async ([FromServices] FreelandoContext contexto) =>
         {
             var consulta = contexto.Contratos.FromSql($"SELECT * FROM dbo.TB_Contratos WHERE TB_Contratos.Valor > 1000").ToList();
             return consulta;
         }).WithTags("Relatórios").WithOpenApi();

         app.MapGet("/relatorios/NomeCliente", async ([FromServices] FreelandoContext contexto, string NomeCliente) =>
         {
             var consulta = contexto.Database.SqlQueryRaw<ClienteProjetoResponse>($"SELECT dbo.TB_Clientes.ID_Cliente, dbo.TB_Clientes.Nome, dbo.TB_Clientes.Email, dbo.TB_Projetos.Titulo,dbo.TB_Projetos.ID_Projeto, dbo.TB_Projetos.DS_Projeto, dbo.TB_Projetos.Status FROM dbo.TB_Clientes INNER JOIN dbo.TB_Projetos ON dbo.TB_Clientes.ID_Cliente = dbo.TB_Projetos.ID_Cliente WHERE dbo.TB_Clientes.Nome like '%{NomeCliente}%'").ToList();
             return consulta;
         }).WithTags("Relatórios").WithOpenApi();
         app.MapGet("/relatorios/precoContratoMenor", async ([FromServices] FreelandoContext contexto) =>
         {
             var consulta = contexto.Contratos.FromSql($"SELECT * FROM dbo.TB_Contratos WHERE TB_Contratos.Valor < 1000").ToList();
             return consulta;
         }).WithTags("Relatórios").WithOpenApi();
        app.MapGet("/relatorios/NomeCpf", async ([FromServices] FreelandoContext contexto, string NomeCpf) =>
         {
             var consulta = contexto.Database.SqlQueryRaw<ClienteProjetoResponse>($"SELECT dbo.TB_Clientes.ID_Cliente, dbo.TB_Clientes.Nome, dbo.TB_Clientes.Email, dbo.TB_Projetos.Titulo,dbo.TB_Projetos.ID_Projeto, dbo.TB_Clientes.CPF,dbo.TB_Projetos.DS_Projeto, dbo.TB_Projetos.Status FROM dbo.TB_Clientes INNER JOIN dbo.TB_Projetos ON dbo.TB_Clientes.ID_Cliente = dbo.TB_Projetos.ID_Cliente WHERE dbo.TB_Clientes.CPF like '%{NomeCpf}%'").ToList();
             return consulta;
         }).WithTags("Relatórios").WithOpenApi();
    }
    
}
