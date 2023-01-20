﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faktura.Models
{
    public class AdressesCustomers
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Street { get; set; } = null!;
        [Required]
        public string StreetNumber { get; set; } = null!;
        [Required]
        [Column("PhoneNumber", TypeName = "ntext")]
        [MaxLength(5)]
        public string PostCode { get; set; }
        [Required]
        public string City { get; set; } = null!;

        public AdressesCustomers(string street,string streetNumber,string postCode,string city)
        {
            Street = street;
            StreetNumber = streetNumber;
            PostCode = postCode;
            City = city;
        }
    }
}
