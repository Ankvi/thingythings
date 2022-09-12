namespace ThingyThings.Server.Api.Mappers;

public interface IMapper<in TIn, out TOut>
{
    TOut Map(TIn input);
}