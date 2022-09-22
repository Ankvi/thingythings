using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using ThingyThings.Server.Api;
using ThingyThings.Server.Api.Configuration;
using ThingyThings.Server.Api.Contract.Dtos;
using ThingyThings.Server.Api.Contract.Requests;
using ThingyThings.Server.Api.Contract.Requests.Ingredients;
using ThingyThings.Server.Api.Contract.Requests.Recipes;
using ThingyThings.Server.Api.Contract.Requests.Users;
using ThingyThings.Server.Api.Contract.Responses;
using ThingyThings.Server.Api.Database;
using ThingyThings.Server.Api.Mappers;
using ThingyThings.Server.Api.Repositories;
using ThingyThings.Server.Api.Services;

DotEnv.Load(".env");

var builder = WebApplication.CreateBuilder(args);

NpgsqlConnection.GlobalTypeMapper.UseJsonNet();

// var config = new ConfigurationBuilder()
//     .SetBasePath(Directory.GetCurrentDirectory())
//     .AddJsonFile("appsettings.json")
//     .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
//     .AddEnvironmentVariables()
//     .Build();


// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var assembly = typeof(Program).Assembly;
builder.Services.AddMediatR(assembly);

builder.Services.AddScoped<IRecipeRepository, RecipeRepository>();
builder.Services.AddScoped<IIngredientRepository, IngredientRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IRecipeService, RecipeService>();
builder.Services.AddScoped<IIngredientService, IngredientService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped(typeof(IMapper<,>), assembly);
builder.Services.AddScoped<IRecipeIngredientMapper, RecipeIngredientMapper>();
builder.Services.AddScoped(typeof(IValidator<>), assembly);

// Postgres
var postgresConfiguration = builder.Configuration.GetSection<PostgresConfiguration>();
if (postgresConfiguration is null)
{
    throw new ArgumentNullException(nameof(postgresConfiguration), "Postgres configuration cannot be empty");
}
builder.Services.AddSingleton(postgresConfiguration!);
builder.Services.AddSingleton<IPostgresConnector, PostgresConnector>();
builder.Services.AddScoped<IPostgresDatabase, PostgresDatabase>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app
    .MapEndpoint<LoginUserRequest>()
    .MapEndpoint<RegisterUserRequest>()
    .MapEndpoint<GetRecipesRequest>()
    .MapEndpoint<AddRecipeRequest>()
    .MapEndpoint<AddIngredientToRecipeRequest>()
    .MapEndpoint<AddIngredientRequest>()
    .MapEndpoint<GetIngredientsRequest>();

app.Run();
