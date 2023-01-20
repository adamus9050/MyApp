﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faktura.Models
{
    public class Customers : MainModelClass
    {
        [Required]
        public string Surname { get; set; } = null!;
        [Column("PhoneNumber", TypeName = "ntext")]
        [MaxLength(8)]
        public string PhoneNumber { get; set; }
        public int IdAdress { get; set; }
        public AdressesCustomers Adressess { get; set; } = null!;
        

        public Customers(string name, string surname,string phoneNumber) : base(name)
        {
            Name = name;
            Surname = surname;
            PhoneNumber = phoneNumber;

        }

    }

}

