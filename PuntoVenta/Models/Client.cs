﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PuntoVenta.Models
{
    [Table("Client")]
    public class Client
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Debe completar el campo nombre!")]
        [MinLength(2, ErrorMessage = "Debe contener mas de dos caracteres!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Debe completar el campo apellido!")]
        [MinLength(2, ErrorMessage = "Debe contener mas de dos caracteres!")]
        public string LastName { get; set; }
    }
}
