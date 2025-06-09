using SafeGuardAPI.Exceptions;
using SafeGuardAPI.Models;

namespace SafeGuardAPI.Validations
{
    public static class SensorValidation
    {
        public static void ValidadeSensor(Sensor sensor)
        {
            if (string.IsNullOrEmpty(sensor.TipoSensor))
            {
                throw new TipoSensorObrigatorioException();
            }

            if (sensor.EstacaoId == 0)
            {
                throw new EstacaoIdInvalidoException();
            }
        }
    }
}
