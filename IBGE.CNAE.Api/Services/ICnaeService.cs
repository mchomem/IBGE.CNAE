using IBGE.CNAE.Api.Models;

namespace IBGE.CNAE.Api.Services
{
    public interface ICnaeService
    {
        Task<IEnumerable<Cnae>> ExcelReader(string filePath);
    }
}
