namespace IBGE.CNAE.Api.Services;

public interface ICnaeService
{
    Task<IEnumerable<Cnae>> GetAllAsync(int? pageNumber, int? size);
    string GetFilePath();
}
