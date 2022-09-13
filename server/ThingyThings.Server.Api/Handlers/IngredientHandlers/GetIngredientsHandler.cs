using MediatR;
using ThingyThings.Server.Api.Contract.Requests.Ingredients;
using ThingyThings.Server.Api.Contract.Responses;
using ThingyThings.Server.Api.Mappers;
using ThingyThings.Server.Api.Models.Recipes;
using ThingyThings.Server.Api.Services;

namespace ThingyThings.Server.Api.Handlers.IngredientHandlers;

public class GetIngredientsHandler : IRequestHandler<GetIngredientsRequest, IResult>
{
    private readonly IIngredientService _service;
    private readonly IMapper<Ingredient, IngredientResponse> _responseMapper;
    
    public GetIngredientsHandler(
        IIngredientService service,
        IMapper<Ingredient, IngredientResponse> responseMapper)
    {
        _service = service;
        _responseMapper = responseMapper;
    }
    
    public async Task<IResult> Handle(GetIngredientsRequest request, CancellationToken cancellationToken)
    {
        var ingredients = await _service.GetIngredients(cancellationToken);
        return Results.Ok(ingredients.Select(_responseMapper.Map));
    }
}