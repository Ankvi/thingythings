namespace ThingyThings.Server.Api.Handlers.Attributes;

public interface IEndpointAttribute
{
    public string Template { get; }
}