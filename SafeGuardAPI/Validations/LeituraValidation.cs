using SafeGuardAPI.Exceptions;
using SafeGuardAPI.Models;

namespace SafeGuardAPI.Validations
{
    public static class LeituraValidation
    {
        public static void ValidadeLeitura(Leitura leitura)
        {
            if (leitura.SensorId == 0)
            {
                throw new SensorIdInvalidoException();
            }

            if (leitura.Valor < 0)
            {
                throw new ValorInvalidoException();
            }
        }
    }
}
