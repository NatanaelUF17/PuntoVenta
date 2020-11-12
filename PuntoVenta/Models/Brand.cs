﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PuntoVenta.Models
{
    public class Brand
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Debe completar el campo marca!")]
        [MinLength(2, ErrorMessage = "Debe contener mas de dos caracteres!")]
        public string Name { get; set; }
    }
}
