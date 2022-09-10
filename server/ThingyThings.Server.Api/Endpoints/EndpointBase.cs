namespace ThingyThings.Server.Api.Endpoints;

public abstract class EndpointBase
{
    private WebApplication _app;
    private string _path;

    public EndpointBase(WebApplication app, string path)
    {
        _app = app;
        _path = path;
    }

    private string GetPath(string path)
    {
        return $"{_path}/{path}";
    }

    protected void MapGet(string path, Delegate handler)
    {
        _app.MapGet(GetPath(path), handler);
    }
}