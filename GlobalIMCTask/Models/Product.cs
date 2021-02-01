using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GlobalIMCTask.Models
{
    public class Product
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Product Title Is Required.")]
        [MinLength(3)]
        [MaxLength(30)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Product Price Is Required.")]
        [Range(1,999999999)]
        public double Price { get; set; }


        //[Required(ErrorMessage = "Product Description Is Required.")]
        [MinLength(5)]
        [MaxLength(100)]
        public string Description { get; set; }


        // Category
        [Display(Name ="Category")]
        public Guid CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        [JsonIgnore]
        public Category Category { get; set; }
    }
}
