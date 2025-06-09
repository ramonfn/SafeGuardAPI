namespace SafeGuardAPI.Exceptions
{
    public class DescricaoObrigatoriaException : Exception
    {
        public DescricaoObrigatoriaException()
            : base("A descrição é obrigatória.") { }

        public DescricaoObrigatoriaException(string message)
            : base(message) { }

        public DescricaoObrigatoriaException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
