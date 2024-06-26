﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiCupMetric.Models
{
    [Table("UTENSILIO")]
    public class Utensilio
    {
        [Key]
        [Column("IdUtensilio")]
        public int IdUtensilio { get; set; }
        [Column("Nombre")]
        public string Nombre { get; set; }
        [Column("Volumen")]
        public double Volumen { get; set; }
        [Column("Imagen")]
        public string Imagen { get; set; }
        [Column("Recomendacion")]
        public string Recomendacion { get; set; }
    }

}
