using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIFila.Model
{
    public class ItemFila
    {
        [StringLength(3), Required]
        public string Moeda { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public string Data_Inicio { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public string Data_Fim { get; set; }
        public string MensagemRetorno { get; set; }
    }
}
