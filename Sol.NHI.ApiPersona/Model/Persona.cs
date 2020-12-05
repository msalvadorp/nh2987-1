using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sol.NHI.ApiPersona.Model
{
    public class Persona
    {
        [Key]
        public int IdPersona { get; set; }
        public string ApellidoPaterno { get; set; }
        [Required]
        public string ApellidoMaterno { get; set; }
        public string Nombres { get; set; }
    }
}
