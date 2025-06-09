namespace SafeGuardAPI.Exceptions
{
    public class EstacaoIdInvalidoException : Exception
    {
        public EstacaoIdInvalidoException()
            : base("O ID da estação não pode ser zero.") { }

        public EstacaoIdInvalidoException(string message)
            : base(message) { }

        public EstacaoIdInvalidoException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
