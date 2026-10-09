namespace MyRecipeBook.Exceptions.ExceptionsBase;

public class ErrorOnValidationExceptios : MyRecipebookExceptions
{
    private readonly List<string> _errors;
    public IList<string> ErrorMenssages { get; set; }

    public ErrorOnValidationExceptios(List<string> errorMensasges) 
    {
        _errors = errorMensasges;
    }

    public List<string> GetErrorMensagens() => _errors;
}
