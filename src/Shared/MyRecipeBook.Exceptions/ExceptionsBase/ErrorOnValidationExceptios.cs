namespace MyRecipeBook.Exceptions.ExceptionsBase;

public class ErrorOnValidationExceptios : MyRecipebookExceptions
{
    public IList<string> ErrorMenssages { get; set; }

    public ErrorOnValidationExceptios(IList<string> errorMensasges) 
    {
        ErrorMenssages = errorMensasges;
    }
}
