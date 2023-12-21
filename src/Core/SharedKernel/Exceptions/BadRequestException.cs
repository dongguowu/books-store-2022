using System.Text;
using FluentValidation.Results;

namespace SharedKernel.Exceptions;

public class BadRequestException : Exception
{
    public BadRequestException(string message) : base($"Bad incoming request: {message}") { }

    public BadRequestException(string message, ValidationResult validationResult)
        : base(BuildErrorMessage(message, validationResult))
    {
    }

    private static string BuildErrorMessage(string message, ValidationResult validationResult)
    {
        var sb = new StringBuilder($"{message}: ");
        foreach (var error in validationResult.Errors)
        {
            sb.Append(error.ErrorMessage + "; ");
        }

        return sb.ToString();
    }
}
