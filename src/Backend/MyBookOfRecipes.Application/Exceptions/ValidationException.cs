using MyBookOfRecipes.Application.Exceptions.Base;

namespace MyBookOfRecipes.Application.Exceptions
{
    public class ValidationException(IList<string> errorMessage) : MyBookOfRecipesException
    {
        public IList<string> ErrorMessage { get; set; } = errorMessage;
    }
}
