using SafeGuardAPI.Exceptions;
using SafeGuardAPI.Models;

namespace SafeGuardAPI.Validations
{
    public static class EstacaoValidation
    {
        public static void ValidadeEstacao(Estacao estacao)
        {
            if (string.IsNullOrEmpty(estacao.Nome))
            {
                throw new NomeEstacaoObrigatorioException();
            }

            if (estacao.Status != "Ativa" && estacao.Status != "Inativa")
            {
                throw new StatusEstacaoInvalidoException();
            }
        }
    }
}
