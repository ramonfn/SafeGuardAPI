using SafeGuardAPI.Exceptions;
using SafeGuardAPI.Models;

namespace SafeGuardAPI.Validations
{
    public static class AlertaValidation
    {
        public static void ValidadeAlerta(Alerta alerta)
        {
            if (string.IsNullOrEmpty(alerta.Mensagem))
            {
                throw new MensagemAlertaObrigatoriaException();
            }

            if (alerta.RiscoId == 0)
            {
                throw new RiscoIdInvalidoException();
            }
        }
    }
}
