using Microsoft.AspNetCore.Mvc;
using sql.Data.Repositories;
using sql.Model;

namespace sql.Endpoints
{
    public static class ProductEndpoints
    {
        public static void MapProductEndpoints(this IEndpointRouteBuilder routes)
        {
            // GET /api/Product
            routes.MapGet("/api/Product", async ([FromServices] IProductRepository repo) =>
            {
                return await repo.GetAllAsync();
            })
            .WithName("GetAllProducts");

            // GET /api/Product/{id}
            routes.MapGet("/api/Product/{id}", async (int id, [FromServices] IProductRepository repo) =>
            {
                var product = await repo.GetByIdAsync(id);
                return product is not null ? Results.Ok(product) : Results.NotFound();
            })
            .WithName("GetProductById");

            // POST /api/Product
            routes.MapPost("/api/Product", async (Product product, [FromServices] IProductRepository repo) =>
            {
                await repo.AddAsync(product);
                return Results.Created($"/api/Product/{product.Id}", product);
            })
            .WithName("CreateProduct");

            // PUT /api/Product/{id}
            routes.MapPut("/api/Product/{id}", async (int id, Product updatedProduct, [FromServices] IProductRepository repo) =>
            {
                var existing = await repo.GetByIdAsync(id);
                if (existing is null)
                    return Results.NotFound();

                updatedProduct.Id = existing.Id;
                await repo.UpdateAsync(updatedProduct);
                return Results.Ok(updatedProduct);
            })
            .WithName("UpdateProduct");

            // DELETE /api/Product/{id}
            routes.MapDelete("/api/Product/{id}", async (int id, [FromServices] IProductRepository repo) =>
            {
                var existing = await repo.GetByIdAsync(id);
                if (existing is null)
                    return Results.NotFound();

                await repo.DeleteAsync(id);
                return Results.NoContent();
            })
            .WithName("DeleteProduct");
        }
    }
}