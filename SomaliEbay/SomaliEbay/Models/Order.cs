using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SomaliEbay.Models
{
    public class Order
    {

       [Key]

        public int Id { get; set; }

        [Required]

        public int Qty { get; set; }

        [Required]

        public decimal TotalCost{ get; set; }
        [Required]

        public decimal TotalPaid { get; set; }
        [Required]

        public bool ISpaid { get; set; } = false;

        public int? ProductId { get; set; } 

        public Product product{ get; set; }


    }
}
