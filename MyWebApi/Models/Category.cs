using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using MYWEBAPI.Models;

namespace MYWEBAPI.Models
{
    [Table("CATEGORIES")]
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        [Required]
        [StringLength(35)]
        public string categoryName { get; set; }
        public virtual ICollection<Product> Products {get; set; }
    }
}
