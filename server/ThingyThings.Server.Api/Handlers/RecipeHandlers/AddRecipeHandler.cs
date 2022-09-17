using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using ThingyThings.Server.Api.Contract.Requests;
using ThingyThings.Server.Api.Contract.Requests.Recipes;
using ThingyThings.Server.Api.Contract.Responses;
using ThingyThings.Server.Api.Mappers;
using ThingyThings.Server.Api.Models.Recipes;
using ThingyThings.Server.Api.Services;

namespace ThingyThings.Server.Api.Handlers.RecipeHandlers;

public class AddRecipeHandler : IRequestHandler<AddRecipeRequest, IResult>
{
    private readonly IRecipeService _service;
    private readonly IMapper<AddRecipeRequest, Recipe> _requestMapper;
    private readonly IMapper<Recipe, RecipeResponse> _responseMapper;

    public AddRecipeHandler(
        IRecipeService service,
        IMapper<AddRecipeRequest, Recipe> requestMapper,
        IMapper<Recipe, RecipeResponse> responseMapper)
    {
        _service = service;
        _requestMapper = requestMapper;
        _responseMapper = responseMapper;
    }

    public async Task<IResult> Handle(AddRecipeRequest request, CancellationToken cancellationToken)
    {
        var recipe = _requestMapper.Map(request);
        var addedRecipe = await _service.AddRecipe(recipe, cancellationToken);
        var response = _responseMapper.Map(addedRecipe);
        return Results.Created($"recipes/{addedRecipe.Id}", response);
    }
}
