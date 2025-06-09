using System;
using System.ComponentModel.DataAnnotations;

namespace SafeGuardAPI.Models
{
    public class Leitura
    {
        public int IdLeitura { get; set; }

        public int SensorId { get; set; }

        public DateTime DataHora { get; set; }

        public decimal Valor { get; set; }
    }
}
