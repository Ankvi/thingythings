using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using ThingyThings.Server.Api.Contract.Requests;
using ThingyThings.Server.Api.Services;

namespace ThingyThings.Server.Api.Handlers.RecipeHandlers;

public class AddRecipeHandler : IRequestHandler<AddRecipeRequest, IResult>
{
    private readonly IRecipeService _service;

    public AddRecipeHandler(IRecipeService service)
    {
        _service = service;
    }

    public Task<IResult> Handle(AddRecipeRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
