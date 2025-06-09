namespace SafeGuardAPI.Exceptions
{
    public class NivelForaDoRangeException : Exception
    {
        public NivelForaDoRangeException(int min, int max)
            : base($"O nível deve estar entre {min} e {max}.") { }

        public NivelForaDoRangeException(string message)
            : base(message) { }

        public NivelForaDoRangeException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
