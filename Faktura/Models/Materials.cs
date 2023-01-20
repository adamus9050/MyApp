using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faktura.Models
{
   public class Materials : MainModelClass
    {
        [Required]
        public double Price { get; set; }

        public Materials(string name, double price) : base(name)
        {
            Name= name;
            Price = price;
        }

        
    }
}
