using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace API.Models
{
    public partial class tb_gastos
    {
        [MetadataType(typeof(tb_gastos.MetaData))]
        sealed class MetaData
        {
            [Required]
            public string nombre_gasto { get; set; }
            [Required]
            public decimal valor_gasto { get; set; }
            [Required]
            public decimal pagado { get; set; }
            [Required]
            public decimal total { get; set; }
        }
    }
}