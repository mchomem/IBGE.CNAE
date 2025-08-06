namespace IBGE.CNAE.Api.Services;

public interface ICnaeService
{
    Task<IEnumerable<Cnae>> ExcelReader();
    string GetFilePath();
}
