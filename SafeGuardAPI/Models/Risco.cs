using System.ComponentModel.DataAnnotations;

namespace SafeGuardAPI.Models
{
    public class Risco
    {
        public int IdRisco { get; set; }

        public int IdEstacao { get; set; }

        public int Nivel { get; set; }

        public string Descricao { get; set; }
    }
}
