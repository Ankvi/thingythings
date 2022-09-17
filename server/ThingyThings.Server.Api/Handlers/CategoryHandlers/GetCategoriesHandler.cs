using MediatR;
using Microsoft.AspNetCore.Mvc;
using ThingyThings.Server.Api.Contract.Requests.Categories;

namespace ThingyThings.Server.Api.Handlers.CategoryHandlers;

public class GetCategoriesHandler : IRequestHandler<GetCategoriesRequest, IResult>
{
    
    public Task<IResult> Handle(GetCategoriesRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}