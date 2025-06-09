namespace SafeGuardAPI.Exceptions
{
    public class MensagemAlertaObrigatoriaException : Exception
    {
        public MensagemAlertaObrigatoriaException()
            : base("A mensagem do alerta é obrigatória.") { }

        public MensagemAlertaObrigatoriaException(string message)
            : base(message) { }

        public MensagemAlertaObrigatoriaException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
