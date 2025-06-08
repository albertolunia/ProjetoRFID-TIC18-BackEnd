using TCC.ProjetoCaprino.Shared.Enums;

namespace TCC.ProjetoCaprino.Shared.Exceptions;
public class NoResultException : ExceptionApplication
{
    public NoResultException() : 
        base(RegisteredErrors.NoResults)
    {
    }
}