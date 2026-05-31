using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NecroClock.Application.Models
{
    [Table("Demandas")]
    public class DemandaModel
    {
        [Key]
        [Column("Id")]
        public long Id { get; set; }

        [Column("NumeroDemanda")]
        public string NumeroDemanda { get; set; }

        [Column("Descricao")]
        public string Descricao { get; set; }

        [Column("Horas")]
        public long Horas { get; set; }

        [Column("Data")]
        public DateTime Data { get; set; }

        [Column("UserId")]
        public long UserId { get; set; }
    }
}
