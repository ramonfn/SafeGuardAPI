namespace SafeGuardAPI.Exceptions
{
    public class TipoSensorObrigatorioException : Exception
    {
        public TipoSensorObrigatorioException()
            : base("O tipo de sensor é obrigatório.") { }

        public TipoSensorObrigatorioException(string message)
            : base(message) { }

        public TipoSensorObrigatorioException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
