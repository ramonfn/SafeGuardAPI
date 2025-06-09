namespace SafeGuardAPI.Exceptions
{
    public class NomeEstacaoObrigatorioException : Exception
    {
        public NomeEstacaoObrigatorioException()
            : base("O nome da estação é obrigatório.") { }

        public NomeEstacaoObrigatorioException(string message)
            : base(message) { }

        public NomeEstacaoObrigatorioException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
