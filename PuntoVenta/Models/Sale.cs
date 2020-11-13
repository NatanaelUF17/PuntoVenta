using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PuntoVenta.Models
{
    [Table("Sale")]
    public class Sale
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Debe seleccionar un cliente!")]
        public int ClientId { get; set; }
        public Client Client { get; set; }
        [DataType(DataType.DateTime), DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime SaleDate { get; set; }
        public List<SaleDetail> SaleDetails { get; set; }
    }
}
