using System.ComponentModel.DataAnnotations;

namespace SafeGuardAPI.Models
{
    public class Estacao
    {
        public int IdEstacao { get; set; }

        public string Nome { get; set; }

        public string Status { get; set; }
    }
}
