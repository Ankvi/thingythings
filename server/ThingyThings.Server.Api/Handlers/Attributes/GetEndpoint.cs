using System;

namespace ThingyThings.Server.Api.Handlers.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public class GetEndpoint : BaseEndpoint
{
    public GetEndpoint(string template) : base("GET", template)
    {
    }
}