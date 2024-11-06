namespace MyRecipeBook.Exceptions.ExceptionsBase;

public class ErrorOnValidationExceptios : MyRecipebookExceptions
{
    public List<string> ErrorMensasges { get; set; }

    public ErrorOnValidationExceptios(IList<string> erroMensasges) 
    {
        
    }
}
