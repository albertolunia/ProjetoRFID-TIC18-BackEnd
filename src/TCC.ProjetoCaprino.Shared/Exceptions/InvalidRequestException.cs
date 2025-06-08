using TCC.ProjetoCaprino.Shared.Enums;

namespace TCC.ProjetoCaprino.Shared.Exceptions;
public class InvalidRequestExeption : ExceptionApplication
{
    public InvalidRequestExeption(IDictionary<string, string[]> errors)
        : base(RegisteredErrors.InvalidData) =>
        Errors = errors.Select(e => $"{e.Key}: {string.Join(", ", e.Value)}");

    public IEnumerable<string> Errors { get; }
}
