namespace SafeGuardAPI.Exceptions
{
    public class SensorIdInvalidoException : Exception
    {
        public SensorIdInvalidoException()
            : base("O ID do sensor não pode ser zero.") { }

        public SensorIdInvalidoException(string message)
            : base(message) { }

        public SensorIdInvalidoException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
