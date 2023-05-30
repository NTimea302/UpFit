using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UpFit__main.Models
{
    public class Food
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int foodID { get; set; }

        [Display(Name = "What type of food is?")]
        [Required(ErrorMessage = "Type Required")]
        public int type { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name Required")]
        public string name { get; set; }

        [Display(Name = "Calories")]
        [Required(ErrorMessage = "Calories Required")]
        public int calories { get; set; }

        [Display(Name = "Proteins")]
        [Required(ErrorMessage = "Proteins Required")]
        public double? proteins { get; set; }

        [Display(Name = "Fats")]
        [Required(ErrorMessage = "Fats Required")]
        public double? fats { get; set; }

        [Display(Name = "Carbohydrates")]
        [Required(ErrorMessage = "Carbs Required")]
        public double? carbs { get; set; }

        [Display(Name = "Fibers")]
        [Required(ErrorMessage = "Fibers Required")]
        public double? fibers { get; set; }

        [Display(Name = "Vitamin A")]
        [Required(ErrorMessage = "Vitamin A Required")]
        public double? vitamin_A { get; set; }

        [Display(Name = "Vitamin B")]
        [Required(ErrorMessage = "Vitamin B Required")]
        public double? vitamin_B { get; set; }

        [Display(Name = "Vitamin C")]
        [Required(ErrorMessage = "Vitamin C Required")]
        public double? vitamin_C { get; set; }

        [Display(Name = "Vitamin D")]
        [Required(ErrorMessage = "Vitamin D Required")]
        public double? vitamin_D { get; set; }

        [Display(Name = "Vitamin E")]
        [Required(ErrorMessage = "Vitamin E Required")]
        public double? vitamin_E { get; set; }
    }
}