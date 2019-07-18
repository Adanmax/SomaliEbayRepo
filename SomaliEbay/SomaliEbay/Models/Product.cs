using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SomaliEbay.Models
{
    public class Product
    {
        [Key]

        public int Id{ get; set; }

        [Required(ErrorMessage = "Product Name Is must")]

        [MinLength(2, ErrorMessage = "2 letters Minimu")]
        [MaxLength(20, ErrorMessage = "20 letters Maximum")]
        public string ProducName { get; set; }

            [Required(ErrorMessage = "Product Description Is must")]

            [MinLength(2, ErrorMessage = "2 letters Minimum")]
            [MaxLength(200, ErrorMessage = "200 letters Maximum")]

         

        public string ProductDescription { get; set; }
        [Required]

        public int Qty{ get; set; }
        [Required]

        public decimal Price { get; set; }

        public byte[] ProductImage { get; set; }

        public decimal? Discount { get; set; }

        public virtual List<Order> Orders { get; set; }
    }
}
