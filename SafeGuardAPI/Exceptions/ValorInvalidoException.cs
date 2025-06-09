namespace SafeGuardAPI.Exceptions
{
    public class ValorInvalidoException : Exception
    {
        public ValorInvalidoException()
            : base("O valor não pode ser negativo.") { }

        public ValorInvalidoException(string message)
            : base(message) { }

        public ValorInvalidoException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
