using ThingyThings.Server.Api.Handlers.Attributes;

namespace ThingyThings.Server.Api.Contract.Requests.Categories;

[GetEndpoint("categories")]
public class GetCategoriesRequest : HttpRequest
{
    public string? Type { get; set; }
}