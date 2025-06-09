using System.ComponentModel.DataAnnotations;

namespace SafeGuardAPI.Models
{
    public class Alerta
    {
        public int IdAlerta { get; set; }

        public string Mensagem { get; set; }

        public DateTime DataAlerta { get; set; }

        public int RiscoId { get; set; }
    }
}
