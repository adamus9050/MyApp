using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faktura.Models
{
    public class Kolnierz : MainModelClass
    {
        [Required]

        [Column(TypeName ="decimal(6,2)")]
        public double PriceKolnierz { get; set; }

        public Kolnierz(string name, double priceKolnierz) : base(name)
        {
            Name = name;
            PriceKolnierz = priceKolnierz;
        }

    }
}
