using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faktura.Models
{
    public abstract class MainModelClass
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        [MinLength(3)]
        public string Name { get; set; }

        public MainModelClass(string name) 
        {
            Name= name;
        }
    }
}
