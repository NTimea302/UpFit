using System;
using System.ComponentModel.DataAnnotations;

namespace UpFit__main.Models
{
    public class Meal
    {
        [Key]
        public int mealID { get; set; }

        [Required]
        [Display(Name = "Meal Type")]
        public int mealTypeFK { get; set; }

        [Required]
        [Display(Name = "User")]
        public int userFK { get; set; }

        [Required]
        [Display(Name = "Food")]
        public int foodFK { get; set; }

        [Required]
        [Display(Name = "Quantity")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be a positive value.")]
        public int quantity { get; set; }

        [Required]
        [Display(Name = "Date")]
        [DataType(DataType.DateTime)]
        public DateTime date { get; set; }

       
    }
}
