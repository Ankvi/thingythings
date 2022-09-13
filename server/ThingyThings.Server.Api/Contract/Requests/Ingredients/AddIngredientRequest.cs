using Microsoft.AspNetCore.Mvc;
using ThingyThings.Server.Api.Handlers.Attributes;

namespace ThingyThings.Server.Api.Contract.Requests.Ingredients;

[PostEndpoint("ingredients")]
public class AddIngredientRequest : HttpRequestWithBody<AddIngredientRequest.RequestBody>
{
    public class RequestBody
    {
        public string Name { get; set; }
    }
}