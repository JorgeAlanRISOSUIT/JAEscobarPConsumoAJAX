using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML.DTO
{
    public class EntidadDTO
    {
        [Key]
        public int IdEntidad { get; set; }
        [Required]
        public string Nombre { get; set; }
    }
}
