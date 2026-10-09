namespace MyRecipeBook.Communication.Response;

public class ResponseErrorJson
{
    public IList<string> Errors { get; private set; }

    public ResponseErrorJson(IList<string> errorMessage) => Errors = errorMessage;

    public ResponseErrorJson(string errorMessage) => Errors = [errorMessage];

}
