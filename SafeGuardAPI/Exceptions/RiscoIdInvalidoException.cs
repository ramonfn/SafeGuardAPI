namespace SafeGuardAPI.Exceptions
{
    public class RiscoIdInvalidoException : Exception
    {
        public RiscoIdInvalidoException()
            : base("O ID do risco não pode ser zero.") { }

        public RiscoIdInvalidoException(string message)
            : base(message) { }

        public RiscoIdInvalidoException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
