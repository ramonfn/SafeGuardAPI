using System.ComponentModel.DataAnnotations;

namespace SafeGuardAPI.Models
{
    public class Sensor
    {
        public int IdSensor { get; set; }

        public string TipoSensor { get; set; }

        public int EstacaoId { get; set; }
    }
}
