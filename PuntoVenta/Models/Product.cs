using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PuntoVenta.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [Required(ErrorMessage = "Debe seleccionar una categoria!")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        [Required(ErrorMessage = "Debe seleccionar una marca!")]
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        [Required(ErrorMessage = "No puede haber un stock vacio!")]
        public int Stock { get; set; }
        [Required(ErrorMessage = "El producto debe contener un precio!")]
        public double Price { get; set; }
    }
}
