namespace IBGE.CNAE.Api.Services;

public interface ICnaeService
{
    Task<IEnumerable<Cnae>> GetAllAsync();
    string GetFilePath();
}
