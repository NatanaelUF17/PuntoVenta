using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PuntoVenta.Models
{
    [Table("Category")]
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Debe completar el campo categoria!")]
        [MinLength(2, ErrorMessage = "Debe contener mas de dos caracteres!")]
        public string Name { get; set; }
    }
}
