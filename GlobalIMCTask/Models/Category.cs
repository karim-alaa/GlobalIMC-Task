using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalIMCTask.Models
{
    public class Category
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage ="Category Name Is Required.")]
        [MinLength(3)]
        [MaxLength(30)]
        public string Name { get; set; }


        // Product
        [InverseProperty("Category")]
        public List<Product> Products { get; set; }
    }
}
