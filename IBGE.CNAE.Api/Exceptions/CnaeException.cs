namespace IBGE.CNAE.Api.Exceptions;

public class CnaeException : Exception
{
    public CnaeException(string message = "An error occurred while processing CNAE data.") : base(message) { }
}
