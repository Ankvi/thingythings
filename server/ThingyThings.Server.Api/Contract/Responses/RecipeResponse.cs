using Microsoft.AspNetCore.Http.Metadata;
using ThingyThings.Server.Api.Contract.Dtos;

namespace ThingyThings.Server.Api.Contract.Responses;

public class RecipeResponse : BaseResponse<RecipeResponse>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public IEnumerable<RecipeIngredient> Ingredients { get; set; }

    public IEnumerable<string> Steps { get; set; }
}