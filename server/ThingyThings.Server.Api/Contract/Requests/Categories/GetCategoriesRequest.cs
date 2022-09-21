using Microsoft.AspNetCore.Mvc;
using ThingyThings.Server.Api.Handlers.Attributes;
using ThingyThings.Server.Api.Types;

namespace ThingyThings.Server.Api.Contract.Requests.Categories;

[GetEndpoint("categories")]
public class GetCategoriesRequest : HttpRequest
{
    [FromQuery]
    public CategoryType? Type { get; set; }
}
