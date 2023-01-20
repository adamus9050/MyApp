using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faktura.Models
{
    public class Order
    {
        public int Id { get; set; }

        public Materials IdMaterial { get; set; } = null!; 
        public Customers IdCustomer { get; set; } = null!;
        public Kolnierz IdKolnierz { get; set; } = null!;

    }
}
