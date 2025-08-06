namespace IBGE.CNAE.Api.Services;

public class CnaeService : ICnaeService
{
    public async Task<IEnumerable<Cnae>> ExcelReader(string filePath)
    {
        var cnaes = new List<Cnae>();

        await Task.Run(() =>
        {
            using var workBook = new XLWorkbook(filePath);
            var workSheet = workBook.Worksheet(1); // primeira aba
            var rangeUsed = workSheet.RangeUsed();
            
            if (rangeUsed == null)
                return;

            var rows = rangeUsed.RowsUsed(); // ignora linhas vazias

            var secao = string.Empty;

            foreach (var row in rows.Skip(3)) // ignora linhas de cabeçalho
            {
                secao = !string.IsNullOrEmpty(row.Cell(1).GetString()) ? row.Cell(1).GetString() : secao;

                if (string.IsNullOrEmpty(row.Cell(5).GetString())) // Ignora as células que não tem a subclasse preenchida
                    continue;

                var divisao = row.Cell(2).GetString();
                var grupo = row.Cell(3).GetString();
                var classe = row.Cell(4).GetString();
                var subclasse = row.Cell(5).GetString();
                var descricao = row.Cell(6).GetString();

                var cnae = new Cnae(secao, divisao, grupo, classe, subclasse, descricao);

                cnae.GetAnotherFieldsBySubclasse();
                cnae.RemoveMaskToSubclasseField();

                cnaes.Add(cnae);
            }
        });

        return cnaes;
    }
}
