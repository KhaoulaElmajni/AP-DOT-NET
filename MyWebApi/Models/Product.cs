using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MYWEBAPI.Models
{
    [Table("PRODUCTS")]
    public class Product
    {
        [Key]
        [Display(Name ="Product ID")]
        public int ProductId { get; set; }

        [Required,MinLength(6),MaxLength(25)]
        [StringLength(70)]
        public string Designation { get; set; }

        [Required,Range(100,1000000)]
        public double Price { get; set; }

        public int CategoryID { get; set; }
        
        public virtual Category Category { get; set; }
    }

}