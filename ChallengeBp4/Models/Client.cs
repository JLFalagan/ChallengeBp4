using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ChallengeBp4.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "El Nombre es requerido")]
        [StringLength(250)]
        public string Name { get; set; }

        [Required(ErrorMessage = "El Apellido es requerido")]
        [StringLength(250)]
        public string Surname { get; set; }

        [Required(ErrorMessage = "La fecha de nacimiento es requerida")]
        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }

        [Required(ErrorMessage = "El CUIT es requerido")]
        [StringLength(11)]
        [RegularExpression("^[0-9]+$")]
        public string CUIT { get; set; }

        [StringLength(300)]
        public string Address { get; set; }
        
        [Required(ErrorMessage = "El Celular es requerido")]
        [StringLength(10)]
        [RegularExpression("^[0-9]+$")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "El correo electronico es requerido")]
        [EmailAddress]
        public string Email { get; set; }
    }
}
