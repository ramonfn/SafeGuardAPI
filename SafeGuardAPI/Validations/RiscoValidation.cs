using SafeGuardAPI.Exceptions;
using SafeGuardAPI.Models;

namespace SafeGuardAPI.Validations
{
    public static class RiscoValidation
    {
        public static void ValidadeRisco(Risco risco)
        {
            if (risco.Nivel < 1 || risco.Nivel > 5)
            {
                throw new NivelForaDoRangeException(1, 5);
            }

            if (string.IsNullOrEmpty(risco.Descricao))
            {
                throw new DescricaoObrigatoriaException();
            }
        }
    }
}
