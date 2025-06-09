namespace SafeGuardAPI.Exceptions
{
    public class StatusEstacaoInvalidoException : Exception
    {
        public StatusEstacaoInvalidoException()
            : base("O status da estação deve ser 'Ativa' ou 'Inativa'.") { }

        public StatusEstacaoInvalidoException(string message)
            : base(message) { }

        public StatusEstacaoInvalidoException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
