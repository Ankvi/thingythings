using MediatR;
using ThingyThings.Server.Api.Contract.Requests.Ingredients;
using ThingyThings.Server.Api.Contract.Responses;
using ThingyThings.Server.Api.Mappers;
using ThingyThings.Server.Api.Models.Recipes;
using ThingyThings.Server.Api.Services;

namespace ThingyThings.Server.Api.Handlers.IngredientHandlers;

public class AddIngredientHandler : IRequestHandler<AddIngredientRequest, IResult>
{
    private readonly IIngredientService _service;
    private readonly IMapper<AddIngredientRequest, Ingredient> _requestMapper;
    private readonly IMapper<Ingredient, IngredientResponse> _responseMapper;

    public AddIngredientHandler(
        IIngredientService service,
        IMapper<AddIngredientRequest, Ingredient> requestMapper,
        IMapper<Ingredient, IngredientResponse> responseMapper)
    {
        _service = service;
        _requestMapper = requestMapper;
        _responseMapper = responseMapper;
    }
    
    public async Task<IResult> Handle(AddIngredientRequest request, CancellationToken cancellationToken)
    {
        var input = _requestMapper.Map(request);
        var created = await _service.AddIngredient(input, cancellationToken);
        var response = _responseMapper.Map(created);
        return Results.Created($"ingredients/{response.Id}", response);
    }
}