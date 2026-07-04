using  System.ComponentModel.DataAnnotations; 
namespace Phones.Services;

public static class ValidationHelper
{
    public static IResult? Validate<T>(T model)
    {
        var validationResults = new List<ValidationResult>();
        var validationContext = new ValidationContext(model!);

        var isValid = Validator.TryValidateObject(
            model!,
            validationContext,
            validationResults,
            validateAllProperties: true
            );

        if (isValid) return null;
        
        return Results.BadRequest(validationResults.Select(x => x.ErrorMessage));
    }
}