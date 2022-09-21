using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ThingyThings.Server.Api.Contract.Requests.Categories;
using ThingyThings.Server.Api.Services;

namespace ThingyThings.Server.Api.Handlers.CategoryHandlers;

public class GetCategoriesHandler : IRequestHandler<GetCategoriesRequest, IResult>
{
    private readonly ICategoryService _service;

    public GetCategoriesHandler(ICategoryService service)
    {
        _service = service;
    }

    public async Task<IResult> Handle(GetCategoriesRequest request, CancellationToken cancellationToken)
    {
        var categories = await _service.GetCategories(request.Type, cancellationToken);
        return Results.Ok(categories);
    }
}
