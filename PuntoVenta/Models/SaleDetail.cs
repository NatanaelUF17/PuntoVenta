using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PuntoVenta.Models
{
    [Table("SaleDetail")]
    public class SaleDetail
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Debe seleccionar un producto!")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int SaleId { get; set; }
        public Sale Sale { get; set; }
        [Required(ErrorMessage = "Debe haber una cantidad para realizar la venta!")]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "Debe ingresar un precio para realizar la venta!")]
        public double Price { get; set; }
        public double Total { get; set; }
    }
}
