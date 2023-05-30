using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UpFit__main.Models
{
    public class MealType
    {
        [Key]
        public int mealTypeID { get; set; }

        [Required]
        public string mealName { get; set;}
    }
}