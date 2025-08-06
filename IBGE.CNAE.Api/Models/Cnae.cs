namespace IBGE.CNAE.Api.Models;

public class Cnae
{
    public Cnae(string secao, string divisao, string grupo, string classe, string subclasse, string descricao)
    {
        Secao = secao;
        Divisao = divisao;
        Grupo = grupo;
        Classe = classe;
        Subclasse = subclasse;
        Descricao = descricao;
    }

    public string Secao { get; private set; }
    public string Divisao { get; private set; }
    public string Grupo { get; private set; }
    public string Classe { get; private set; }
    public string Subclasse { get; private set; }
    public string Descricao { get; private set; }

    public void RemoveMaskToSubclasseField()
    {
        Subclasse = Regex.Replace(Subclasse, @"[^\d]", string.Empty);
    }

    public void FillAnotherFieldsBySubclasse()
    {
        Divisao = Subclasse.Substring(0, 2);
        Grupo = Subclasse.Substring(0, 3);
        Classe = Subclasse.Substring(0, 6);
    }
}
