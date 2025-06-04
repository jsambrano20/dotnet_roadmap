using Microsoft.AspNetCore.Mvc;
using no_sql.Data.Repository;
using no_sql.Model;

namespace no_sql.Endpoints
{
    public static class PessoaModelEndpoints
    {
        public static void MapPessoaEndpoints(this IEndpointRouteBuilder routes)
        {
            routes.MapGet("/api/Pessoa", async ([FromServices] IPessoaRepository repo) =>
            {
                return await repo.GetAll();
            })
            .WithName("GetAllPessoas");

        

            routes.MapPut("/api/Pessoa/{id}", async (Guid id, Pessoa pessoa, [FromServices] IPessoaRepository repo) =>
            {
                var personFromDb = await repo.GetOne(id);
                if (personFromDb == null)
                    return Results.NotFound();

                pessoa.Id = personFromDb.Id;
                pessoa.InternalId = personFromDb.InternalId;
                await repo.Update(pessoa);
                return Results.Ok(pessoa);
            })
            .WithName("UpdatePessoa");

            routes.MapPost("/api/Pessoa/", async (Pessoa pessoa, [FromServices] IPessoaRepository repo) =>
            {
                pessoa.Id = await repo.GetNextId();
                await repo.Create(pessoa);

                return Results.Created($"/Pessoas/{pessoa.InternalId}", pessoa);
            })
            .WithName("CreatePessoa");

        }
    }
}
