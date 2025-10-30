namespace Certe.Result.ErrorDefinitions;

public sealed class Errors
{
	public static Error InternalServerError(string message, string? detail = null)
		=> new Error("Error.InternalServerError", message, detail);

	public static Error DomainError(string message, string? detail = null)
		=> new Error("Error.DomainError", message, detail);

	public static Error ValidationError(string message, string? detail = null)
		=> new Error("Error.ValidationError", message, detail);

	public static Error InvalidArgumentError(string message, string? detail = null)
		=> new Error("Error.InvalidArgumentError", message, detail);

	public static Error DependencyError(string message, string? detail = null)
		=> new Error("Error.DependencyError", message, detail);

	public static Error ConfigurationError(string message, string? detail = null)
		=> new Error("Error.ConfigurationError", message, detail);

	public static Error ConcurrencyError(string message, string? detail = null)
		=> new Error("Error.ConcurrencyError", message, detail);

	public static Error ResourceLockedError(string message, string? detail = null)
		=> new Error("Error.ResourceLockedError", message, detail);

	public static Error SerializationError(string message, string? detail = null)
		=> new Error("Error.SerializationError", message, detail);

	public static Error DeserializationError(string message, string? detail = null)
		=> new Error("Error.DeserializationError", message, detail);

	public static Error MappingError(string message, string? detail = null)
		=> new Error("Error.MappingError", message, detail);

	public static Error IntegrationError(string message, string? detail = null)
		=> new Error("Error.IntegrationError", message, detail);

	public static Error InfrastructureError(string message, string? detail = null)
		=> new Error("Error.InfrastructureError", message, detail);

	public static Error BusinessRuleError(string message, string? detail = null)
		=> new Error("Error.BusinessRuleError", message, detail);

	public static Error PreconditionFailedError(string message, string? detail = null)
		=> new Error("Error.PreconditionFailedError", message, detail);

	public static Error UnexpectedError(string message, string? detail = null)
		=> new Error("Error.UnexpectedError", message, detail);
}
